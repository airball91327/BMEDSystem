using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EDIS.Fliters;
using Newtonsoft.Json;
using EDIS.Areas.WebService.Models;
using WebService;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class KeepFlowController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;

        public KeepFlowController(ApplicationDbContext context,
                                  IRepository<AppUserModel, int> userRepo,
                                  CustomUserManager customUserManager,
                                  CustomRoleManager customRoleManager)
        {
            _context = context;
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
            var keepDtl = _context.BMEDKeepDtls.Find(assign.DocId);

            /* 工程師的流程控管 */
            if (assign.Cls == "設備工程師")
            {
                /* 如點選有費用、卻無輸入費用明細 */
                var isCharged = _context.BMEDKeepDtls.Where(d => d.DocId == assign.DocId).FirstOrDefault().IsCharged;
                if (isCharged == "Y")
                {
                    var CheckCost = _context.BMEDKeepCosts.Where(c => c.DocId == assign.DocId).FirstOrDefault();
                    if (CheckCost == null)
                    {
                        if (assign.FlowCls == "醫工主管" || assign.FlowCls == "賀康主管")   //送至主管時才Check
                        {
                            throw new Exception("尚未輸入費用明細!!");
                        }
                    }
                }
            }

            if (assign.FlowCls == "結案" || assign.FlowCls == "廢除")
                assign.FlowUid = ur.Id;
            if (ModelState.IsValid)
            {
                KeepFlowModel kf = _context.BMEDKeepFlows.Where(f => f.DocId == assign.DocId && f.Status == "?").FirstOrDefault();
                if (assign.FlowCls == "驗收人")
                {
                    if (_context.BMEDKeepEmps.Where(emp => emp.DocId == assign.DocId).Count() <= 0)
                    {
                        throw new Exception("沒有維修工程師紀錄!!");
                    }
                    else if (_context.BMEDKeepDtls.Find(assign.DocId).EndDate == null)
                    {
                        throw new Exception("沒有完工日!!");
                    }
                    if (_context.BMEDKeepDtls.Find(assign.DocId).Result == null)
                    {
                        throw new Exception("保養結果不可空白!!");
                    }
                    if (string.IsNullOrEmpty(_context.BMEDKeepDtls.Find(assign.DocId).InOut))
                    {
                        throw new Exception("保養方式不可空白!!");
                    }
                }
                if (assign.FlowCls == "結案")
                {
                    if (assign.Cls == "驗收人" && keepDtl != null)
                    {
                        if (keepDtl.IsCharged == "Y")
                        {
                            throw new Exception("有費用之案件不可由驗收人直接結案!");
                        }
                    }
                    KeepDtlModel kd = _context.BMEDKeepDtls.Find(assign.DocId);
                    kd.CloseDate = DateTime.Now;
                    kf.Opinions = "[" + assign.AssignCls + "]" + Environment.NewLine + assign.AssignOpn;
                    kf.Status = "2";
                    kf.UserId = ur.Id;
                    kf.UserName = _context.AppUsers.Find(ur.Id).FullName;
                    kf.Rtt = DateTime.Now;
                    kf.Rtp = ur.Id;
                    _context.Entry(kf).State = EntityState.Modified;
                    _context.Entry(kd).State = EntityState.Modified;
                    // Save stock to ERP system.
                    if (keepDtl.NotInExceptDevice == "Y" && keepDtl.IsCharged == "Y") //該案件為統包 & 有費用
                    {
                        var ERPreponse = await SaveToERPAsync(assign.DocId);
                        if (!ERPreponse.Contains("成功"))
                        {
                            throw new Exception(ERPreponse);
                        }
                    }
                    _context.SaveChanges();
                    KeepModel keep = _context.BMEDKeeps.Find(assign.DocId);
                    if (keep.Loc == "總院" || keep.Loc == "K")
                    {
                        //sync to oracleBatch
                        string smsg = await SyncToOracleBatchAsync(assign.DocId);
                        //if (smsg == "1")
                        //    throw new Exception("同步OracleBatch失敗!");
                    }

                    //Send Mail
                    //To all users in this keep's flow.
                    Tmail mail = new Tmail();
                    string body = "";
                    string sto = "";
                    AppUserModel u;
                    
                    mail.from = new System.Net.Mail.MailAddress(ur.Email); //u.Email
                    _context.BMEDKeepFlows.Where(f => f.DocId == assign.DocId)
                            .ToList()
                            .ForEach(f =>
                            {
                                u = _context.AppUsers.Find(f.UserId);
                                sto += u.Email + ",";
                            });
                    mail.sto = sto.TrimEnd(new char[] { ',' });

                    mail.message.Subject = "醫工智能保修系統[保養案-結案通知]：設備名稱： " + keep.AssetName;
                    body += "<p>表單編號：" + keep.DocId + "</p>";
                    body += "<p>送單日期：" + keep.SentDate.Value.ToString("yyyy/MM/dd") + "</p>";
                    body += "<p>申請人：" + keep.UserName + "</p>";
                    body += "<p>財產編號：" + keep.AssetNo + "</p>";
                    body += "<p>設備名稱：" + keep.AssetName + "</p>";
                    body += "<p>放置地點：" + keep.PlaceLoc + "</p>";
                    body += "<p>保養結果：" + kd.Result + "</p>";
                    body += "<p>保養描述：" + kd.Memo + "</p>";
                    body += "<p><a href='http://dms.cch.org.tw/BMED/Account/Login'" + "?DocId=" + keep.DocId + "&dealType=BMEDKeepViews" + ">檢視案件</a></p>";
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
                    kf.Opinions = "[廢除]" + Environment.NewLine + assign.AssignOpn;
                    kf.Status = "3";
                    kf.Rtt = DateTime.Now;
                    kf.Rtp = ur.Id;
                    _context.Entry(kf).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    //轉送下一關卡
                    kf.Opinions = "[" + assign.AssignCls + "]" + Environment.NewLine + assign.AssignOpn;
                    kf.Status = "1";
                    kf.Rtt = DateTime.Now;
                    kf.Rtp = ur.Id;
                    _context.Entry(kf).State = EntityState.Modified;
                    _context.SaveChanges();
                    //
                    KeepFlowModel flow = new KeepFlowModel();
                    flow.DocId = assign.DocId;
                    flow.StepId = kf.StepId + 1;
                    flow.UserId = assign.FlowUid.Value;
                    flow.UserName = _context.AppUsers.Find(assign.FlowUid.Value).FullName;
                    flow.Status = "?";
                    flow.Cls = assign.FlowCls;
                    flow.Rtt = DateTime.Now;
                    _context.BMEDKeepFlows.Add(flow);
                    _context.SaveChanges();
                    // 轉送的下一個關卡為驗收人
                    if (assign.FlowCls == "驗收人")
                    {
                        KeepModel kp = _context.BMEDKeeps.Find(assign.DocId);
                        if (kp.Src != "M")  //非手動出單
                        {
                            var usr = _context.AppUsers.Find(assign.FlowUid.Value);
                            if (usr != null)
                            {
                                kp.CheckerId = usr.Id;
                                kp.CheckerName = usr.FullName;
                                _context.Entry(kp).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                        }
                    }

                    //Send Mail
                    //To user and the next flow user.
                    Tmail mail = new Tmail();
                    string body = "";
                    AppUserModel u;
                    KeepModel keep = _context.BMEDKeeps.Find(assign.DocId);
                    mail.from = new System.Net.Mail.MailAddress(ur.Email); //ur.Email
                    u = _context.AppUsers.Find(flow.UserId);
                    mail.to = new System.Net.Mail.MailAddress(u.Email); //u.Email
                                                                        //mail.cc = new System.Net.Mail.MailAddress("99242@cch.org.tw");
                    mail.message.Subject = "醫工智能保修系統[保養案]：設備名稱： " + keep.AssetName;
                    body += "<p>表單編號：" + keep.DocId + "</p>";
                    body += "<p>送單日期：" + keep.SentDate.Value.ToString("yyyy/MM/dd") + "</p>";
                    body += "<p>申請人：" + keep.UserName + "</p>";
                    body += "<p>財產編號：" + keep.AssetNo + "</p>";
                    body += "<p>設備名稱：" + keep.AssetName + "</p>";
                    body += "<p>放置地點：" + keep.PlaceLoc + "</p>";
                    body += "<p><a href='http://dms.cch.org.tw/BMED/Account/Login'" + "?docId=" + keep.DocId + "&dealType=BMEDKeepEdit" + ">處理案件</a></p>";
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
        public ActionResult GetNextEmp(string cls, string docid/*, string vendor*/)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<string> s;
            SelectListItem li;
            AppUserModel u;
            KeepModel k = _context.BMEDKeeps.Find(docid);
            AssetModel asset = _context.BMEDAssets.Where(a => a.AssetNo == k.AssetNo).FirstOrDefault();
            string[] locList;

            switch (cls)
            {
                case "維修工程師":  //Not Used
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
                case "賀康主管":  //設備主管
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
                    if (k.Loc == "總院")
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
                    //list = new List<SelectListItem>();
                    //u = _context.AppUsers.Where(ur => ur.UserName == "1814").FirstOrDefault();
                    //if (!string.IsNullOrEmpty(u.DptId))
                    //{
                    //    li = new SelectListItem();
                    //    li.Text = u.FullName;
                    //    li.Value = u.Id.ToString();
                    //    list.Add(li);
                    //}
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
                        if (k.Loc != "總院")
                        {
                            Array.Clear(locList, 0, locList.Length);
                            locList = new[] { k.Loc };
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
                        li = new SelectListItem();
                        li.Text = "請選擇";
                        li.Value = "請選擇";
                        list.Add(li);
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
                    if (k != null)
                    {
                        list = new List<SelectListItem>();
                        li = new SelectListItem();
                        li.Text = k.UserName;
                        li.Value = k.UserId.ToString();
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
                    if (_context.BMEDKeepEmps.Where(emp => emp.DocId == docid).Count() <= 0)
                    {
                        throw new Exception("沒有維修工程師紀錄!!");
                    }
                    else if (_context.BMEDKeepDtls.Find(docid).EndDate == null)
                    {
                        throw new Exception("沒有完工日!!");

                    }
                    else if (_context.BMEDKeepDtls.Find(docid).Result == null ||
                        _context.BMEDKeepDtls.Find(docid).Result == null)
                    {
                        throw new Exception("沒有保養結果!!");
                    }
                    if (k != null)
                    {
                        if (k.Src != "M")// 非手動出單
                        {
                            /* 成本中心的成員 */
                            List<AppUserModel> ul = _context.AppUsers.Where(f => f.DptId == k.AccDpt)
                                                                     .Where(f => f.Status == "Y").ToList();
                            /* 驗收人列表 */
                            list = new List<SelectListItem>();
                            li = new SelectListItem();
                            li.Text = "請選擇";
                            li.Value = null;
                            list.Add(li);

                            foreach (AppUserModel l in ul)
                            {
                                li = new SelectListItem();
                                li.Text = l.FullName + "(" + l.UserName + ")";
                                li.Value = l.Id.ToString();
                                list.Add(li);
                            }
                        }
                        else
                        {
                            /* 與驗收人同單位的成員(包括驗收人) */
                            var checkerDptId = _context.AppUsers.Find(k.CheckerId).DptId;
                            List<AppUserModel> ul = _context.AppUsers.Where(f => f.DptId == checkerDptId)
                                                                     .Where(f => f.Status == "Y").ToList();
                            if (asset != null)
                            {
                                if (asset.DelivDpt != k.DptId)
                                {
                                    ul.AddRange(_context.AppUsers.Where(f => f.DptId == asset.DelivDpt)
                                                                 .Where(f => f.Status == "Y").ToList());
                                }
                            }
                            /* 驗收人 */
                            var checker = _context.AppUsers.Find(k.CheckerId);
                            list = new List<SelectListItem>();
                            li = new SelectListItem();
                            li.Text = checker.FullName + "(" + checker.UserName + ")";
                            li.Value = checker.Id.ToString();
                            list.Add(li);

                            foreach (AppUserModel l in ul)
                            {
                                /* 申請人以外的成員 */
                                if (l.Id != k.UserId)
                                {
                                    li = new SelectListItem();
                                    li.Text = l.FullName + "(" + l.UserName + ")";
                                    li.Value = l.Id.ToString();
                                    list.Add(li);
                                }
                            }
                        }
                    }
                    break;
                case "設備工程師":

                    /* Get all engineers. */
                    s = roleManager.GetUsersInRole("MedEngineer").OrderBy(x => x).ToList();
                    var keepEngId = _context.BMEDAssetKeeps.Find(k.AssetNo).KeepEngId;
                    var keepEng = _context.AppUsers.Find(keepEngId);

                    list = new List<SelectListItem>();
                    /* 負責工程師 */
                    li = new SelectListItem();
                    li.Text = keepEng.FullName + "(" + keepEng.UserName + ")";
                    li.Value = keepEng.Id.ToString();
                    list.Add(li);
                    /* 其他工程師 */
                    locList = new[] { "K", "P", "C" };
                    if (k.Loc != "總院")
                    {
                        Array.Clear(locList, 0, locList.Length);
                        locList = new[] { k.Loc };
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

                        if (u != null && l != keepEng.UserName)
                        {
                            li = new SelectListItem();
                            li.Text = u.FullName + "(" + u.UserName + ")";
                            li.Value = u.Id.ToString();
                            list.Add(li);
                        }
                    }
                    break;
                case "列管財產負責人":  //Not Used
                    //list = new List<SelectListItem>();
                    //u = _context.AppUsers.Where(ur => ur.UserName == "181151").FirstOrDefault();
                    //if (!string.IsNullOrEmpty(u.DptId))
                    //{
                    //    li = new SelectListItem();
                    //    li.Text = u.FullName;
                    //    li.Value = u.Id.ToString();
                    //    list.Add(li);
                    //}
                    break;
                case "固資財產負責人":  //Not Used
                    //list = new List<SelectListItem>();
                    //u = _context.AppUsers.Where(ur => ur.UserName == "1814").FirstOrDefault();
                    //if (!string.IsNullOrEmpty(u.DptId))
                    //{
                    //    li = new SelectListItem();
                    //    li.Text = u.FullName;
                    //    li.Value = u.Id.ToString();
                    //    list.Add(li);
                    //}
                    break;
                case "醫工分院主管":
                    s = roleManager.GetUsersInRole("MedBranchMgr").OrderBy(x => x).ToList();
                    list = new List<SelectListItem>();
                    locList = new[] { k.Loc };
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
                case "設備主管":
                    s = roleManager.GetUsersInRole("DeviceMgr").OrderBy(x => x).ToList();
                    list = new List<SelectListItem>();
                    locList = new[] { "K", "P", "C" };
                    if (k.Loc != "總院")
                    {
                        Array.Clear(locList, 0, locList.Length);
                        locList = new[] { k.Loc };
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
            var keep = _context.BMEDKeeps.Find(docId);
            ERPRepHead hd = new ERPRepHead();
            hd.ZHANG_ID = "2";
            hd.ADD = 0;
            hd.BIL_NO = "K" + docId;
            hd.PS_DD = DateTime.Now.Date;
            hd.SAL_NO = User.Identity.Name;
            //Get SAL_NO
            var salStocks = _context.BMEDKeepCosts.Where(rc => rc.DocId == docId)
                                                  .Where(rc => rc.StockType == "0").ToList();
            var salTickets = _context.BMEDKeepCosts.Where(rc => rc.DocId == docId)
                                                   .Where(rc => rc.StockType == "2").ToList();
            if (salStocks.Count() > 0)
            {
                var salId = salStocks.FirstOrDefault().Rtp;
                var user = _context.AppUsers.Find(salId);
                hd.SAL_NO = user.UserName;
            }
            else
            {
                var salId = salTickets.OrderByDescending(s => s.Rtt).FirstOrDefault().Rtp;
                var user = _context.AppUsers.Find(salId);
                hd.SAL_NO = user.UserName;
            }
#if DEBUG
            hd.SAL_NO = "344033";
#endif
            if (keep != null)
            {
                hd.CUS_NO = keep.AccDpt;
                var asset = _context.BMEDAssets.Find(keep.AssetNo);
                if (asset != null)
                {
                    hd.WEBMAC = asset.Type;
                    hd.WEBITM = asset.MakeNo;
                }
                if (!string.IsNullOrEmpty(keep.SalesDocId))
                {
                    hd.ADD = 1;
                }
            }
            //Get keep doc's costs.
            DateTime? ticketDate = null;
            var keepCosts = _context.BMEDKeepCosts.Where(rc => rc.DocId == docId).ToList();
            if (keepCosts.Count() > 0)
            {
                // 讀取庫存明細 (2020/9/30增加發票明細)
                var stocks = keepCosts.Where(rc => rc.StockType == "0" || rc.StockType == "2").OrderBy(rc => rc.SeqNo).ToList();
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
                        if (keep != null)
                        {
                            keep.SalesDocId = msg;
                            _context.Entry(keep).State = EntityState.Modified;
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

        private async Task<string> SyncToOracleBatchAsync(string docid)
        {
            string responseString = "";

            using (var client = new HttpClient())
            {
                string urlstr = "";
                //
                UriBuilder builder = new UriBuilder("http://dms.cch.org.tw/CchWebApi/api/SyncBatch/KeepCloseCase");
                builder.Query = "docid=" + docid + "";
                //
                urlstr = "api/SyncBatch/KeepCloseCase?docid=" + docid;
                //client.BaseAddress = new Uri("http://dms.cch.org.tw/CchWebApi2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync(builder.Uri).Result; //
                    response.EnsureSuccessStatusCode();
                    responseString = await response.Content.ReadAsStringAsync();
                    var msg = JsonConvert.DeserializeObject<SystemMsg>(responseString);
                    return msg.MsgCode;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

    }
}