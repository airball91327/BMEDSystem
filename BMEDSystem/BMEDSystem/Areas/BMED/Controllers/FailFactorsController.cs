using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using EDIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class FailFactorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        private int pageSize = 50;

        public FailFactorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View(_context.BMEDFailFactors.ToList());
        }

        // GET: 
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(404);
            }

            FailFactorModel failFactor = _context.BMEDFailFactors.Find(id);

            if (failFactor == null)
            {
                return BadRequest("無資料");
            }
            return View(failFactor);
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
        public ActionResult Create(FailFactorModel failFactor)
        {
            if (ModelState.IsValid)
            {
                _context.BMEDFailFactors.Add(failFactor);
                _context.SaveChanges();
                return Ok(failFactor);
            }
            else
            {
                var msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
        }

        // GET: MedEngMgt/FailFactors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }
            FailFactorModel failFactor = _context.BMEDFailFactors.Find(id);
            if (failFactor == null)
            {
                return BadRequest("無資料");
            }
            return View(failFactor);
        }

        // POST: MedEngMgt/FailFactors/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Edit(FailFactorModel failFactor)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(failFactor).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(true);
            }
            else
            {
                var msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
        }

        // GET: MedEngMgt/FailFactors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }
            FailFactorModel failFactor = _context.BMEDFailFactors.Find(id);
            if (failFactor == null)
            {
                return BadRequest("無資料");
            }
            return View(failFactor);
        }

        // POST: MedEngMgt/FailFactors/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            FailFactorModel failFactor = _context.BMEDFailFactors.Find(id);
            if (failFactor == null)
            {
                return BadRequest("資料錯誤");
            }
            _context.BMEDFailFactors.Remove(failFactor);
            _context.SaveChanges();
            return Json(true);
        }
    }
}