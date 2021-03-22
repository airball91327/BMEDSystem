using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Components.News
{
    public class NewsShowViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IRepository<DepartmentModel, string> _dptRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private readonly IRepository<DocIdStore, string[]> _dsRepo;
        private int pageSize = 50;

        public NewsShowViewComponent(ApplicationDbContext context,
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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Get current user.
            var user = _userRepo.Find(u => u.UserName == User.Identity.Name).FirstOrDefault();

            List<NewsViewModel> newslist = new List<NewsViewModel>();
            DateTime dt = DateTime.Now;
            _context.News.Where(n => n.Status == "Y")
                .Where(n => n.Sdate <= dt && n.Edate >= dt)
                .Join(_context.AppUsers, n => n.UserId, u => u.Id,
            (n, u) => new
            {
                news = n,
                user = u
            }).ToList()
            .ForEach(n =>
                newslist.Add(new NewsViewModel
                {
                    NewsId = n.news.NewsId,
                    NewsTitle = n.news.NewsTitle,
                    NewsContent = n.news.NewsContent,
                    UserName = n.user.FullName,
                    Sdate = n.news.Sdate,
                    Edate = n.news.Edate
                })
            );

            return View(newslist);
        }

    }
}
