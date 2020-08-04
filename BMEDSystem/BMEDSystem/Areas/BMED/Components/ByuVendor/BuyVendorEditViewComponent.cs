﻿using EDIS.Models;
using EDIS.Models.Identity;

using EDIS.Areas.BMED.Repositories;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace EDIS.Areas.BMED.Components.BuyVendor
{
    public class BuyVendorEditViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string id = null)
        {
            BuyVendorModel buyvendor = new BuyVendorModel();
            buyvendor.DocId = id;
            return View(buyvendor);
        }
    }
}
