using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]

    public class DeviceSortCodeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private int pageSize = 50;

        public DeviceSortCodeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context.BMEDDeviceSortCodes.Take(pageSize) != null)
            {
                return View();
            }
            else
                return View(_context.BMEDDeviceSortCodes.Take(pageSize).ToList());
        }

        [HttpPost]
        public IActionResult Index(string name,int page = 1)
        {
            List<DeviceSortCode> dev = new List<DeviceSortCode>();

            if (!string.IsNullOrEmpty(name))
            {
                dev = _context.BMEDDeviceSortCodes.Where(d => name.Contains(d.M_name)).ToList();
            }
            else
            {
                dev = _context.BMEDDeviceSortCodes.ToList();
            }

            //if (dev.Count() <= 0)
            //{
            //    return PartialView(dev);
            //}
            //
            var pageCount = dev.ToPagedList(page, pageSize).PageCount;
            pageCount = pageCount == 0 ? 1 : pageCount; // If no page.
            if (dev.ToPagedList(page, pageSize).Count <= 0)  //If the page has no items.
                return PartialView("List", dev.ToPagedList(pageCount, pageSize));
            return PartialView("List", dev.ToPagedList(page, pageSize));
        }

        // GET: 
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return StatusCode(404);
            }

            DeviceSortCode deviceSort = _context.BMEDDeviceSortCodes.Find(id);

            if (deviceSort == null)
            {
                return BadRequest("無資料");
            }
            return View(deviceSort);
        }

        // GET: MedEngMgt/FailFactors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedEngMgt/FailFactors/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Create(DeviceSortCode deviceSort)
        {
            var msg = "";

            try
            { 
                if (ModelState.IsValid)
                {
                    var sortcode = _context.BMEDDeviceSortCodes.Where(d => d.M_code == deviceSort.M_code).FirstOrDefault();
                    if ( sortcode != null )
                    {
                        msg = "此分類碼已存在";
                    }
                    else { 
                        _context.BMEDDeviceSortCodes.Add(deviceSort);
                        _context.SaveChanges();
                        return Ok(deviceSort);
                    }
                }
                else
                {
                    foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                    {
                        msg += error.ErrorMessage + Environment.NewLine;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }

             return BadRequest(msg);
        }

        // GET: MedEngMgt/FailFactors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }
            DeviceSortCode deviceClass = _context.BMEDDeviceSortCodes.Find(id);
            if (deviceClass == null)
            {
                return BadRequest("無資料");
            }
            return View(deviceClass);
        }

        // POST: MedEngMgt/FailFactors/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Edit(DeviceSortCode deviceClass)
        {
            var msg = "";
            try { 
                if (ModelState.IsValid)
                {
                    _context.Entry(deviceClass).State = EntityState.Modified;
                    _context.BMEDDeviceSortCodes.Update(deviceClass);
                    _context.SaveChanges();
                    return Json(true);
                }
                else
                {
                    foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                    {
                        msg += error.ErrorMessage + Environment.NewLine;
                    }
                
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return BadRequest(msg);
        }

        // GET: MedEngMgt/FailFactors/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }
            DeviceSortCode deviceClass = _context.BMEDDeviceSortCodes.Find(id);
            if (deviceClass == null)
            {
                return BadRequest("無資料");
            }
            return View(deviceClass);
        }

        // POST: MedEngMgt/FailFactors/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            DeviceSortCode deviceClass = _context.BMEDDeviceSortCodes.Find(id);
            if (deviceClass == null)
            {
                return BadRequest("資料錯誤");
            }
            _context.BMEDDeviceSortCodes.Remove(deviceClass);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}