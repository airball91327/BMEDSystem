
using EDIS.Areas.FORMS.Data;
using EDIS.Areas.FORMS.Models;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;


namespace EDIS.Areas.BMED.Controllers
{
    [Area("FORMS")]
    [Authorize]
    public class OutsideBmedFlowsController : Controller
    {
        private readonly BMEDDBContext _db;
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;

        public OutsideBmedFlowsController(BMEDDBContext db,
                                    ApplicationDbContext context,
                                    IRepository<AppUserModel, int> userRepo,
                                    IHostingEnvironment hostingEnvironment,
                                    CustomUserManager customUserManager,
                                    CustomRoleManager customRoleManager)
        {
            _db = db;
            _context = context;
            _userRepo = userRepo;
            _hostingEnvironment = hostingEnvironment;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }

        // GET: OutsideBmedFlow
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(string id)
        {
            List<OutsideBmedFlow> of = _db.OutsideBmedFlows.Where(f => f.DocId == id).ToList();
            return PartialView(of);
        }

        

        [HttpPost]
        public ActionResult NextFlow(Assign assign)
        {
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            if (assign.FlowCls == "結案" || assign.FlowCls == "廢除")
                assign.FlowUid = ur.Id;
            else
                assign.FlowUid = _context.AppUsers.Where(u => u.FullName == assign.ClsNow).Select(u => u.Id).FirstOrDefault();
            Instrument instrument = _db.Instruments.Find(assign.DocId);

            


            if (ModelState.IsValid)
            {
                OutsideBmedFlow of = _db.OutsideBmedFlows.Where(f => f.DocId == assign.DocId && f.Status == "?").FirstOrDefault();
               
                if (assign.FlowCls == "結案")
                {
                    of.Opinion = "[" + assign.AssignCls + "]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "2";
                    of.Rtt = DateTime.Now;
                    of.Rtp = assign.FlowUid;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;

                    _db.Entry(of).State = EntityState.Modified;
                    _db.SaveChanges();                 
                }
                else if (assign.FlowCls == "廢除")
                {
                    of.Opinion = "[廢除]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "3";
                    of.Rtt = DateTime.Now;
                    of.Rtp = assign.FlowUid;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;
                    _db.Entry(of).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    //轉送下一關卡
                    of.Opinion = "[" + assign.AssignCls + "]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "1";
                    of.Rtt = DateTime.Now;
                    of.Rtp = ur.Id;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;
                    _db.Entry(of).State = EntityState.Modified;
                    _db.SaveChanges();
                    //
                    OutsideBmedFlow flow = new OutsideBmedFlow();
                    flow.DocId = assign.DocId;
                    flow.StepId = of.StepId + 1;
                    flow.UserId = assign.FlowUid.Value;
                    flow.UserName = _db.AppUsers.Find(assign.FlowUid.Value).FullName;
                    flow.Status = "?";
                    flow.Cls = assign.FlowCls;
                    flow.Rtt = DateTime.Now;
                    flow.item1 = assign.item1;
                    flow.item2 = assign.item2;
                    flow.item3 = assign.item3;
                    flow.item4 = assign.item4;
                    flow.item5 = assign.item5;
                    flow.item6 = assign.item6;
                    flow.item7 = assign.item7;
                    _db.OutsideBmedFlows.Add(flow);
                    _db.SaveChanges();
                    //Send Mail
                    //To user and the next flow user.
                    Tmail mail = new Tmail();
                    string body = "";
                    AppUserModel u;
                    //RepairModel repair = _context.BMEDRepairs.Find(assign.DocId);
                    mail.from = new System.Net.Mail.MailAddress(ur.Email); //ur.Email
                    u = _context.AppUsers.Find(flow.UserId);
                    mail.to = new System.Net.Mail.MailAddress(u.Email); //u.Email
                                                                        //mail.cc = new System.Net.Mail.MailAddress("99242@cch.org.tw");
                    mail.message.Subject = "醫工智能保修系統[外部醫療使用申請] : 品名 : " + instrument.Name;
                    body += "<p>表單編號：" + instrument.DocId + "</p>";
                    body += "<p>申請日期：" + instrument.ApplyDate.ToString("yyyy/MM/dd") + "</p>";
                    body += "<p>申請人：" + instrument.UserName + "</p>";
                    body += "<p>品名：" + instrument.Name + "</p>";
                    body += "<p><a href='http://dms.cch.org.tw/BMED/Account/Login'" + "?docId=" + instrument.DocId + "&dealType=BMEDRepEdit" + ">處理案件</a></p>";
                    body += "<br/>";
                    body += "<h3>此封信件為系統通知郵件，請勿回覆。</h3>";
                    body += "<br/>";
                    //body += "<h3 style='color:red'>如有任何疑問請聯絡工務部，分機3033或7033。<h3>";
                    mail.message.Body = body;
                    mail.message.IsBodyHtml = true;
                    mail.SendMail();

                }
                return new JsonResult(assign)
                {
                    Value = new { success = true, error = "" }
                };
            }
            else
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
           
        }

