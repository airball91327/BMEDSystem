﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EDIS.Models;
using Microsoft.AspNetCore.Authorization;
using EDIS.Models;
using EDIS.Repositories;
using EDIS.Models.Identity;
using System.Text.RegularExpressions;
using EDIS.Areas.FORMS.Data;

namespace EDIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BMEDDBContext _db;
        private readonly ApplicationDbContext _BMEDcontext;
        private readonly IRepository<RepairModel, string> _repRepo;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;

        public HomeController(ApplicationDbContext context,
                              BMEDDBContext db,
                              ApplicationDbContext BMEDcontext,
                              IRepository<RepairModel, string> repairRepo,
                              IRepository<AppUserModel, int> userRepo,
                              CustomUserManager customUserManager)
        {
            _context = context;
            _db = db;
            _BMEDcontext = BMEDcontext;
            _repRepo = repairRepo;
            _userRepo = userRepo;
            userManager = customUserManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            /* Get user details. */
            
            
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            var urLocation = new DepartmentModel(_BMEDcontext).GetUserLocation(ur);
            //
            var rps = _context.BMEDRepairs.Where(r => r.Loc == urLocation);
            var kps = _context.BMEDKeeps.Where(r => r.Loc == urLocation);
            /* 所有尚未指派工程師的案件 */
            var rfs = _context.BMEDRepairFlows.Where(r => r.Status == "?" && r.Cls.Contains("工程師"))
                                              .Where(r => r.UserId == 0);

            if (userManager.IsInRole(User, "MedAssetMgr")) //賀康主管不做院區篩選
            {
                rps = _context.BMEDRepairs;
                kps = _context.BMEDKeeps;
            }
            //請修案件數
            var BMEDrepairCount = rps.Join(_BMEDcontext.BMEDRepairFlows.Where(f => f.Status == "?" && f.UserId == ur.Id), r => r.DocId, rf => rf.DocId,
                                              (r, rf) => new 
                                              { 
                                                  repair = r,
                                                  repairflow = rf
                                              }).Count();
            //保養案件數
            var BMEDkeepCount = kps.Join(_BMEDcontext.BMEDKeepFlows.Where(f => f.Status == "?" && f.UserId == ur.Id), k => k.DocId, kf => kf.DocId,
                                              (k, kf) => new
                                              {
                                                  keep = k,
                                                  keepflow = kf
                                              }).Count();
            //驗收案件數
            var BMEDdeliveryCount = _BMEDcontext.DelivFlows.Where(f => f.Status == "?")
                                                           .Where(f => f.UserId == ur.Id).Count();
            //採購評估案件數
            var BMEDbuyCount = _BMEDcontext.BuyFlows.Where(f => f.Status == "?")
                                                    .Where(f => f.UserId == ur.Id).Count();

            //外部醫療儀器使用申請案件數
            var FORMSoutsidebmedCount = _db.OutsideBmedFlows.Where(f => f.Status == "?")
                                                    .Where(f => f.UserId == ur.Id).Count();
            //未分派案件
            var BMEDRepResignCount = _context.BMEDRepairs.Where(r => r.EngId == 0)
                .Join(rfs, r => r.DocId, rf => rf.DocId,
                (r, rf) => new
                {
                    repair = r,
                    flow = rf
                })
                .Join(_context.BMEDRepairDtls, r => r.repair.DocId, d => d.DocId,
                (r, d) => new
                {
                    repair = r.repair,
                    flow = r.flow,
                    repdtl = d
                })
                .Join(_context.Departments, j => j.repair.AccDpt, d => d.DptId,
                (j, d) => new
                {
                    repair = j.repair,
                    flow = j.flow,
                    repdtl = j.repdtl,
                    dpt = d
                })
                .Where(item => item.repair.Loc == urLocation)
                .Count();



            UnsignCounts v = new UnsignCounts();
            v.RepairCount = BMEDrepairCount;
            v.KeepCount = BMEDkeepCount;
            v.DeliveryCount = BMEDdeliveryCount;
            v.BuyEvalateCount = BMEDbuyCount;
            v.OutsideBmedCount = FORMSoutsidebmedCount;
            v.RepResignCount = BMEDRepResignCount;

            //if (fBrowserIsMobile())
            //{
            //    if (userManager.IsInRole(User, "RepEngineer") == true &&
            //        userManager.IsInRole(User, "RepMgr") == false)
            //    {
            //        // go to mobile pages
            //        return RedirectToAction("Index", "Repair", new { Area = "Mobile" });
            //    }
            //}

            return View(v);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /* Mobile Detect Function. */
        public bool fBrowserIsMobile()
        {
            Regex MobileCheck = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
            Regex MobileVersionCheck = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);

            Debug.Assert(HttpContext != null);
            var a = HttpContext.Request.Headers["User-Agent"].ToString();
            if (HttpContext.Request != null && HttpContext.Request.Headers["User-Agent"].FirstOrDefault() != null)
            {
                var u = HttpContext.Request.Headers["User-Agent"].FirstOrDefault().ToString();

                if (u.Length < 4)
                    return false;

                if (MobileCheck.IsMatch(u) || MobileVersionCheck.IsMatch(u.Substring(0, 4)))
                    return true;
            }
            return false;
        }
    }
}
