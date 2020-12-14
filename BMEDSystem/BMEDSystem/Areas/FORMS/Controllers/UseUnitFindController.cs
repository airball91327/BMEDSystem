using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Areas.FORMS.Data;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EDIS.Areas.FORMS.Controllers
{
    [Area("FORMS")]
    [Authorize]

    public class UseUnitFindController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BMEDDBContext _db;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;

        public UseUnitFindController(ApplicationDbContext context,
                                    BMEDDBContext db,
                                    IRepository<AppUserModel, int> userRepo,
                                    IHostingEnvironment hostingEnvironment,
                                    CustomUserManager customUserManager,
                                    CustomRoleManager customRoleManager
            )
        {
            _context = context;
            _db = db;
            _userRepo = userRepo;
            _hostingEnvironment = hostingEnvironment;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //搜尋部門
        public JsonResult GetRoleByKeyname(string keyname)
        {
            List<DepartmentModel> uls = new List<DepartmentModel>();
            List<SelectListItem> list = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(keyname)) {
                //關鍵字
                _context.Departments.Where(c => c.Name_C.Contains(keyname))
                .ToList()
                .ForEach(ul => list.Add(
                  new SelectListItem { Text = "("+ ul.DptId + ")"+ ul.Name_C, Value = ul.DptId }
                ));
                //部門代號
                _context.Departments.Where(c => c.DptId.Contains(keyname))
                .ToList()
                .ForEach(ul => list.Add(
                  new SelectListItem { Text = "(" + ul.DptId + ")" + ul.Name_C, Value = ul.DptId }
                ));
            }
            return Json(list);
        }

        //搜尋人員
        public JsonResult GetToNameByKeyname(string keyname)
        {
            List<AppUserModel> uls = new List<AppUserModel>();
            List<SelectListItem> list = new List<SelectListItem>();
            
            if (!string.IsNullOrEmpty(keyname))   
            {
                //關鍵字
                _context.AppUsers.Where(c => c.FullName.Contains(keyname))
                    .ToList()
                    .ForEach(ul => list.Add(
                                new SelectListItem { Text = "(" + ul.UserName + ")" + ul.FullName, Value = ul.Id.ToString() }
                            ));
                //代號
                _context.AppUsers.Where(c => c.UserName.Contains(keyname))
                    .ToList()
                    .ForEach(ul => list.Add(
                                new SelectListItem { Text = "(" + ul.UserName + ")" + ul.FullName, Value = ul.Id.ToString() }
                            ));
            }
            
            return Json(list);
        }
       
        public JsonResult GetToClsByKeyname(string keyname,string docid,string tle)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            //申請人
            var cls = _db.OutsideBmedFlows.Where(f => f.DocId == docid && f.Cls == "申請者").FirstOrDefault();

            //申請人資訊
            var clsuser = _context.AppUsers.Where(u => u.Id == cls.UserId).FirstOrDefault();

            //string[] FullName = null;
            if (!string.IsNullOrEmpty(keyname) && !string.IsNullOrEmpty(docid))
            {
                switch (keyname)
                {
                    case "醫工部主管":
                        var FullName = roleManager.GetUsersInRole("MedMgr");
                        if (FullName != null)
                        {
                            for (int i = 0; i < FullName.Count(); i++)
                            {
                                var ur = _context.AppUsers.Where(u => u.UserName == FullName[i]).FirstOrDefault();
                                list.Add(
                                 new SelectListItem { Text = "("+ur.UserName+")"+ur.FullName, Value = ur.FullName });
                            }
                        }
                        break;
                    case "申請者":
                        list.Add(new SelectListItem { Text = "(" + clsuser.UserName + ")" + clsuser.FullName, Value = clsuser.FullName });
                        break;
                    case "單位主管":
                        if (!string.IsNullOrEmpty(tle))
                        {
                            var us = _context.AppUsers.Where(ur => ur.UserName.Contains(tle)).ToList();
                            if (us.Count() <= 0)
                            {
                                us = _context.AppUsers.Where(ur => ur.FullName.Contains(tle)).ToList();
                            }
                             us.ForEach(ul => list.Add(
                                 new SelectListItem { Text = "(" + ul.UserName + ")" + ul.FullName, Value = ul.FullName }
                             ));
                        }
                        break;
                    case "醫工承辦":
                        list.Add(new SelectListItem { Text = "(344024)施曉婷", Value = "施曉婷" });
                        break;
                    case "醫工工程師":
                        if (!string.IsNullOrEmpty(tle))
                        {
                            var us = _context.AppUsers.Where(ur => ur.UserName.Contains(tle)).ToList();
                            if (us.Count() <= 0)
                            {
                                us = _context.AppUsers.Where(ur => ur.FullName.Contains(tle)).ToList();
                            }
                            us.ForEach(ul => list.Add(
                                new SelectListItem { Text = "(" + ul.UserName + ")" + ul.FullName, Value = ul.FullName }
                            ));
                        }
                        break;
                };

            }
            return Json(list);
        }

        public JsonResult GetBepartmentByKeyname(string keyname)
        {
            List<DepartmentModel> uls = new List<DepartmentModel>();
            List<SelectListItem> list = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(keyname))
            {
                //關鍵字
                    _context.Departments.Where(c => c.Name_C.Contains(keyname))
                    .ToList()
                    .ForEach(ul => list.Add(
                      new SelectListItem { Text = ul.Name_C, Value = ul.DptId }
                    ));
                //部門代號
                    _context.Departments.Where(c => c.DptId == keyname)
                    .ToList()
                    .ForEach(ul => list.Add(
                      new SelectListItem { Text = ul.Name_C, Value = ul.DptId }
                    ));
            }
            
            return Json(list);
        }
    }
}