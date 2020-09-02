using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using EDIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class KeepDtlController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KeepDtlController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: BMED/KeepDtl/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KeepDtlModel keepDtlModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (keepDtlModel.IsCharged == "N")
                    {
                        var keepCost = _context.BMEDKeepCosts.Where(c => c.DocId == keepDtlModel.DocId).ToList();
                        if (keepCost.Count() > 0)
                        {
                            throw new Exception("點選無費用時，請先刪除所有費用明細!!");
                        }
                        //_context.BMEDKeepCosts.RemoveRange(_context.BMEDKeepCosts.Where(c => c.DocId == keepDtlModel.DocId));
                        keepDtlModel.Cost = 0;
                    }
                    else
                    {
                        keepDtlModel.Cost = _context.BMEDKeepCosts.Where(k => k.DocId == keepDtlModel.DocId)
                                                                  .Select(k => k.TotalCost)
                                                                  .DefaultIfEmpty(0).Sum();
                        int hr = _context.BMEDKeepEmps.Where(p => p.DocId == keepDtlModel.DocId)
                                                      .Select(p => p.Hour)
                                                      .DefaultIfEmpty(0).Sum();
                        decimal min = _context.BMEDKeepEmps.Where(p => p.DocId == keepDtlModel.DocId)
                                                           .Select(p => p.Minute)
                                                           .DefaultIfEmpty(0).Sum();
                        keepDtlModel.Hours = hr + Decimal.Round(min / 60m, 2);
                    }
                    _context.Entry(keepDtlModel).State = EntityState.Modified;
                    _context.SaveChanges();
                    return new JsonResult(keepDtlModel)
                    {
                        Value = new { success = true, error = "" }
                    };
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
        }

    }
}
