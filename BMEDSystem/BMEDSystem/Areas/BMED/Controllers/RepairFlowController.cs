﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Areas.BMED.Repositories;
using EDIS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using EDIS.Areas.WebService.Models;
using WebService;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class RepairFlowController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<RepairModel, string> _repRepo;
        private readonly IRepository<RepairFlowModel, string[]> _repflowRepo;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;

        public RepairFlowController(ApplicationDbContext context,
                                    IRepository<RepairModel, string> repairRepo,
                                    IRepository<RepairFlowModel, string[]> repairflowRepo,
                                    IRepository<AppUserModel, int> userRepo,
                                    CustomUserManager customUserManager,
                                    CustomRoleManager customRoleManager)
        {
            _context = context;
            _repRepo = repairRepo;
            _repflowRepo = repairflowRepo;
            _userRepo = userRepo;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NextFlow(AssignModel assign)
        {
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            var repairDtl = _context.BMEDRepairDtls.Find(assign.DocId);
            var dpt = _context.BMEDRepairs.Find(assign.DocId).DptId;
            string[] loc = { "K", "P", "C" };
            var applyloc = _context.Departments.Where(d => d.DptId == dpt).Where(d => loc.Contains(d.Loc)).Select(l => l.Loc).FirstOrDefault();
            applyloc = String.IsNullOrEmpty(applyloc) == false ? "總院" : "分院";
            /* 工程師的流程控管 */
            if (assign.Cls == "設備工程師")
            {
                /* 如點選有費用、卻無輸入費用明細 */
                var isCharged = _context.BMEDRepairDtls.Where(d => d.DocId == assign.DocId).FirstOrDefault().IsCharged;
                if (isCharged == "Y")
                {
                    var CheckCost = _context.BMEDRepairCosts.Where(c => c.DocId == assign.DocId).FirstOrDefault();
                    if (CheckCost == null)
                    {
                        if (assign.FlowCls == "醫工主管" || assign.FlowCls == "賀康主管")   //送至主管時才Check
                        {
                            throw new Exception("尚未輸入費用明細!!");
                        }
                    }
                }
            }
            //    var repairDtl = _context.BMEDRepairDtls.Where(d => d.DocId == assign.DocId).FirstOrDefault();
            //    /* 3 = 已完成，4 = 報廢 */
            //    if (repairDtl.DealState == 3 || repairDtl.DealState == 4)
            //    {
            //        if(repairDtl.EndDate == null)
            //        {
            //            throw new Exception("報廢及已完成，需輸入完工日!!");
            //        }
            //    }


            if (assign.FlowCls == "結案" || assign.FlowCls == "廢除")
                assign.FlowUid = ur.Id;
            if (ModelState.IsValid)
            {
                RepairFlowModel rf = _context.BMEDRepairFlows.Where(f => f.DocId == assign.DocId && f.Status == "?").FirstOrDefault();
                if (assign.FlowCls == "驗收人")
                {
                    if (_context.BMEDRepairEmps.Where(emp => emp.DocId == assign.DocId).Count() <= 0)
                    {
                        throw new Exception("沒有維修工程師紀錄!!");
                    }
                    else if (_context.BMEDRepairDtls.Find(assign.DocId).EndDate == null)
                    {
                        throw new Exception("沒有完工日!!");
                    }
                    else if (_context.BMEDRepairDtls.Find(assign.DocId).DealState == 0)
                    {
                        throw new Exception("處理狀態不可空值!!");
                    }
                    if (_context.BMEDRepairDtls.Find(assign.DocId).FailFactor == 0)
                    {
                        throw new Exception("故障原因不可空白!!");
                    }
                    if (string.IsNullOrEmpty(_context.BMEDRepairDtls.Find(assign.DocId).InOut))
                    {
                        throw new Exception("維修方式不可空白!!");
                    }
                    if (_context.BMEDRepairDtls.Find(assign.DocId).DealState == 3 ||
                        _context.BMEDRepairDtls.Find(assign.DocId).DealState == 4 ||
                        _context.BMEDRepairDtls.Find(assign.DocId).DealState == 8)
                    {
                        //Do nothing.
                        //狀態為【已完成】、【報廢】、【退件】才可送至驗收人
                    }
                    else
                    {
                        throw new Exception("送至驗收人處理狀態只可為【已完成】、【報廢】、【退件】!!");
                    }
                }
                if (applyloc == "總院")
                {
                    if (rf.Cls == "設備工程師" &&
                        (repairDtl.IsCharged == "Y" && repairDtl.NotInExceptDevice == "Y") &&
                        (assign.FlowCls == "賀康主管" && assign.AssignCls == "同意"))
                    {
                        RepairDtlModel rd = _context.BMEDRepairDtls.Find(assign.DocId);
                        rd.CloseDate = DateTime.Now;
                        //轉送賀康主管關卡
                        rf.Opinions = "[" + assign.AssignCls + "]" + Environment.NewLine + assign.AssignOpn;
                        rf.Status = "1";
                        rf.Rtt = DateTime.Now;
                        rf.Rtp = ur.Id;
                        _context.Entry(rf).State = EntityState.Modified;
                        _context.Entry(rd).State = EntityState.Modified;
                        _context.SaveChanges();
                        //
                        var role = roleManager.GetUsersInRole("MedAssetMgr");
                        RepairFlowModel flow = new RepairFlowModel();
                        flow.DocId = assign.DocId;
                        flow.StepId = rf.StepId + 1;
                        flow.UserId = _context.AppUsers
                            .Where(u => role.Contains(u.UserName))
                            .Join(_context.Departments.Where(d => loc.Contains(d.Loc)),
                                    u => u.DptId,
                                    d => d.DptId,
                                    (u, d) => new { Id = u.Id }
                            ).Select(x => x.Id).FirstOrDefault();
                        flow.UserName = _context.AppUsers.Find(flow.UserId).FullName;
                        flow.Status = "?";
                        flow.Cls = "賀康主管";
                        flow.Rtt = DateTime.Now;
                        _context.BMEDRepairFlows.Add(flow);
                        _context.SaveChanges();
                    }
                    else if (assign.FlowCls == "結案")
                    {
                        if (assign.Cls == "驗收人" && repairDtl != null)
                        {
                            if (repairDtl.IsCharged == "Y")
                            {
                                throw new Exception("有費用之案件不可由驗收人直接結案!");
                            }
                        }
                        if (assign.Cls == "驗收人" && repairDtl != null)
                        {
                            if (repairDtl.DealState == 4)
                            {
                                throw new Exception("報廢之案件不可由驗收人直接結案!");
                            }
                        }
                        RepairDtlModel rd = _context.BMEDRepairDtls.Find(assign.DocId);
                        rd.CloseDate = DateTime.Now;
                        rf.Opinions = "[" + assign.AssignCls + "]" + Environment.NewLine + assign.AssignOpn;
                        rf.Status = "2";
                        rf.UserId = ur.Id;
                        rf.UserName = _context.AppUsers.Find(ur.Id).FullName;
                        rf.Rtt = DateTime.Now;
                        rf.Rtp = ur.Id;
                        _context.Entry(rf).State = EntityState.Modified;
                        _context.Entry(rd).State = EntityState.Modified;
                        // Save stock to ERP system.
                        if (repairDtl.NotInExceptDevice == "Y" && repairDtl.IsCharged == "Y") //該案件為統包 & 有費用
                        {
                            var ERPreponse = await SaveToERPAsync(assign.DocId);
                            if (!ERPreponse.Contains("成功"))
                            {
                                throw new Exception(ERPreponse);
                            }
                        }
                        _context.SaveChanges();
                        //sync to oracleBatch
                        var rep = _context.BMEDRepairs.Find(assign.DocId);
                        if (rep.Loc == "總院" || rep.Loc == "K")
                        {
                            string smsg = SyncToOracleBatch(assign.DocId);
                            //if (smsg == "1")
                            //    throw new Exception("同步OracleBatch失敗!");
                        }


                        //Send Mail
                        //To all users in this repair's flow.
                        Tmail mail = new Tmail();
                        string body = "";
                        string sto = "";
                        AppUserModel u;
                        RepairModel repair = _context.BMEDRepairs.Find(assign.DocId);
                        mail.from = new System.Net.Mail.MailAddress(ur.Email); //u.Email
                        _context.BMEDRepairFlows.Where(f => f.DocId == assign.DocId)
                                .ToList()
                                .ForEach(f =>
                                {
                                    u = _context.AppUsers.Find(f.UserId);
                                    sto += u.Email + ",";
                                });
                        mail.sto = sto.TrimEnd(new char[] { ',' });

                        mail.message.Subject = "醫工智能保修系統[請修案-結案通知]：設備名稱： " + repair.AssetName;
                        body += "<p>表單編號：" + repair.DocId + "</p>";
                        body += "<p>申請日期：" + repair.ApplyDate.ToString("yyyy/MM/dd") + "</p>";
                        body += "<p>申請人：" + repair.UserName + "</p>";
                        body += "<p>財產編號：" + repair.AssetNo + "</p>";
                        body += "<p>設備名稱：" + repair.AssetName + "</p>";
                        //body += "<p>請修地點：" + repair.PlaceLoc + " " + repair.BuildingName + " " + repair.FloorName + " " + repair.AreaName + "</p>";
                        body += "<p>放置地點：" + repair.PlaceLoc + "</p>";
                        body += "<p>故障描述：" + repair.TroubleDes + "</p>";
                        body += "<p>處理描述：" + rd.DealDes + "</p>";
                        body += "<p><a href='http://dms.cch.org.tw/BMED/Account/Login'" + "?DocId=" + repair.DocId + "&dealType=BMEDRepViews" + ">檢視案件</a></p>";
                        body += "<br/>";
                        body += "<h3>此封信件為系統通知郵件，請勿回覆。</h3>";
                        body += "<br/>";
                        //body += "<h3 style='color:red'>如有任何疑問請聯絡工務部，分機3033或7033。<h3>";
                        mail.message.Body = body;
                        mail.message.IsBodyHtml = true;
                        mail.SendMail();
                    }
                    else if (assign.FlowCls == "廢除")
                    {
                        rf.Opinions = "[廢除]" + Environment.NewLine + assign.AssignOpn;
                        rf.Status = "3";
                        rf.Rtt = DateTime.Now;
                        rf.Rtp = ur.Id;
                        _context.Entry(rf).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else
                    {
                        //轉送下一關卡
                        rf.Opinions = "[" + assign.AssignCls + "]" + Environment.NewLine + assign.AssignOpn;
                        rf.Status = "1";
                        rf.Rtt = DateTime.Now;
                        rf.Rtp = ur.Id;
                        _context.Entry(rf).State = EntityState.Modified;
                        _context.SaveChanges();
                        //
                        RepairFlowModel flow = new RepairFlowModel();
                        flow.DocId = assign.DocId;
                        flow.StepId = rf.StepId + 1;
                        flow.UserId = assign.FlowUid.Value;
                        flow.UserName = _context.AppUsers.Find(assign.FlowUid.Value).FullName;
                        flow.Status = "?";
                        flow.Cls = assign.FlowCls;
                        flow.Rtt = DateTime.Now;
                        _context.BMEDRepairFlows.Add(flow);
                        _context.SaveChanges();

                        //Send Mail
                        //To user and the next flow user.
                        Tmail mail = new Tmail();
                        string body = "";
                        AppUserModel u;
                        RepairModel repair = _context.BMEDRepairs.Find(assign.DocId);
                        mail.from = new System.Net.Mail.MailAddress(ur.Email); //ur.Email
                        u = _context.AppUsers.Find(flow.UserId);
                        mail.to = new System.Net.Mail.MailAddress(u.Email); //u.Email
                                                                            //mail.cc = new System.Net.Mail.MailAddress("99242@cch.org.tw");
                        mail.message.Subject = "醫工智能保修系統[請修案]：設備名稱： " + repair.AssetName;
                        body += "<p>表單編號：" + repair.DocId + "</p>";
                        body += "<p>申請日期：" + repair.ApplyDate.ToString("yyyy/MM/dd") + "</p>";
                        body += "<p>申請人：" + repair.UserName + "</p>";
                        body += "<p>財產編號：" + repair.AssetNo + "</p>";
                        body += "<p>設備名稱：" + repair.AssetName + "</p>";
                        body += "<p>故障描述：" + repair.TroubleDes + "</p>";
                        //body += "<p>請修地點：" + repair.PlaceLoc + " " + repair.BuildingName + " " + repair.FloorName + " " + repair.AreaName + "</p>";
                        body += "<p>放置地點：" + repair.PlaceLoc + "</p>";
                        body += "<p><a href='http://dms.cch.org.tw/BMED/Account/Login'" + "?docId=" + repair.DocId + "&dealType=BMEDRepEdit" + ">處理案件</a></p>";
                        body += "<br/>";
                        body += "<h3>此封信件為系統通知郵件，請勿回覆。</h3>";
                        body += "<br/>";
                        //body += "<h3 style='color:red'>如有任何疑問請聯絡工務部，分機3033或7033。<h3>";
                        mail.message.Body = body;
                        mail.message.IsBodyHtml = true;
                        // 寄信人員控管
                        if (flow.Cls.Contains("工程師") || flow.Cls == "賀康主管" || flow.Cls == "醫工主管")
                        {
                            // 工程師、主管不寄信
                        }
                        else
                        {
                            mail.SendMail();
                        }
                    }
                }
                else
                {
                    if (rf.Cls == "設備主管" &&
                        (repairDtl.IsCharged == "Y" && repairDtl.NotInExceptDevice == "Y") &&
                        (assign.FlowCls == "結案" || (assign.FlowCls == "賀康主管" && assign.AssignCls == "同意")))
                    {
                        if (assign.Cls == "驗收人" && repairDtl != null)
                        {
                            if (repairDtl.IsCharged == "Y")
                            {
                                throw new Exception("有費用之案件不可由驗收人直接結案!");
                            }
                        }
                        if (assign.Cls == "驗收人" && repairDtl != null)
                        {
                            if (repairDtl.DealState == 4)
                            {
                                throw new Exception("報廢之案件不可由驗收人直接結案!");
                            }
                        }
                        RepairDtlModel rd = _context.BMEDRepairDtls.Find(assign.DocId);
                        rd.CloseDate = DateTime.Now;
                        //轉送賀康主管關卡
                        rf.Opinions = "[" + assign.AssignCls + "]" + Environment.NewLine + assign.AssignOpn;
                        rf.Status = "1";
                        rf.Rtt = DateTime.Now;
                        rf.Rtp = ur.Id;
                        _context.Entry(rf).State = EntityState.Modified;
                        _context.Entry(rd).State = EntityState.Modified;
                        _context.SaveChanges();
                        //
                        var role = roleManager.GetUsersInRole("MedAssetMgr");
                        RepairFlowModel flow = new RepairFlowModel();
                        flow.DocId = assign.DocId;
                        flow.StepId = rf.StepId + 1;
                        flow.UserId = _context.AppUsers
                            .Where(u => role.Contains(u.UserName))
                            .Join(_context.Departments.Where(d => !loc.Contains(d.Loc)),
                                    u => u.DptId,
                                    d => d.DptId,
                                    (u, d) => new { Id = u.Id }
                            ).Select(x => x.Id).FirstOrDefault();
                        flow.UserName = _context.AppUsers.Find(flow.UserId).FullName;
                        flow.Status = "?";
                        flow.Cls = "賀康主管";
                        flow.Rtt = DateTime.Now;
                        _context.BMEDRepairFlows.Add(flow);
                        _context.SaveChanges();
                    }
                    else if (assign.FlowCls == "結案")
                    {
                        if (assign.Cls == "驗收人" && repairDtl != null)
                        {
                            if (repairDtl.IsCharged == "Y")
                            {
                                throw new Exception("有費用之案件不可由驗收人直接結案!");
                            }
                        }
                        if (assign.Cls == "驗收人" && repairDtl != null)
                        {
                            if (repairDtl.DealState == 4)
                            {
                                throw new Exception("報廢之案件不可由驗收人直接結案!");
                            }
                        }
                        RepairDtlModel rd = _context.BMEDRepairDtls.Find(assign.DocId);
                        rd.CloseDate = DateTime.Now;
                        rf.Opinions = "[" + assign.AssignCls + "]" + Environment.NewLine + assign.AssignOpn;
                        rf.Status = "2";
                        rf.UserId = ur.Id;
                        rf.UserName = _context.AppUsers.Find(ur.Id).FullName;
                        rf.Rtt = DateTime.Now;
                        rf.Rtp = ur.Id;
                        _context.Entry(rf).State = EntityState.Modified;
                        _context.Entry(rd).State = EntityState.Modified;
                        // Save stock to ERP system.
                        if (repairDtl.NotInExceptDevice == "Y" && repairDtl.IsCharged == "Y") //該案件為統包 & 有費用
                        {
                            var ERPreponse = await SaveToERPAsync(assign.DocId);
                            if (!ERPreponse.Contains("成功"))
                            {
                                throw new Exception(ERPreponse);
                            }
                        }
                        _context.SaveChanges();
                        //sync to oracleBatch
                        var rep = _context.BMEDRepairs.Find(assign.DocId);
                        if (rep.Loc == "總院" || rep.Loc == "K")
                        {
                            string smsg = SyncToOracleBatch(assign.DocId);
                            //if (smsg == "1")
                            //    throw new Exception("同步OracleBatch失敗!");
                        }


                        //Send Mail
                        //To all users in this repair's flow.
                        Tmail mail = new Tmail();
                        string body = "";
                        string sto = "";
                        AppUserModel u;
                        RepairModel repair = _context.BMEDRepairs.Find(assign.DocId);
                        mail.from = new System.Net.Mail.MailAddress(ur.Email); //u.Email
                        _context.BMEDRepairFlows.Where(f => f.DocId == assign.DocId)
                                .ToList()
                                .ForEach(f =>
                                {
                                    u = _context.AppUsers.Find(f.UserId);
                                    sto += u.Email + ",";
                                });
                        mail.sto = sto.TrimEnd(new char[] { ',' });

                        mail.message.Subject = "醫工智能保修系統[請修案-結案通知]：設備名稱： " + repair.AssetName;
                        body += "<p>表單編號：" + repair.DocId + "</p>";
                        body += "<p>申請日期：" + repair.ApplyDate.ToString("yyyy/MM/dd") + "</p>";
                        body += "<p>申請人：" + repair.UserName + "</p>";
                        body += "<p>財產編號：" + repair.AssetNo + "</p>";
                        body += "<p>設備名稱：" + repair.AssetName + "</p>";
                        //body += "<p>請修地點：" + repair.PlaceLoc + " " + repair.BuildingName + " " + repair.FloorName + " " + repair.AreaName + "</p>";
                        body += "<p>放置地點：" + repair.PlaceLoc + "</p>";
                        body += "<p>故障描述：" + repair.TroubleDes + "</p>";
                        body += "<p>處理描述：" + rd.DealDes + "</p>";
                        body += "<p><a href='http://dms.cch.org.tw/BMED/Account/Login'" + "?DocId=" + repair.DocId + "&dealType=BMEDRepViews" + ">檢視案件</a></p>";
                        body += "<br/>";
                        body += "<h3>此封信件為系統通知郵件，請勿回覆。</h3>";
                        body += "<br/>";
                        //body += "<h3 style='color:red'>如有任何疑問請聯絡工務部，分機3033或7033。<h3>";
                        mail.message.Body = body;
                        mail.message.IsBodyHtml = true;
                        mail.SendMail();
                    }
                    else if (assign.FlowCls == "廢除")
                    {
                        rf.Opinions = "[廢除]" + Environment.NewLine + assign.AssignOpn;
                        rf.Status = "3";
                        rf.Rtt = DateTime.Now;
                        rf.Rtp = ur.Id;
                        _context.Entry(rf).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else
                    {
                        //轉送下一關卡
                        rf.Opinions = "[" + assign.AssignCls + "]" + Environment.NewLine + assign.AssignOpn;
                        rf.Status = "1";
                        rf.Rtt = DateTime.Now;
                        rf.Rtp = ur.Id;
                        _context.Entry(rf).State = EntityState.Modified;
                        _context.SaveChanges();
                        //
                        RepairFlowModel flow = new RepairFlowModel();
                        flow.DocId = assign.DocId;
                        flow.StepId = rf.StepId + 1;
                        flow.UserId = assign.FlowUid.Value;
                        flow.UserName = _context.AppUsers.Find(assign.FlowUid.Value).FullName;
                        flow.Status = "?";
                        flow.Cls = assign.FlowCls;
                        flow.Rtt = DateTime.Now;
                        _context.BMEDRepairFlows.Add(flow);
                        _context.SaveChanges();

                        //Send Mail
                        //To user and the next flow user.
                        Tmail mail = new Tmail();
                        string body = "";
                        AppUserModel u;
                        RepairModel repair = _context.BMEDRepairs.Find(assign.DocId);
                        mail.from = new System.Net.Mail.MailAddress(ur.Email); //ur.Email
                        u = _context.AppUsers.Find(flow.UserId);
                        mail.to = new System.Net.Mail.MailAddress(u.Email); //u.Email
                                                                            //mail.cc = new System.Net.Mail.MailAddress("99242@cch.org.tw");
                        mail.message.Subject = "醫工智能保修系統[請修案]：設備名稱： " + repair.AssetName;
                        body += "<p>表單編號：" + repair.DocId + "</p>";
                        body += "<p>申請日期：" + repair.ApplyDate.ToString("yyyy/MM/dd") + "</p>";
                        body += "<p>申請人：" + repair.UserName + "</p>";
                        body += "<p>財產編號：" + repair.AssetNo + "</p>";
                        body += "<p>設備名稱：" + repair.AssetName + "</p>";
                        body += "<p>故障描述：" + repair.TroubleDes + "</p>";
                        //body += "<p>請修地點：" + repair.PlaceLoc + " " + repair.BuildingName + " " + repair.FloorName + " " + repair.AreaName + "</p>";
                        body += "<p>放置地點：" + repair.PlaceLoc + "</p>";
                        body += "<p><a href='http://dms.cch.org.tw/BMED/Account/Login'" + "?docId=" + repair.DocId + "&dealType=BMEDRepEdit" + ">處理案件</a></p>";
                        body += "<br/>";
                        body += "<h3>此封信件為系統通知郵件，請勿回覆。</h3>";
                        body += "<br/>";
                        //body += "<h3 style='color:red'>如有任何疑問請聯絡工務部，分機3033或7033。<h3>";
                        mail.message.Body = body;
                        mail.message.IsBodyHtml = true;
                        // 寄信人員控管
                        if (flow.Cls.Contains("工程師") || flow.Cls == "賀康主管" || flow.Cls == "醫工主管")
                        {
                            // 工程師、主管不寄信
                        }
                        else
                        {
                            mail.SendMail();
                        }
                    }
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

        private string SyncToOracleBatch(string docid)
        {
            string responseString = "";

            using (var client = new HttpClient())
            {
                string urlstr = "http://dms.cch.org.tw/CchWebApi/api/SyncBatch/CloseCase";
                urlstr += "?docid=" + docid;
                var url = new Uri(urlstr, UriKind.Absolute);
                //string json = JsonConvert.SerializeObject(apps);
                //HttpContent contentPost = new StringContent(json);
                //contentPost.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                try
                {
                    var response = client.GetAsync(url); //
                    responseString = response.Result.Content.ReadAsStringAsync().Result;
                    var msg = JsonConvert.DeserializeObject<SystemMsg>(responseString);
                    return msg.MsgCode;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        [HttpPost]
        public IActionResult GetNextEmp(string cls, string docid/*, string vendor*/)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<string> s;
            SelectListItem li;
            AppUserModel u;
            RepairModel r = _context.BMEDRepairs.Find(docid);
            AssetModel asset = _context.BMEDAssets.Where(a => a.AssetNo == r.AssetNo).FirstOrDefault();
            string[] locList;

            switch (cls)
            {
                case "維修工程師": //Not Used
                    roleManager.GetUsersInRole("Engineer").ToList()
                        .ForEach(x =>
                        {
                            u = _context.AppUsers.Where(ur => ur.UserName == x).FirstOrDefault();
                            if (u != null)
                            {
                                li = new SelectListItem();
                                li.Text = u.FullName + "(" + u.UserName + ")";
                                li.Value = u.Id.ToString();
                                list.Add(li);
                            }
                        });
                    break;
                case "醫工主管":
                    s = roleManager.GetUsersInRole("MedMgr").ToList();
                    list = new List<SelectListItem>();
                    foreach (string l in s)
                    {
                        u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                        if (!string.IsNullOrEmpty(u.DptId))
                        {
                            li = new SelectListItem();
                            li.Text = u.FullName + "(" + u.UserName + ")";
                            li.Value = u.Id.ToString();
                            list.Add(li);
                        }
                    }
                    break;
                case "賀康主管": //設備主管
                    s = roleManager.GetUsersInRole("MedAssetMgr").ToList();
                    list = new List<SelectListItem>();
                    foreach (string l in s)
                    {
                        u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                        if (!string.IsNullOrEmpty(u.DptId))
                        {
                            li = new SelectListItem();
                            li.Text = u.FullName + "(" + u.UserName + ")";
                            li.Value = u.Id.ToString();
                            list.Add(li);
                        }
                    }
                    if (r.Loc == "總院")
                    {
                        list.Remove(list.Single(x => x.Value == "1129"));
                    }
                    else
                    {
                        list.Remove(list.Single(x => x.Value == "12549"));
                    }
                    break;
                case "醫工主任":  //Not Used
                    s = roleManager.GetUsersInRole("MedDirector").ToList();
                    list = new List<SelectListItem>();
                    foreach (string l in s)
                    {
                        u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                        if (!string.IsNullOrEmpty(u.DptId))
                        {
                            li = new SelectListItem();
                            li.Text = u.FullName + "(" + u.UserName + ")";
                            li.Value = u.Id.ToString();
                            list.Add(li);
                        }
                    }
                    break;
                case "醫工經辦":  //Not Used
                    list = new List<SelectListItem>();
                    u = _context.AppUsers.Where(ur => ur.UserName == "1814").FirstOrDefault();
                    if (!string.IsNullOrEmpty(u.DptId))
                    {
                        li = new SelectListItem();
                        li.Text = u.FullName + "(" + u.UserName + ")";
                        li.Value = u.Id.ToString();
                        list.Add(li);
                    }
                    break;
                case "單位主管":
                    /* Get login user. */
                    u = _userRepo.Find(ur => ur.UserName == this.User.Identity.Name).FirstOrDefault();
                    /* Get login user's location. */
                    var urLocation = new DepartmentModel(_context).GetUserLocation(u);
                    if (urLocation != "總院")
                    {
                        s = roleManager.GetUsersInRole("Manager").OrderBy(x => x).ToList();
                        list = new List<SelectListItem>();
                        li = new SelectListItem();
                        li.Text = "請選擇";
                        li.Value = "請選擇";
                        list.Add(li);
                        //
                        locList = new[] { "K", "P", "C" };
                        if (r.Loc != "總院")
                        {
                            Array.Clear(locList, 0, locList.Length);
                            locList = new[] { r.Loc };
                        }
                        foreach (string l in s)
                        {
                            u = _context.AppUsers.Where(ur => !string.IsNullOrEmpty(ur.DptId))
                            .Join(_context.Departments, ur => ur.DptId, d => d.DptId, (ur, d) => new
                            {
                                appuser = ur,
                                dpt = d
                            })
                            .Where(d => locList.Contains(d.dpt.Loc))
                            .Where(ur => ur.appuser.UserName == l && ur.appuser.Status == "Y").Select(ur => ur.appuser).FirstOrDefault();
                            
                            if (u != null)
                            {
                                li = new SelectListItem();
                                li.Text = u.FullName + "(" + u.UserName + ")";
                                li.Value = u.Id.ToString();
                                list.Add(li);
                            }
                        }
                    }
                    else
                    {
                        list = new List<SelectListItem>();
                        li = new SelectListItem();
                        li.Text = "請選擇";
                        li.Value = "請選擇";
                        list.Add(li);
                        //

                        _context.AppUsers.Where(ur => !string.IsNullOrEmpty(ur.DptId))
                        .Where(ur => ur.DptId == r.DptId)
                        .Where(ur => ur.Status == "Y")
                        .ToList()
                        .ForEach(ur => {
                            li = new SelectListItem();
                            li.Text = ur.FullName + "(" + ur.UserName + ")";
                            li.Value = ur.Id.ToString();
                            list.Add(li);
                        });
                    }
                    break;
                case "單位主任":  //Not Used
                    break;
                case "單位副院長":  //Not Used
                    s = roleManager.GetUsersInRole("ViceSI").ToList();
                    list = new List<SelectListItem>();
                    foreach (string l in s)
                    {
                        u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                        if (!string.IsNullOrEmpty(u.DptId))
                        {
                            li = new SelectListItem();
                            li.Text = u.FullName + "(" + u.UserName + ")";
                            li.Value = u.Id.ToString();
                            list.Add(li);
                        }
                    }
                    break;
                case "申請人":
                    if (r != null)
                    {
                        list = new List<SelectListItem>();
                        li = new SelectListItem();
                        li.Text = r.UserName;
                        li.Value = r.UserId.ToString();
                        list.Add(li);
                    }
                    else
                    {
                        list = new List<SelectListItem>();
                        li = new SelectListItem();
                        li.Text = "宋大衛";
                        li.Value = "000";
                        list.Add(li);
                    }
                    break;
                case "驗收人":
                    if (_context.BMEDRepairEmps.Where(emp => emp.DocId == docid).Count() <= 0)
                    {
                        throw new Exception("沒有維修工程師紀錄!!");
                    }
                    else if (_context.BMEDRepairDtls.Find(docid).EndDate == null)
                    {
                        throw new Exception("沒有完工日!!");

                    }
                    if (r != null)
                    {
                        /* 與驗收人同單位的成員(包括驗收人) */
                        var checkerDptId = _context.AppUsers.Find(r.CheckerId).DptId;
                        List<AppUserModel> ul = _context.AppUsers.Where(f => f.DptId == checkerDptId)
                                                                 .Where(f => f.Status == "Y").ToList();
                        if (asset != null)
                        {
                            if(asset.DelivDpt != r.DptId)
                            {
                                ul.AddRange(_context.AppUsers.Where(f => f.DptId == asset.DelivDpt)
                                                             .Where(f => f.Status == "Y").ToList());
                            }
                        }
                        /* 驗收人 */
                        var checker = _context.AppUsers.Find(r.CheckerId);
                        list = new List<SelectListItem>();
                        li = new SelectListItem();
                        li.Text = checker.FullName + "(" + checker.UserName + ")";
                        li.Value = checker.Id.ToString();
                        list.Add(li);

                        foreach (AppUserModel l in ul)
                        {
                            /* 申請人以外的成員 */
                            if(l.Id != r.UserId)
                            {
                                li = new SelectListItem();
                                li.Text = l.FullName + "(" + l.UserName + ")";
                                li.Value = l.Id.ToString();
                                list.Add(li);
                            }
                        }
                    }
                    break;
                case "設備工程師":

                    /* Get all engineers. */
                    
                    var repEngId = _context.AppUsers.Find(r.EngId).UserName;
                    var lastflow = _context.BMEDRepairFlows
                        .Where(f => f.DocId == docid && f.Status == "1")
                        .Where(f => f.Cls.Contains("工程師") )
                        .OrderByDescending(x => x.StepId)
                        .Select(f => f.UserId)
                        .FirstOrDefault();

                    if (lastflow != 0) {
                        var ur = _context.AppUsers.Find(lastflow).UserName;
                        s = roleManager.GetUsersInRole("MedEngineer").Where(x => x == ur).ToList();
                        s.AddRange(roleManager.GetUsersInRole("MedEngineer").Where(x => x != ur).OrderBy(x => x).ToList());
                    }
                    else
                    {
                        s = roleManager.GetUsersInRole("MedEngineer").OrderBy(x => x).ToList();
                    }

                    list = new List<SelectListItem>();
                    /* 負責工程師 */
                    var engTemp = _context.AppUsers.Find(r.EngId);
                    if (r.EngId != 0)
                    {
                        li = new SelectListItem();
                        li.Text = engTemp.FullName + "(" + engTemp.UserName + ")";
                        li.Value = engTemp.Id.ToString();
                        list.Add(li);
                    }
                    /* 其他工程師 */
                    locList = new[] { "K", "P", "C" };
                    if (r.Loc != "總院")
                    {
                        Array.Clear(locList, 0, locList.Length);
                        locList = new[] { r.Loc };
                    }
                    foreach (string l in s)
                    {
                        u = _context.AppUsers.Where(ur => !string.IsNullOrEmpty(ur.DptId))
                            .Join(_context.Departments, ur => ur.DptId, d => d.DptId, (ur, d) => new
                            {
                                appuser = ur,
                                dpt = d
                            })
                            .Where(d => locList.Contains(d.dpt.Loc))
                            .Where(ur => ur.appuser.UserName == l && ur.appuser.Status == "Y").Select(ur => ur.appuser).FirstOrDefault();

                        if (u != null && l != repEngId)
                        {
                            li = new SelectListItem();
                            li.Text = u.FullName + "(" + u.UserName + ")";
                            li.Value = u.Id.ToString();
                            list.Add(li);
                        }
                    }
                    break;
                case "列管財產負責人":  //Not Used
                    list = new List<SelectListItem>();
                    u = _context.AppUsers.Where(ur => ur.UserName == "181151").FirstOrDefault();
                    if (!string.IsNullOrEmpty(u.DptId))
                    {
                        li = new SelectListItem();
                        li.Text = u.FullName + "(" + u.UserName + ")";
                        li.Value = u.Id.ToString();
                        list.Add(li);
                    }
                    break;
                case "固資財產負責人":  //Not Used
                    list = new List<SelectListItem>();
                    u = _context.AppUsers.Where(ur => ur.UserName == "1814").FirstOrDefault();
                    if (!string.IsNullOrEmpty(u.DptId))
                    {
                        li = new SelectListItem();
                        li.Text = u.FullName + "(" + u.UserName + ")";
                        li.Value = u.Id.ToString();
                        list.Add(li);
                    }
                    break;
                case "醫工分院主管":
                    s = roleManager.GetUsersInRole("MedBranchMgr").OrderBy(x => x).ToList();
                    list = new List<SelectListItem>();
                    //locList = new[] { r.Loc };
                    foreach (string l in s)
                    {
                        u = _context.AppUsers.Where(ur => ur.UserName == l && ur.Status == "Y").FirstOrDefault();
                        if (u != null)
                        {
                            li = new SelectListItem();
                            li.Text = u.FullName + "(" + u.UserName + ")";
                            li.Value = u.Id.ToString();
                            list.Add(li);
                        }
                    }
                    break;
                case "設備主管":
                    s = roleManager.GetUsersInRole("DeviceMgr").OrderBy(x => x).ToList();
                    list = new List<SelectListItem>();
                    locList = new[] { "K", "P", "C" };
                    if (r.Loc != "總院")
                    {
                        Array.Clear(locList, 0, locList.Length);
                        locList = new[] { r.Loc };
                    }
                    foreach (string l in s)
                    {
                        u = _context.AppUsers.Where(ur => !string.IsNullOrEmpty(ur.DptId))
                            .Join(_context.Departments, ur => ur.DptId, d => d.DptId, (ur, d) => new 
                            { 
                                appuser = ur,
                                dpt = d
                            })
                            .Where(d => locList.Contains(d.dpt.Loc))
                            .Where(ur => ur.appuser.UserName == l && ur.appuser.Status == "Y").Select(ur => ur.appuser).FirstOrDefault();
                        if (u != null)
                        {
                            li = new SelectListItem();
                            li.Text = u.FullName + "(" + u.UserName + ")";
                            li.Value = u.Id.ToString();
                            list.Add(li);
                        }
                    }
                    break;
                default:
                    list = new List<SelectListItem>();
                    break;
            }
            return Json(list);
        }

        /// <summary>
        /// Sync Stock to ERP system.
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>
        private async Task<string> SaveToERPAsync(string docId)
        {
            ERPservicesSoapClient ERPWebServices = new ERPservicesSoapClient(ERPservicesSoapClient.EndpointConfiguration.ERPservicesSoap);
            string msg = "";
            //
            var repair = _context.BMEDRepairs.Find(docId);
            ERPRepHead hd = new ERPRepHead();
            hd.ZHANG_ID = "2";
            hd.ADD = 0;
            hd.BIL_NO = docId;
            hd.PS_DD = DateTime.Now.Date;
            hd.SAL_NO = User.Identity.Name;
            //Get SAL_NO
            //var salStocks = _context.BMEDRepairCosts.Where(rc => rc.DocId == docId)
            //                                        .Where(rc => rc.StockType == "0").ToList();
            //var salTickets = _context.BMEDRepairCosts.Where(rc => rc.DocId == docId)
            //                                         .Where(rc => rc.StockType == "2").ToList();
            //if (salStocks.Count() > 0)
            //{
            //    var salId = salStocks.FirstOrDefault().Rtp;
            //    var user = _context.AppUsers.Find(salId);
            //    hd.SAL_NO = user.UserName;
            //}
            //else
            //{
            //    var salId = salTickets.OrderByDescending(s => s.Rtt).FirstOrDefault().Rtp;
            //    var user = _context.AppUsers.Find(salId);
            //    hd.SAL_NO = user.UserName;
            //}
            var user = _context.BMEDRepairEmps.Where(e => e.DocId == docId).FirstOrDefault().UserId;

            hd.SAL_NO = _context.AppUsers.Find(user).UserName;

            if (repair != null)
            {
                hd.CUS_NO = repair.AccDpt;
                var asset = _context.BMEDAssets.Find(repair.AssetNo);
                if (asset != null)
                {
                    hd.WEBMAC = asset.Type;
                    hd.WEBITM = asset.MakeNo;
                }
                if (!string.IsNullOrEmpty(repair.SalesDocId))
                {
                    hd.ADD = 1;
                }
            }
            //Get repair doc's costs.
            DateTime? ticketDate = null;
            var repairCosts = _context.BMEDRepairCosts.Where(rc => rc.DocId == docId).ToList();
            if (repairCosts.Count() > 0)
            {
                // 讀取庫存明細 (2020/9/30增加發票明細)
                var stocks = repairCosts.Where(rc => rc.StockType == "0" || rc.StockType == "2").OrderBy(rc => rc.SeqNo).ToList();
                if (stocks.Count() > 0)
                {
                    int i = 1;
                    List<ERPRepBody> body = new List<ERPRepBody>();
                    ERPVendors ERPvendor = new ERPVendors();
                    foreach (var stock in stocks)
                    {
                        // get ERP vendor id.
                        if (stock.VendorId != null)
                        {
                            var vendor = _context.BMEDVendors.Find(stock.VendorId);
                            ERPvendor = await new ERPVendors().GetERPVendorAsync(vendor.UniteNo);
                        }
                        // get ticket date.
                        if (stock.AccountDate.HasValue)
                        {
                            if (ticketDate == null)
                            {
                                ticketDate = stock.AccountDate.Value.Date;
                            }
                            else if (stock.AccountDate.Value < ticketDate)
                            {
                                ticketDate = stock.AccountDate.Value.Date;
                            }
                        }
                        // 
                        var isPay = "F";
                        if (stock.IsPetty == "Y")
                        {
                            isPay = "T";
                        }
                        body.Add(new ERPRepBody
                        {
                            ITM = i,
                            PRD_NO = stock.PartNo,
                            PRD_NAME = stock.PartName,
                            QTY = Convert.ToDecimal(stock.Qty),
                            UP = Convert.ToDecimal(stock.Price),
                            AMT = Convert.ToDecimal(stock.TotalCost),
                            INV_CUS_NO = stock.VendorId == null || stock.StockType == "0" ? null : ERPvendor.CUS_NO,
                            ISPAY = isPay,
                            TAX_ID = stock.TaxClass
                        });
                        i++;
                    }
                    //
                    if (ticketDate != null)
                    {
                        hd.PS_DD = ticketDate.Value;
                    }
                    //
                    string mf = JsonConvert.SerializeObject(hd);
                    string bf = JsonConvert.SerializeObject(body);
                    var response = await ERPWebServices.PostRepStuffAsync(mf, bf);
                    JObject objs = JObject.Parse(response.Body.PostRepStuffResult);
                    string rtnCode = objs["RtnCode"].ToString();
                    if (rtnCode == "1")
                    {
                        msg = objs["RtnMsg"].ToString();
                        //回傳銷貨單號，回寫至請修單主檔
                        if (repair != null)
                        {
                            repair.SalesDocId = msg;
                            _context.Entry(repair).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                        msg = "成功";
                    }
                    else
                    {
                        var rtnMsg = objs["RtnMsg"].ToString().Replace(Environment.NewLine, "");
                        msg = "寫入ERP失敗!" + Environment.NewLine + "請將錯誤訊息【" + rtnMsg + "】告知ERP管理人員協助處理。";
                    }
                    return msg;
                }
                msg = "無費用明細，寫入ERP失敗!";
                return msg;
            }
            else
            {
                msg = "無費用明細，寫入ERP失敗!";
                return msg;
            }
        }

    }
}