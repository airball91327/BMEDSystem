﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Models;

using EDIS.Models.Identity;
using EDIS.Repositories;
using EDIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;

using System.Data.SqlClient;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class BuyVendorController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IRepository<DepartmentModel, string> _dptRepo;
        private readonly IEmailSender _emailSender;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;

        public BuyVendorController(ApplicationDbContext context,
                                   IRepository<AppUserModel, int> userRepo,
                                   IRepository<DepartmentModel, string> dptRepo,
                                   IEmailSender emailSender,
                                   CustomUserManager customUserManager,
                                   CustomRoleManager customRoleManager)
        {
            _context = context;
            _userRepo = userRepo;
            _dptRepo = dptRepo;
            _emailSender = emailSender;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }

        //
        // GET: /BuyVendor/
        public IActionResult Index(string id = null)
        {
            List<BuyVendorModel> t = _context.BuyVendors.Where(c => c.DocId == id).ToList();
            return PartialView(t);
        }

        public IActionResult StatusList(string id = null)
        {
            List<BuyVendorModel> tv = _context.BuyVendors.Where(c => c.DocId == id).ToList();
            foreach (BuyVendorModel b in tv)
            {
                if (b.Status == "?")
                    b.Status = "未完成";
                else if (b.Status == "2")
                    b.Status = "已完成";
            }
            return PartialView(tv);
        }

        public IActionResult BuyPriceList(string uniteno = null)
        {
            BuyPriceListVModel bpv = new BuyPriceListVModel(_context);
            return View("_BuyPriceList", bpv.GetList().Where(b => b.UniteNo == uniteno).ToList());
        }

        //
        // GET: /BuyVendor/Details/5

        public IActionResult Details(string id = null)
        {
            BuyVendorModel buyvendor = _context.BuyVendors.Find(id);
            if (buyvendor == null)
            {
                return NotFound();
            }
            return View(buyvendor);
        }

        //
        // GET: /BuyVendor/Create

        public IActionResult Create()
        {
            return View();
        }

        //
        // POST: /BuyVendor/Create

        [HttpPost]
        public IActionResult Create(BuyVendorModel buyvendor)
        {
            if (ModelState.IsValid)
            {
                _context.BuyVendors.Add(buyvendor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buyvendor);
        }

        //
        // GET: /BuyVendor/Edit/5

        public IActionResult Edit(string id = null)
        {
            BuyVendorModel buyvendor = new BuyVendorModel();
            buyvendor.DocId = id;
            return PartialView(buyvendor);
        }

        //
        // POST: /BuyVendor/Edit/5

        [HttpPost]
        public IActionResult Edit(BuyVendorModel buyvendor)
        {
            if (ModelState.IsValid)
            {
                // Get Login User's details.
                var loginUser = _userRepo.Find(ur => ur.UserName == User.Identity.Name).FirstOrDefault();
                buyvendor.Status = "?";
                buyvendor.Rtp = loginUser.Id.ToString();
                buyvendor.Rtt = DateTime.Now;
                _context.BuyVendors.Add(buyvendor);
                _context.SaveChanges();
                List<BuyVendorModel> rf = _context.BuyVendors.Where(f => f.DocId == buyvendor.DocId).ToList();
                return PartialView("Index", rf);
            }
            return View(buyvendor);
        }

        public IActionResult UpdStatus(string id = null, string vno = null)
        {
            // Get Login User's details.
            var loginUser = _userRepo.Find(ur => ur.UserName == User.Identity.Name).FirstOrDefault();
            BuyVendorModel buyvendor = _context.BuyVendors.Find(id, vno);
            buyvendor.Status = "?";
            buyvendor.Rtp = loginUser.Id.ToString();
            buyvendor.Rtt = DateTime.Now;
            _context.Entry(buyvendor).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return new JsonResult(buyvendor)
            {
                Value = new { success = true, error = "" },
            };
        }
        //
        // GET: /BuyVendor/Delete/5

        public IActionResult Delete(string id = null, string vno = null)
        {
            BuyVendorModel buyvendor = _context.BuyVendors.Find(id, vno);
            if (buyvendor == null)
            {
                return NotFound();
            }
            _context.BuyVendors.Remove(buyvendor);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return new JsonResult(buyvendor)
            {
                Value = new { success = true, error = "" },
            };
        }

        //
        // POST: /BuyVendor/Delete/5

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            BuyVendorModel buyvendor = _context.BuyVendors.Find(id);
            _context.BuyVendors.Remove(buyvendor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Upload(string id = null, string vno = null)
        {
            BuyVendorModel buyvendor = _context.BuyVendors.Find(id, vno);
            buyvendor.Status = "2";
            buyvendor.Rtp = vno;
            buyvendor.Rtt = DateTime.Now;
            _context.Entry(buyvendor).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return RedirectToAction("BuyPriceList", "BuyVendor", new { uniteno = buyvendor.UniteNo});
        }

        public IActionResult Home()
        {
            return PartialView(new BuyPriceListVModel(_context).GetHomeList());
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}