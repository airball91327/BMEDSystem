using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDIS.Models;

namespace EDIS.Areas.BMED.Components.DeptStock
{
    public class BMEDDeptStockIndexViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public BMEDDeptStockIndexViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? stockId,string id)
        {
            ViewBag.StockClsId = new SelectList(_context.BMEDDeptStocks, "StockId", "StockName", stockId);
            ViewData["docid"] = id;
            return View();
        }

    }
}
