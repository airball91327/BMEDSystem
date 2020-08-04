using EDIS.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.BMED.Components.KeepFormat
{
    public class BMEDKeepFormatDtlViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public BMEDKeepFormatDtlViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id = null)
        {
            if (id != null)
            {
                ViewData["fid"] = id;
                return View(_context.BMEDKeepFormatDtls.Where(d => d.FormatId == id).ToList());
            }
            return View(_context.BMEDKeepFormatDtls.ToList());
        }
    }
}
