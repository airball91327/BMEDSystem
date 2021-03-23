using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using EDIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]

    public class QuestionnaireMsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IRepository<DepartmentModel, string> _dptRepo;
        private readonly IRepository<DocIdStore, string[]> _dsRepo;
        private readonly IEmailSender _emailSender;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private int pageSize = 50;
        private readonly IHostingEnvironment _hostingEnvironment;

        public QuestionnaireMsController(ApplicationDbContext context,
                              IRepository<AppUserModel, int> userRepo,
                              IRepository<DepartmentModel, string> dptRepo,
                              IRepository<DocIdStore, string[]> dsRepo,
                              IEmailSender emailSender,
                              IHostingEnvironment hostingEnvironment,
                              CustomUserManager customUserManager,
                              CustomRoleManager customRoleManager)
        {
            _context = context;
            _userRepo = userRepo;
            _dptRepo = dptRepo;
            _dsRepo = dsRepo;
            _emailSender = emailSender;
            _hostingEnvironment = hostingEnvironment;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }

 
        public IActionResult Index()
        {
            var lst = _context.QuestionnaireMs.ToList();
            if (lst != null) { 
                lst.ForEach(q =>
                {
                    q.RtpName = _context.AppUsers.Find(q.Rtp).FullName;
                });
            }

            return View(lst);
        }

        // GET: 
        public IActionResult Create()
        {
            AppUserModel ur = _context.AppUsers.Where(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            if (userManager.IsInRole(User, "Admin") || userManager.IsInRole(User, "MedMgr")
                 || userManager.IsInRole(User, "MedAssetMgr"))
            {
                QuestionnaireM que = new QuestionnaireM();
                que.Rtp = ur.Id;
                que.RtpName = ur.FullName;
                return View(que);
            }
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult Create(QuestionnaireM questionnaireM)
        {
            string msg = "";
            try { 
                if (ModelState.IsValid)
                {
                    questionnaireM.Rtt = DateTime.Now;
                    _context.QuestionnaireMs.Add(questionnaireM);
                    _context.SaveChanges();

                    return View(questionnaireM);
                }

                else
                {
                    msg = "";
                    foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                    {
                        msg += error.ErrorMessage + Environment.NewLine;
                    }
                    throw new Exception(msg);
                }
            }
        
            catch(Exception ex)
            {
                msg = ex.Message;
            }

            return BadRequest(msg);
        }

        // GET: MedEngMgt/QuestionnaireMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(404);
            }
            AppUserModel ur = _context.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            QuestionnaireM questionnaireM = _context.QuestionnaireMs.Find(id);
            questionnaireM.Rtp = ur.Id;
            questionnaireM.RtpName = ur.FullName;

            if (questionnaireM == null)
            {
                return StatusCode(404);
            }
            return View(questionnaireM);
        }

         [HttpPost]
        public ActionResult Update( QuestionnaireM questionnaireM)
        {
            if (ModelState.IsValid)
            {
                questionnaireM.Rtt = DateTime.Now;
                _context.Entry(questionnaireM).State = EntityState.Modified;
                _context.SaveChanges();
                return new JsonResult(questionnaireM)
                {
                    Value = new { success = true, error = "" }
                };
            }
            return BadRequest("案件有誤!");
        }

    }
}