using EDIS.Models;
using EDIS.Models.Identity;

using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.BMED.Components.Repair
{
    public class BMEDRepEditViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;

        public BMEDRepEditViewComponent(ApplicationDbContext context,
                                        IRepository<AppUserModel, int> userRepo,
                                        CustomUserManager customUserManager)
        {
            _context = context;
            _userRepo = userRepo;
            userManager = customUserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            RepairModel repair = _context.BMEDRepairs.Find(id);

            /* Get and set value for NotMapped fields. */
            repair.DptName = _context.Departments.Find(repair.DptId).Name_C;
            repair.DptName = repair.DptName + "(" + repair.DptId + ")";
            repair.AccDptName = _context.Departments.Find(repair.AccDpt).Name_C;
            repair.CheckerName = _context.AppUsers.Find(repair.CheckerId).FullName;
            repair.UserName = repair.UserName + "(" + repair.UserId + ")";


            if (repair.AssetNo != null)
            {
                var asset = _context.BMEDAssets.Find(repair.AssetNo);
                if (asset != null)
                {
                    if (asset.AccDate.HasValue)
                    {
                        repair.AssetAccDate = asset.AccDate.Value.ToString("yyyy/MM/dd");
                    }
                }
            }

            return View(repair);
        }

    }
}
