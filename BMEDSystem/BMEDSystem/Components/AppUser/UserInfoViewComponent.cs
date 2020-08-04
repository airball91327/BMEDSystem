﻿using EDIS.Models;

using EDIS.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Components.AppUser
{
    public class UserInfoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomRoleManager roleManager;

        public UserInfoViewComponent(ApplicationDbContext context,
                                     CustomRoleManager customRoleManager)
        {
            _context = context;
            roleManager = customRoleManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            int userId = Convert.ToInt32(id);
            AppUserModel user = _context.AppUsers.Find(userId);
            return View(user);
        }
    }
}
