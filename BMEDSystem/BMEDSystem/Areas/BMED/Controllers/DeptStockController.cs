﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDIS.Models;
using Microsoft.AspNetCore.Http;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using WebService;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Newtonsoft.Json;
using EDIS.Areas.WebService.Models;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class DeptStockController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private int pageSize = 20;

        public DeptStockController(ApplicationDbContext context,
                                   IRepository<AppUserModel, int> userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        public async Task<IActionResult> Index(IFormCollection fm, int page = 1)
        {
            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();

            string stockno = fm["qtySTOCKNO"];
            string dname = fm["qtyDEPTNAME"];
            string brand = fm["qtyBRAND"];
            //List<DeptStockModel> dv = _context.BMEDDeptStocks.ToList();
            List<DeptStockModel> dv = await GetERPDptStokAsync(ur.UserName);
            if (string.IsNullOrEmpty(stockno) && string.IsNullOrEmpty(dname) && string.IsNullOrEmpty(brand))
            {
                dv = dv.Where(d => d.Qty > 0).ToList();
            }
            else
            {
                if (!string.IsNullOrEmpty(stockno))
                {
                    dv = dv.Where(d => d.StockNo.Contains(stockno)).ToList();
                }
                if (!string.IsNullOrEmpty(dname))
                {
                    dv = dv.Where(d => d.StockName.Contains(dname)).ToList();
                }
                if (!string.IsNullOrEmpty(brand))
                {
                    dv = dv.Where(d => d.Brand == brand.ToUpper()).ToList();
                }

            }
            
            
            if (dv.ToPagedList(page, pageSize).Count <= 0)
                return PartialView("List", dv.ToPagedList(1, pageSize));

            return PartialView("List", dv.ToPagedList(page, pageSize));
        }

        // GET: DeptStock/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptStock = await _context.BMEDDeptStocks
                .SingleOrDefaultAsync(m => m.StockId == id);
            if (deptStock == null)
            {
                return NotFound();
            }

            return View(deptStock);
        }

        // GET: DeptStock/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeptStock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StokId,StokCls,StokNo,StokNam,Unite,Price,Qty,SafeQty,Loc,Standard,Brand,Status,Rtp,Rtt,CustOrgan_CustId")] DeptStockModel deptStockModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deptStockModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deptStockModel);
        }

        // GET: DeptStock/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptStockModel = await _context.BMEDDeptStocks.SingleOrDefaultAsync(m => m.StockId == id);
            if (deptStockModel == null)
            {
                return NotFound();
            }
            return View(deptStockModel);
        }

        // POST: DeptStock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StokId,StokCls,StokNo,StokNam,Unite,Price,Qty,SafeQty,Loc,Standard,Brand,Status,Rtp,Rtt,CustOrgan_CustId")] DeptStockModel deptStockModel)
        {
            if (id != deptStockModel.StockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deptStockModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptStockModelExists(deptStockModel.StockId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deptStockModel);
        }

        // GET: DeptStock/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptStockModel = await _context.BMEDDeptStocks
                .SingleOrDefaultAsync(m => m.StockId == id);
            if (deptStockModel == null)
            {
                return NotFound();
            }

            return View(deptStockModel);
        }

        // POST: DeptStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deptStockModel = await _context.BMEDDeptStocks.SingleOrDefaultAsync(m => m.StockId == id);
            _context.BMEDDeptStocks.Remove(deptStockModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult List()
        {
            return PartialView();
        }

        private bool DeptStockModelExists(int id)
        {
            return _context.BMEDDeptStocks.Any(e => e.StockId == id);
        }

        private async Task<List<DeptStockModel>> GetERPDptStokAsync(string userName)
        {
            DeptStockModel deptStock;
            List<DeptStockModel> deptStockList = new List<DeptStockModel>();
            Prdts pd;
            int serNo = 1;
#if DEBUG
            userName = "344033";
#endif

            ERPservicesSoapClient ERPWebServices = new ERPservicesSoapClient(ERPservicesSoapClient.EndpointConfiguration.ERPservicesSoap);
            var objs = await ERPWebServices.GetStockAsync("", userName);
            string s = objs.Body.GetStockResult;
            List<WsStock> stocks = JsonConvert.DeserializeObject<List<WsStock>>(s);
            foreach (var obj in stocks)
            {
                var objs2 = await ERPWebServices.GetProductAsync(obj.PRD_NO, "", "");
                s = objs2.Body.GetProductResult;
                pd = JsonConvert.DeserializeObject<List<Prdts>>(s).FirstOrDefault();
                deptStock = new DeptStockModel();
                deptStock.StockId = serNo;
                deptStock.StockName = obj.PRD_NAME;
                deptStock.StockNo = obj.PRD_NO;
                deptStock.Unite = pd.UT;
                deptStock.Qty = obj.QTY == null ? 0 : Convert.ToInt32(obj.QTY);
                deptStock.CUS_NM = obj.CUS_NM;
                deptStockList.Add(deptStock);
                serNo++;
            }
            return deptStockList;
        }

    }
}
