using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDIS.Models;
using Microsoft.AspNetCore.Authorization;
using EDIS.Models.Identity;
using EDIS.Areas.WebService.Models;
using Microsoft.AspNetCore.Http;
using X.PagedList;
using EDIS.Repositories;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class VendorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<DocIdStore, string[]> _dsRepo;
        private int pageSize = 50;

        public VendorController(ApplicationDbContext context,
                                IRepository<DocIdStore, string[]> dsRepo)
        {
            _context = context;
            _dsRepo = dsRepo;
        }

        // GET: Vendor
        public IActionResult Index()
        {
            return View();//await _context.BMEDVendors.ToListAsync()
        }

        [HttpPost]
        public ActionResult Index(string name,string uniteno, int page = 1)
        {
            string qname = name;
            string uno = uniteno;
            List<VendorModel> mv = new List<VendorModel>();
            var vt = _context.BMEDVendors.AsQueryable();
            if (!string.IsNullOrEmpty(qname))
            {
                vt = vt.Where(v => v.VendorName.Contains(qname));
            }
            if (!string.IsNullOrEmpty(uno))
            {
                vt = vt.Where(v => v.UniteNo == uno);
            }
            mv = vt.ToList();
            var vts =  mv.ToPagedList(page, pageSize);

            return PartialView("List",vts);
        }

        // GET: Vendor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorModel = await _context.BMEDVendors
                .SingleOrDefaultAsync(m => m.VendorId == id);
            if (vendorModel == null)
            {
                return NotFound();
            }

            return View(vendorModel);
        }

        // GET: Vendor/Create
        public IActionResult Create()
        {
            VendorModel ven = new VendorModel();
            ven.VendorId = Convert.ToInt32(GetID());
            return View(ven);
        }

        // POST: Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendorId,VendorName,Address,Tel,Fax,Email,UniteNo,TaxAddress,TaxZipCode,Contact,ContactTel,ContactEmail,StartDate,EndDate,Status,Kind")] VendorModel vendorModel)
        {
            var msg = "";
            try
            {
                if (ModelState.IsValid)
                {
                    _context.BMEDVendors.Add(vendorModel);
                    await _context.SaveChangesAsync();
                    return Ok(vendorModel);
                }
                else
                {
                    foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                    {
                        msg += error.ErrorMessage + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return BadRequest(msg);
        }

        // GET: Vendor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(404);
            }

            var vendorModel = await _context.BMEDVendors.SingleOrDefaultAsync(m => m.VendorId == id);
            
            if (vendorModel == null)
            {
                return BadRequest("查無資料!");
            }
            return View(vendorModel);
        }

        // POST: Vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendorId,VendorName,Address,Tel,Fax,Email,UniteNo,TaxAddress,TaxZipCode,Contact,ContactTel,ContactEmail,StartDate,EndDate,Status,Kind")] VendorModel vendorModel)
        {
            var vendor =  _context.BMEDVendors.Where(m => m.VendorId == id);
            var msg = "";
            if (vendor == null)
            {
                return StatusCode(404);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(vendorModel).State = EntityState.Modified;
                    _context.BMEDVendors.Update(vendorModel);
                    await _context.SaveChangesAsync();
                    return Ok(vendorModel);
                }
                else
                {
                  foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                  {
                     msg += error.ErrorMessage + Environment.NewLine;
                  }
                }
            }

            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return BadRequest(msg);
        }

        // GET: Vendor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendorModel = await _context.BMEDVendors
                .SingleOrDefaultAsync(m => m.VendorId == id);
            if (vendorModel == null)
            {
                return NotFound();
            }

            return View(vendorModel);
        }

        // POST: Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendorModel = await _context.BMEDVendors.SingleOrDefaultAsync(m => m.VendorId == id);
            _context.BMEDVendors.Remove(vendorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult QryVendor(QryVendor qryVendor)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (qryVendor.QryType == "關鍵字")
            {
                if (!string.IsNullOrEmpty(qryVendor.KeyWord))
                {
                    _context.BMEDVendors.Where(v => v.VendorName.Contains(qryVendor.KeyWord.Trim()))
                                        .ToList()
                                        .ForEach(v => {
                                            items.Add(new SelectListItem()
                                            {
                                                Text = v.VendorName,
                                                Value = v.VendorId.ToString()
                                            });
                                        });
                }
            }
            else if (qryVendor.QryType == "統一編號")
            {
                _context.BMEDVendors.Where(v => v.UniteNo == qryVendor.UniteNo)
                        .ToList()
                        .ForEach(v => {
                            items.Add(new SelectListItem()
                            {
                                Text = v.VendorName,
                                Value = v.VendorId.ToString()
                            });
                        });
            }

            qryVendor.VendorList = items;

            return PartialView(qryVendor);
        }

        [HttpGet]
        public async Task<JsonResult> GetVendorByKeyName(string keyWord)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var ERPvendors = await new ERPVendors().GetERPVendorsByKeyNameAsync(keyWord, keyWord);
            if (ERPvendors.Count() > 0)
            {
                foreach(var vendor in ERPvendors)   // Check the ERP vendor is in the BMEDVendors or not. If not, add to db.
                {
                    var vd = _context.BMEDVendors.Where(v => v.UniteNo == vendor.UNI_NO).FirstOrDefault();
                    if (vd == null)
                    {
                        VendorModel bmedVendor = new VendorModel();
                        bmedVendor.VendorId = Convert.ToInt32(vendor.UNI_NO);
                        bmedVendor.VendorName = vendor.NAME;
                        bmedVendor.UniteNo = vendor.UNI_NO;
                        _context.BMEDVendors.Add(bmedVendor);
                        _context.SaveChanges();
                    }
                }
            }
            //
            if (!string.IsNullOrEmpty(keyWord))
            {
                _context.BMEDVendors.Where(v => v.VendorName.Contains(keyWord.Trim()) ||
                                                v.UniteNo.Contains(keyWord.Trim())).ToList()
                                    .ForEach(v => {
                                        items.Add(new SelectListItem()
                                        {
                                            Text = v.VendorName + "(" + v.UniteNo + ")",
                                            Value = v.VendorId.ToString()
                                        });
                                    });
            }
            return Json(items);
        }

        private bool VendorModelExists(int id)
        {
            return _context.BMEDVendors.Any(e => e.VendorId == id);
        }

        public IActionResult Choose(string KeyWord = "", string UniteNo = "", string src = "ws")
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            List<VendorModel> vr = _context.BMEDVendors.ToList();
            if (KeyWord != "")
                vr = vr.Where(r => r.VendorName.Contains(KeyWord)).ToList();
            if (UniteNo != "")
                vr = vr.Where(r => r.UniteNo == UniteNo).ToList();
            foreach (VendorModel v in vr)
            {
                listItem.Add(new SelectListItem { Text = v.VendorName, Value = v.UniteNo });
            }
            ViewData["Vendors"] = new SelectList(listItem.Distinct(), "Value", "Text", "");
            return PartialView();
        }

        public IActionResult GetMembers(string uniteno = null)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem li;
            VendorModel v = _context.BMEDVendors.Where(vr => vr.UniteNo == uniteno && vr.Status == "Y").FirstOrDefault();
            if (v != null)
            {
                List<AppUserModel> ur = _context.AppUsers.Where(u => u.VendorId == v.VendorId).ToList();
                foreach (AppUserModel p in ur)
                {
                    li = new SelectListItem();
                    li.Text = p.FullName;
                    li.Value = p.Id.ToString();
                    list.Add(li);
                }
            }
            return Json(list);
        }

        public string IsInVendor(string uniteno = null)
        {
            List<VendorModel> vv = _context.BMEDVendors.Where(v => v.UniteNo == uniteno).ToList();
            if (vv.Count > 0)
                return "";
            return "*此廠商尚未建檔";
        }

        public string GetID()
        {
            string did = "";
            try
            {
                DocIdStore ds = new DocIdStore();
                ds.DocType = "廠商資料";
                string s = _dsRepo.Find(x => x.DocType == "廠商資料").Select(x => x.DocId).Max();
                int yymmdd = (System.DateTime.Now.Year - 1911) * 1000 + (System.DateTime.Now.Month) * 100 + System.DateTime.Now.Day ;
                if (!string.IsNullOrEmpty(s))
                {
                    did = s;
                }
                if (did != "")
                {
                    if (Convert.ToInt64(did) / 1000 == yymmdd)
                        did = Convert.ToString(Convert.ToInt64(did) + 1);
                    else
                        did = Convert.ToString(yymmdd * 1000 + 1);
                    ds.DocId = did;
                    _dsRepo.Update(ds);
                }
                else
                {
                    did = Convert.ToString(yymmdd * 1000 + 1);
                    ds.DocId = did;
                    // 二次確認資料庫內沒該資料才新增。
                    var dataIsExist = _dsRepo.Find(x => x.DocType == "廠商資料");
                    if (dataIsExist.Count() == 0)
                    {
                        _dsRepo.Create(ds);
                    }
                }
            }
            catch (Exception e)
            {
                RedirectToAction("Create", "Repair", new { Area = "BMED" });
            }
            return did;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}
