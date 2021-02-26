using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EDIS.Controllers
{
    [Authorize]
    public class FindInKeyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _BMEDcontext;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IRepository<DepartmentModel, string> _dptRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private int pageSize = 100;

        public FindInKeyController(ApplicationDbContext context,
                                 ApplicationDbContext BMEDcontext,
                                 IRepository<AppUserModel, int> userRepo,
                                 IRepository<DepartmentModel, string> dptRepo,
                                 CustomUserManager customUserManager,
                                 CustomRoleManager customRoleManager)
        {
            _context = context;
            _BMEDcontext = BMEDcontext;
            _userRepo = userRepo;
            _dptRepo = dptRepo;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult QueryAssets(string key)
        {
            //參數key為使用者輸入在input的資訊
            var departments = _context.Departments
                .Where(s => s.DptId.Contains(key)); //拿取前五筆資料配對的資料

            if(departments == null)
            {
                departments = _context.Departments
                .Where(s => s.Name_C.Contains(key)); //拿取前五筆資料配對的資料
            }

            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (var item in departments.OrderBy(d => d.Name_C))
            {
                listItem.Add(new SelectListItem
                {
                    Text = item.Name_C + "(" + item.DptId + ")",    //show DptName(DptId)
                    Value = item.DptId
                });
            }
            
            return Json(listItem);
        }

        [HttpGet]
        public ActionResult QueryEngCode(string key)
        {
            /* 處理工程師查詢的下拉選單 */
            var engs = roleManager.GetUsersInRole("MedEngineer").ToList();
            var ur = _context.AppUsers
                    .Join(engs,
                          u => u.UserName,
                          l => l,
                          (u, l) => u);
            //參數key為使用者輸入在input的資訊
            var urs = ur
                .Where(s => s.UserName.Contains(key)); //拿取前五筆資料配對的資料

            if (urs == null)
            {
                urs = ur
                .Where(s => s.FullName.Contains(key)); //拿取前五筆資料配對的資料
            }

            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (var item in urs.OrderBy(u => u.FullName))
            {
                listItem.Add(new SelectListItem
                {
                    Text = item.FullName + "(" + item.UserName + ")",    //show DptName(DptId)
                    Value = item.Id.ToString()
                });
            }

            return Json(listItem);
        }

        [HttpGet]
        public ActionResult QueryClsUser(string key)
        {
            // Get current user.
            var user = _userRepo.Find(u => u.UserName == User.Identity.Name).FirstOrDefault();
            List<SelectListItem> listItem = new List<SelectListItem>();

            if (user.DptId == "7084" || user.DptId == "8420") { 
                /* 處理工程師查詢的下拉選單 */
                var engs = roleManager.GetUsersInRole("MedEngineer").ToList();
                var ur = _context.AppUsers
                        .Join(engs,
                              u => u.UserName,
                              l => l,
                              (u, l) => u);
                //參數key為使用者輸入在input的資訊
                var urs = ur
                    .Where(s => s.UserName.Contains(key)); 

                if (urs == null)
                {
                    urs = ur
                    .Where(s => s.FullName.Contains(key));
                }

                foreach (var item in urs.OrderBy(u => u.FullName))
                {
                    listItem.Add(new SelectListItem
                    {
                        Text = item.FullName + "(" + item.UserName + ")",    //show DptName(DptId)
                        Value = item.Id.ToString()
                    });
                }
            }
            else
            {
                /* 擷取該使用者單位底下所有人員 */
                var dptUsers = _context.AppUsers
                                .Where(a => a.DptId == user.DptId && a.Status == "Y");

                //參數key為使用者輸入在input的資訊
                dptUsers = dptUsers
                            .Where(s => s.UserName.Contains(key));

                if (dptUsers == null)
                {
                    dptUsers = dptUsers
                            .Where(s => s.FullName.Contains(key));
                }

                foreach (var item in dptUsers.OrderBy(u => u.FullName))
                {
                    listItem.Add(new SelectListItem
                    {
                        Text = item.FullName + "(" + item.UserName + ")",    //show DptName(DptId)
                        Value = item.Id.ToString()
                    });
                }
            }

            return Json(listItem);
        }
    }
}