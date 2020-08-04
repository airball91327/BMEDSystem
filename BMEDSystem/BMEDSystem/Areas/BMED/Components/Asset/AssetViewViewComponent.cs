﻿using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using EDIS.Models;

namespace EDIS.Areas.BMED.Components.Asset
{
    public class AssetViewViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private int pageSize = 100;

        public AssetViewViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            if (id == null)
            {
                return View();
            }
            AssetModel asset = _context.BMEDAssets.Find(id);
            if (asset == null)
            {
                return View();
            }
            asset.DelivDptName = _context.Departments.Find(asset.DelivDpt).Name_C;
            asset.AccDptName = _context.Departments.Find(asset.AccDpt).Name_C;

            return View(asset);
        }
    }
}
