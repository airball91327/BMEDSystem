using EDIS.Models;
using EDIS.Models.Identity;

using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EDIS.Areas.BMED.Components.KeepCost
{
    public class BMEDKeepCostListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomUserManager userManager;

        public BMEDKeepCostListViewComponent(ApplicationDbContext context, 
                                             CustomUserManager customUserManager)
        {
            _context = context;
            userManager = customUserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id, string viewType)
        {
            List<KeepCostModel> kc = _context.BMEDKeepCosts.Include(r => r.TicketDtl)
                                                           .Where(c => c.DocId == id).ToList();
            kc.ForEach(r => {
                if (r.StockType == "0")
                    r.StockType = "庫存";
                else if (r.StockType == "2")
                    r.StockType = "發票";
                else
                    r.StockType = "簽單";
                //
                if (r.TaxClass == "1")
                    r.TaxClass = "收據";
                else if (r.TaxClass == "2")
                    r.TaxClass = "二聯式發票";
                else
                    r.TaxClass = "三聯式發票";
            });

            /* Check the device's contract. */
            var keepDtl = _context.BMEDKeepDtls.Find(id);
            if (keepDtl.NotInExceptDevice == "Y") //該案件為統包
            {
                ViewData["HideCost"] = "Y";
            }
            else
            {
                ViewData["HideCost"] = "N";
            }
            // Get Vendor uniteNo.
            foreach (var item in kc)
            {
                if (item.VendorId != null)
                {
                    var vendor = _context.BMEDVendors.Find(item.VendorId);
                    if (vendor != null)
                    {
                        item.VendorUniteNo = vendor.UniteNo;
                    }
                }
            }
            if (viewType.Contains("Edit"))
            {
                return View(kc);
            }
            return View("List2", kc);
        }

    }
}
