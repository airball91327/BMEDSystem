﻿using EDIS.Models;
using EDIS.Models.Identity;

using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;



namespace EDIS.Areas.BMED.Components.AssetFile
{
    public class AssetFileAssetListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private int pageSize = 100;

        public AssetFileAssetListViewComponent(ApplicationDbContext context,
                                               IRepository<AppUserModel, int> userRepo,
                                               CustomUserManager customUserManager,
                                               CustomRoleManager customRoleManager)
        {
            _context = context;
            _userRepo = userRepo;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            List<AssetFileModel> af = new List<AssetFileModel>();
            if (id != null)
            {
                AssetModel at = _context.BMEDAssets.Find(id);
                ViewData["PlantNo"] = at.AssetNo;
                ViewData["PlantName"] = at.Cname;
                AppUserModel u;
                af = _context.AssetFiles.Where(f => f.AssetNo == id).OrderBy(f => f.SeqNo).ToList();

                foreach (AssetFileModel a in af)
                {
                    u = _context.AppUsers.Find(Convert.ToInt32(a.Rtp));
                    a.UserName = u.FullName;
                }
            }
            else
            {
                AppUserModel u;
                af = _context.AssetFiles.ToList();
                foreach (AssetFileModel a in af)
                {
                    u = _context.AppUsers.Find(Convert.ToInt32(a.Rtp));
                    a.UserName = u.FullName;
                }
            }
            return View(af);
        }
    }
}
