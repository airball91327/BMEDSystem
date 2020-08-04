using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDIS.Models;

using X.PagedList;

namespace EDIS.Areas.BMED.Components.DeptStock
{
    public class BMEDDeptStockListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private int pageSize = 100;

        public BMEDDeptStockListViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int page = 1)
        {
            List<DeptStockModel> dv = _context.BMEDDeptStocks.ToList();

            if (dv.ToPagedList(page, pageSize).Count <= 0)
                return View(dv.ToPagedList(1, pageSize));

            return View(dv.ToPagedList(page, pageSize));
        }

    }
}
