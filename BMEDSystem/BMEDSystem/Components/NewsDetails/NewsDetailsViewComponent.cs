using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Components.NewsDetails
{
    public class NewsDetailsViewComponent : ViewComponent
    {
            private readonly ApplicationDbContext _context;
            private readonly IRepository<AppUserModel, int> _userRepo;
            private readonly IRepository<DepartmentModel, string> _dptRepo;
            private readonly CustomUserManager userManager;
            private readonly CustomRoleManager roleManager;
            private readonly IRepository<DocIdStore, string[]> _dsRepo;
            
            public NewsDetailsViewComponent(ApplicationDbContext context,
                                    IRepository<AppUserModel, int> userRepo,
                                    IRepository<DepartmentModel, string> dptRepo,
                                    CustomUserManager customUserManager,
                                    CustomRoleManager customRoleManager,
                                    IRepository<DocIdStore, string[]> dsRepo)
            {
                _context = context;
                _userRepo = userRepo;
                _dptRepo = dptRepo;
                userManager = customUserManager;
                roleManager = customRoleManager;
                _dsRepo = dsRepo;
            }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
           var news = _context.News.Find(id);
           news.UserName = _context.AppUsers.Find(news.UserId).FullName;
           news.Status = news.Status == "Y" ? "開啟" : "關閉";
           return View(news);
        }
    }
}