       //工程師審核
        [HttpPost]
        public ActionResult NextSFlow(Assign assign)
        {
            //目前使用者資料
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            //AppUser appUser = db.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (assign.FlowCls == "結案" || assign.FlowCls == "廢除")
                assign.FlowUid = ur.Id;
            else
                assign.FlowUid = _context.AppUsers.Where(f => f.FullName == assign.ClsNow).Select(f => f.Id).FirstOrDefault();
            Instrument instrument = _db.Instruments.Find(assign.DocId);

            //審核內容初始化
            if (instrument.Application != "患者自帶")
            {
                assign.item4 = false;
                assign.item5 = false;
                assign.item6 = false;
                assign.item7 = false;
            }
            else
            {
                assign.item1 = false;
                assign.item2 = false;
                assign.item3 = false;
            }
            if (ModelState.IsValid)
            {
                //必須審核皆完成
                if (instrument.Application != "患者自帶")
                {
                    if (assign.item1 == false ||
                        assign.item2 == false ||
                        assign.item3 == false)
                    {
                        return BadRequest("必須全符合規定,才可轉送下一關");
                    }
                }
                else
                {
                    if (
                       (assign.item4 == false ||
                        assign.item5 == false ||
                        assign.item6 == false) &&
                        assign.item7 == false
                        )
                    {
                        return BadRequest("必須前三項審核通過,否則勾選最後一項,送回申請者");
                    }
                }

                OutsideBmedFlow of = _db.OutsideBmedFlows.Where(f => f.DocId == assign.DocId && f.Status == "?").FirstOrDefault();
                if (assign.FlowCls == "結案")
                {
                    of.Opinion = "[" + assign.AssignCls + "]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "2";
                    of.Rtt = DateTime.Now;
                    of.Rtp = ur.Id;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;

                    _db.Entry(of).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                else if (assign.FlowCls == "廢除")
                {
                    of.Opinion = "[廢除]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "3";
                    of.Rtt = DateTime.Now;
                    of.Rtp = ur.Id;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;
                    _db.Entry(of).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    //轉送下一關卡
                    of.Opinion = "[" + assign.AssignCls + "]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "1";
                    of.Rtt = DateTime.Now;
                    of.Rtp = ur.Id;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;
                    _db.Entry(of).State = EntityState.Modified;
                    _db.SaveChanges();
                    //
                    OutsideBmedFlow flow = new OutsideBmedFlow();
                    flow.DocId = assign.DocId;
                    flow.StepId = of.StepId + 1;
                    flow.UserId = assign.FlowUid.Value;
                    flow.UserName = _context.AppUsers.Find(assign.FlowUid.Value).FullName;
                    flow.Status = "?";
                    flow.Cls = assign.FlowCls;
                    flow.Rtt = DateTime.Now;
                    flow.item1 = assign.item1;
                    flow.item2 = assign.item2;
                    flow.item3 = assign.item3;
                    flow.item4 = assign.item4;
                    flow.item5 = assign.item5;
                    flow.item6 = assign.item6;
                    flow.item7 = assign.item7;
                    _db.OutsideBmedFlows.Add(flow);
                    _db.SaveChanges();
                

                //Send Mail
                //To user and the next flow user.
                Tmail mail = new Tmail();
                string body = "";
                AppUserModel u;
                //RepairModel repair = _context.BMEDRepairs.Find(assign.DocId);
                mail.from = new System.Net.Mail.MailAddress(ur.Email); //ur.Email
                u = _context.AppUsers.Find(flow.UserId);
                mail.to = new System.Net.Mail.MailAddress(u.Email); //u.Email
                                                                    //mail.cc = new System.Net.Mail.MailAddress("99242@cch.org.tw");
                mail.message.Subject = "醫工智能保修系統[外部醫療使用申請] : 品名 : " + instrument.Name;
                body += "<p>表單編號：" + instrument.DocId + "</p>";
                body += "<p>申請日期：" + instrument.ApplyDate.ToString("yyyy/MM/dd") + "</p>";
                body += "<p>申請人：" + instrument.UserName + "</p>";
                body += "<p>品名：" + instrument.Name + "</p>";
                body += "<p><a href='http://dms.cch.org.tw/BMED/Account/Login'" + "?docId=" + instrument.DocId + "&dealType=BMEDRepEdit" + ">處理案件</a></p>";
                body += "<br/>";
                body += "<h3>此封信件為系統通知郵件，請勿回覆。</h3>";
                body += "<br/>";
                //body += "<h3 style='color:red'>如有任何疑問請聯絡工務部，分機3033或7033。<h3>";
                mail.message.Body = body;
                mail.message.IsBodyHtml = true;
                    mail.SendMail();
                }

                return new JsonResult(assign)
                {
                    Value = new { success = true, error = "" }
                };
            }
            else
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
        }

        [HttpPost]
        public ActionResult TransToMe(string docid)
        {
            Instrument instrument = _db.Instruments.Find(docid);
            //AppUser appUser = db.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (ModelState.IsValid)
            {
                string[] s = new string[] { "?", "2" };
                OutsideBmedFlow rf = _db.OutsideBmedFlows.Where(f => f.DocId == docid && s.Contains(f.Status)).FirstOrDefault();
                //
                //轉送下一關卡
                rf.Opinion = "[改變流程]" + Environment.NewLine
                    + "流程已經被" + "" + "更改。";
                rf.Status = "1";
                rf.Rtt = DateTime.Now;
                rf.Rtp =123456;
                _db.Entry(rf).State = EntityState.Modified;
                _db.SaveChanges();
                //
                OutsideBmedFlow flow = new OutsideBmedFlow();
                flow.DocId = docid;
                flow.StepId = rf.StepId + 1;
                flow.UserId = 123456;
                flow.UserName = "王曉明";
                flow.Status = "?";
                flow.Cls = "";
                flow.Rtt = DateTime.Now;
                _db.OutsideBmedFlows.Add(flow);
                _db.SaveChanges();
                ///Send Mail
                throw new Exception(" ");

            }
            else
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
        }

        [HttpPost]
        public ActionResult Content()
        {
            return new JsonResult(
            new {
                    Data = new { success = true, error = "" }
                });
        }
    }
}