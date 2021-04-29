using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Models.Identity;
using EDIS.Areas.BMED.Repositories;
using EDIS.Repositories;
using EDIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using System.IO;
using EDIS.Models;
using Zen.Barcode;
using X.PagedList;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using EDIS.Areas.WebService.Models;
using WebService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace EDIS.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IRepository<DepartmentModel, string> _dptRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private readonly IRepository<DocIdStore, string[]> _dsRepo;
        private int pageSize = 50;

        public NewsController(  ApplicationDbContext context,
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


        public IActionResult Index()
        {
            //院區選擇
            List<SelectListItem> LoclistItem = new List<SelectListItem>();

            LoclistItem.Add(new SelectListItem { Text = "總院", Value = "總院" });
            LoclistItem.Add(new SelectListItem { Text = "二林", Value = "L" });
            LoclistItem.Add(new SelectListItem { Text = "員林", Value = "B" });
            LoclistItem.Add(new SelectListItem { Text = "南投", Value = "N" });
            LoclistItem.Add(new SelectListItem { Text = "鹿基", Value = "U" });
            LoclistItem.Add(new SelectListItem { Text = "雲基", Value = "T" });
            ViewData["NewsLoc"] = new SelectList(LoclistItem, "Value", "Text");

            return View();
        }
        [AllowAnonymous]
        public IActionResult Index2()
        {
            //院區選擇
            List<SelectListItem> LoclistItem = new List<SelectListItem>();

            LoclistItem.Add(new SelectListItem { Text = "總院", Value = "總院" });
            LoclistItem.Add(new SelectListItem { Text = "二林", Value = "L" });
            LoclistItem.Add(new SelectListItem { Text = "員林", Value = "B" });
            LoclistItem.Add(new SelectListItem { Text = "南投", Value = "N" });
            LoclistItem.Add(new SelectListItem { Text = "鹿基", Value = "U" });
            LoclistItem.Add(new SelectListItem { Text = "雲基", Value = "T" });
            ViewData["NewsLoc"] = new SelectList(LoclistItem, "Value", "Text");

            return View();
        }

        [AllowAnonymous]
        public IActionResult QryList2(NewsViewModel qdata , int page = 1)
        {
            //var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            //var role = roleManager.GetRolesForUser(ur.Id);

            var Id = qdata.NewsId;
            var Loc = qdata.Loc;
            var Sdate = qdata.Sdate;
            var Edate = qdata.Edate;

            
            List<NewsViewModel> newslist = new List<NewsViewModel>();
            var users = _context.AppUsers.AsQueryable();

            if (users.FirstOrDefault() == null)
            {
                return PartialView("QryList", newslist.ToPagedList(page, pageSize));
            }

            if (!string.IsNullOrEmpty(Loc))
            {
                if (Loc == "總院") { 
                     string[] s = {"K","P","C"};
                     users = users.Join(_context.Departments.Where(d => s.Contains(d.Loc)),
                                   u => u.DptId,
                                   d => d.DptId,
                                   (u, d) => u);
                }

                else { 
                    users = users.Join(_context.Departments.Where(d => d.Loc == Loc),
                                    u => u.DptId,
                                    d => d.DptId,
                                    (u, d) => u);
                }
            }

            //_context.News.Where(ns => ns.UserId == ur.Id)
            //    .Join(_context.AppUsers, n => n.UserId, u => u.Id,
            //(n, u) => new
            //{
            //    news = n,
            //    user = u
            //})
            //.ToList()
            //.ForEach(n =>
            //    newslist.Add(new NewsViewModel
            //    {

            //        NewsId = n.news.NewsId,
            //        NewsTitle = n.news.NewsTitle,
            //        NewsContent = n.news.NewsContent,
            //        UserId = n.news.UserId,
            //        UserName = n.user.FullName,
            //        Sdate = n.news.Sdate,
            //        Edate = n.news.Edate,
            //        Status = n.news.Status,
            //        RTT = n.news.RTT
            //    })
            //);

            //if (role.Contains("MedMgr") || role.Contains("MedAssetMgr") || role.Contains("Admin") )
            //{
            //    _context.News.Where(ns => ns.UserId != ur.Id)
            //   .Join(users, n => n.UserId, u => u.Id,
            //   (n, u) => new
            //   {
            //       news = n,
            //       FullName = u.FullName
            //   })
            //   .ToList()
            //   .ForEach(n =>
            //       newslist.Add(new NewsViewModel
            //       {
            //           NewsId = n.news.NewsId,
            //           NewsTitle = n.news.NewsTitle,
            //           NewsContent = n.news.NewsContent,
            //           UserId = n.news.UserId,
            //           UserName = n.FullName,
            //           Sdate = n.news.Sdate,
            //           Edate = n.news.Edate,
            //           Status = n.news.Status,
            //           RTT = n.news.RTT
            //       })
            //   );
            //}

            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                newslist = newslist.Where(n => n.NewsId == Convert.ToInt32(Id)).ToList();
            }
            if (Sdate == null)
            {
                if(Edate != null) { 
                    newslist = newslist.Where(n => n.Edate <= Edate).ToList();
                }
            }
            else
            {
                if (Edate == null)
                {
                    newslist = newslist.Where(n => n.Sdate >= Sdate).ToList();
                }
                else
                {
                    newslist = newslist.Where(n => n.Sdate >= Sdate && n.Edate <= Edate).ToList();
                }
            }


            //
            var pageCount = newslist.ToPagedList(page, pageSize).PageCount;
            pageCount = pageCount == 0 ? 1 : pageCount; // If no page.

            if (newslist.ToPagedList(page, pageSize).Count <= 0)//If the page has no items.
                return PartialView("QryList", newslist.ToPagedList(pageCount, pageSize));
            return PartialView("QryList", newslist.ToPagedList(page, pageSize));

            //return newslist;
        }

        public IActionResult QryList(NewsViewModel qdata, int page = 1)
        {
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            var role = roleManager.GetRolesForUser(ur.Id);

            var Id = qdata.NewsId;
            var Loc = qdata.Loc;
            var Sdate = qdata.Sdate;
            var Edate = qdata.Edate;


            List<NewsViewModel> newslist = new List<NewsViewModel>();
            var users = _context.AppUsers.AsQueryable();

            if (users.FirstOrDefault() == null)
            {
                return PartialView("QryList", newslist.ToPagedList(page, pageSize));
            }

            if (!string.IsNullOrEmpty(Loc))
            {
                if (Loc == "總院")
                {
                    string[] s = { "K", "P", "C" };
                    users = users.Join(_context.Departments.Where(d => s.Contains(d.Loc)),
                                  u => u.DptId,
                                  d => d.DptId,
                                  (u, d) => u);
                }

                else
                {
                    users = users.Join(_context.Departments.Where(d => d.Loc == Loc),
                                    u => u.DptId,
                                    d => d.DptId,
                                    (u, d) => u);
                }
            }

            _context.News.Where(ns => ns.UserId == ur.Id)
                .Join(_context.AppUsers, n => n.UserId, u => u.Id,
            (n, u) => new
            {
                news = n,
                user = u
            })
            .ToList()
            .ForEach(n =>
                newslist.Add(new NewsViewModel
                {

                    NewsId = n.news.NewsId,
                    NewsTitle = n.news.NewsTitle,
                    NewsContent = n.news.NewsContent,
                    UserId = n.news.UserId,
                    UserName = n.user.FullName,
                    Sdate = n.news.Sdate,
                    Edate = n.news.Edate,
                    Status = n.news.Status,
                    RTT = n.news.RTT
                })
            );

            if (role.Contains("MedMgr") || role.Contains("MedAssetMgr") || role.Contains("Admin"))
            {
                _context.News.Where(ns => ns.UserId != ur.Id)
               .Join(users, n => n.UserId, u => u.Id,
               (n, u) => new
               {
                   news = n,
                   FullName = u.FullName
               })
               .ToList()
               .ForEach(n =>
                   newslist.Add(new NewsViewModel
                   {
                       NewsId = n.news.NewsId,
                       NewsTitle = n.news.NewsTitle,
                       NewsContent = n.news.NewsContent,
                       UserId = n.news.UserId,
                       UserName = n.FullName,
                       Sdate = n.news.Sdate,
                       Edate = n.news.Edate,
                       Status = n.news.Status,
                       RTT = n.news.RTT
                   })
               );
            }

            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                newslist = newslist.Where(n => n.NewsId == Convert.ToInt32(Id)).ToList();
            }
            if (Sdate == null)
            {
                if (Edate != null)
                {
                    newslist = newslist.Where(n => n.Edate <= Edate).ToList();
                }
            }
            else
            {
                if (Edate == null)
                {
                    newslist = newslist.Where(n => n.Sdate >= Sdate).ToList();
                }
                else
                {
                    newslist = newslist.Where(n => n.Sdate >= Sdate && n.Edate <= Edate).ToList();
                }
            }


            //
            var pageCount = newslist.ToPagedList(page, pageSize).PageCount;
            pageCount = pageCount == 0 ? 1 : pageCount; // If no page.

            if (newslist.ToPagedList(page, pageSize).Count <= 0)//If the page has no items.
                return PartialView("QryList", newslist.ToPagedList(pageCount, pageSize));
            return PartialView("QryList", newslist.ToPagedList(page, pageSize));

            //return newslist;
        }

        // GET:
        public ActionResult Create()
        {
            News news = new News();
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            news.UserId = ur.Id;
            news.UserName = ur.FullName;
            return View(news);
        }

        // GET:
        [AllowAnonymous]
        public ActionResult New(string username)
        {
            News news = new News();
            AppUserModel ur;
            if (!string.IsNullOrEmpty(username))
            {
                ur = _userRepo.Find(u => u.UserName == username).FirstOrDefault();
                if (ur == null)
                {
                    ur = _userRepo.Find(u => u.UserName == "47110").FirstOrDefault();
                }
            }
            else { 
                 ur = _userRepo.Find(u => u.UserName == "47110").FirstOrDefault();
            }
            news.UserId = ur.Id;
            news.UserName = ur.FullName;
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                if (news.Sdate >= news.Edate)
                {
                    return BadRequest("起始日期不可大於等於終止日期");
                    //return new JsonResult(news)
                    //{
                    //    Value = new { success = false, error = "起始日期不可大於等於終止日期" }
                    //};
                }

                news.RTT = DateTime.Now;
                _context.News.Add(news);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET
        public ActionResult Edit(int id)
        {
            var news = _context.News.Find(id);
            news.UserName = _context.AppUsers.Find(news.UserId).FullName;
            return View(news);
        }

        [HttpPost]
        // POST
        public ActionResult Update(News news)
        {
            if (ModelState.IsValid)
            {
                news.RTT = DateTime.Now;
                _context.Entry(news).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("Update", news);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("此序號查無消息!");
            }
            News news = _context.News.Find(id);
            if (news == null)
            {
                return BadRequest("此序號查無消息!");
            }
            news.UserName = _context.AppUsers.Find(news.UserId).FullName;
            news.Status = news.Status == "Y" ? "開啟" : "關閉";
            return View(news);
        }

        public ActionResult UnDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest("此序號查無消息!");
            }
            News news = _context.News.Find(id);
            if (news == null)
            {
                return BadRequest("此序號查無消息!");
            }
            news.UserName = _context.AppUsers.Find(news.UserId).FullName;
            news.Status = news.Status == "Y" ? "開啟" : "關閉";
            return View(news);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("此序號查無消息!");
            }
            News news = _context.News.Find(id);
            if (news == null)
            {
                return BadRequest("此序號查無消息!");
            }
            news.UserName = _context.AppUsers.Find(news.UserId).FullName;
            news.Status = news.Status == "Y" ? "開啟" : "關閉";
            return View(news);
        }

        // POST: MedEngMgt/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = _context.News.Find(id);
            _context.News.Remove(news);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowWarnings()
        {
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
                    NewsTitle = n.news.NewsTitle,
                    NewsContent = n.news.NewsContent,
                    UserName = n.user.FullName,
                    Sdate = n.news.Sdate,
                    Edate = n.news.Edate
                })
            );

            return PartialView(newslist);
        }


        public string GetID()
        {
            string s = _context.News.Select(r => r.NewsId).Max().ToString();
            string did = "";
            int yymm = (System.DateTime.Now.Year - 1911) * 100 + System.DateTime.Now.Month;
            if (!string.IsNullOrEmpty(s))
            {
                did = s;
            }
            if (did != "")
            {
                if (Convert.ToInt64(did) / 100000 == yymm)
                    did = Convert.ToString(Convert.ToInt64(did) + 1);
                else
                    did = Convert.ToString(yymm * 100000 + 1);
            }
            else
            {
                did = Convert.ToString(yymm * 100000 + 1);
            }

            if (string.IsNullOrEmpty(did))
            {
                did = "0";
            }
            return did;
        }

        public string GetID2()
        {
            string did = "";
            try
            {
                DocIdStore ds = new DocIdStore();
                ds.DocType = "最新消息";
                string s = _dsRepo.Find(x => x.DocType == "最新消息").Select(x => x.DocId).Max();
                int yymmdd = (System.DateTime.Now.Year - 1911) * 10000 + (System.DateTime.Now.Month) * 100 + System.DateTime.Now.Day;
                if (!string.IsNullOrEmpty(s))
                {
                    did = s;
                }
                if (did != "")
                {
                    if (Convert.ToInt64(did) / 1000 == yymmdd)
                        did = Convert.ToString(Convert.ToInt64(did) + 1);
                    else
                        did = Convert.ToString(yymmdd * 1000 + 1);
                    ds.DocId = did;
                    _dsRepo.Update(ds);
                }
                else
                {
                    did = Convert.ToString(yymmdd * 1000 + 1);
                    ds.DocId = did;
                    // 二次確認資料庫內沒該資料才新增。
                    var dataIsExist = _dsRepo.Find(x => x.DocType == "最新消息");
                    if (dataIsExist.Count() == 0)
                    {
                        _dsRepo.Create(ds);
                    }
                }
            }
            catch (Exception e)
            {
                RedirectToAction("Create", "News", new { Area = "" });
            }
            return did;
        }

        public ActionResult ShowAllNews()
        {
            // Get current user.
            //var user = _userRepo.Find(u => u.UserName == User.Identity.Name).FirstOrDefault();

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