using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDIS.Models;

namespace EDIS.Areas.BMED.Components.ERPProduct
{
    public class ERPProductIndexViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ERPProductIndexViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? stockId)
        {
            return View();
        }

    }
}
