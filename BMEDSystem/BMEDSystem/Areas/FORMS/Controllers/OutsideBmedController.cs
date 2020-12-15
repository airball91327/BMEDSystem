using EDIS.Repositories;
using EDIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDIS.Areas.FORMS.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Linq;
using EDIS.Areas.FORMS.Data;
using System.Net;
using EDIS.Models;
using Microsoft.AspNetCore.Hosting;
using EDIS.Models.Identity;
using Newtonsoft.Json;
using X.PagedList;
using System.IO;
using ClosedXML.Excel;

namespace EDIS.Areas.FORMS.Controllers
{
    [Area("FORMS")]
    [Authorize]

    public class OutsideBmedController : Controller
    {
        
        private readonly BMEDDBContext _db;
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private readonly IRepository<DocIdStore, string[]> _dsRepo;
        private int pageSize = 50;
        public OutsideBmedController(BMEDDBContext db,
                                    ApplicationDbContext context,
                                    IRepository<AppUserModel, int> userRepo,
                                    IRepository<DocIdStore, string[]> dsRepo,
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
            _dsRepo = dsRepo;
        }

        // POST: BMED/Repair/Index
        [HttpPost]
        public IActionResult Index(QryOsbListData qdata, int page = 1)
        {
            string docid = qdata.FORMSqtyDOCID;
            string aname = qdata.FORMSqtyASSETNAME;
            string ftype = qdata.FORMSqtyFLOWTYPE;
            string dptid = qdata.FORMSqtyDPTID;
            string qtyDate1 = qdata.FORMSqtyApplyDateFrom;
            string qtyDate2 = qdata.FORMSqtyApplyDateTo;
            string qtyDateType = qdata.FORMSqtyDateType;
            bool searchAllDoc = qdata.FORMSqtySearchAllDoc;
            string qtyVendor = qdata.FORMSqtyVendor;
            string qtyClsUser = qdata.FORMSqtyClsUser;

            //至少輸入一個搜尋條件
            if (docid == null  && aname == null && ftype == "請選擇" &&
                dptid == null && qtyDate1 == null && qtyDate2 == null &&
                qtyVendor == null)
            {
                return BadRequest("請至少輸入一個查詢條件!");
            }
           
            if (searchAllDoc == true)
            {
                ftype = "其他工程師案件";
            }

            DateTime applyDateFrom = DateTime.Now;
            DateTime applyDateTo = DateTime.Now;
            /* Dealing search by date. */
            if (qtyDate1 != null && qtyDate2 != null)// If 2 date inputs have been insert, compare 2 dates.
            {
                DateTime date1 = DateTime.Parse(qtyDate1);
                DateTime date2 = DateTime.Parse(qtyDate2).AddDays(1);
                int result = DateTime.Compare(date1, date2);
                if (result < 0)
                {
                    applyDateFrom = date1.Date;
                    applyDateTo = date2.Date;
                }
                else if (result == 0)
                {
                    applyDateFrom = date1.Date;
                    applyDateTo = date1.Date;
                }
                else
                {
                    applyDateFrom = date2.Date;
                    applyDateTo = date1.Date;
                }
            }
            else if (qtyDate1 == null && qtyDate2 != null)
            {
                applyDateFrom = new DateTime();
                applyDateTo = DateTime.Parse(qtyDate2).AddDays(1);
            }
            else if (qtyDate1 != null && qtyDate2 == null)
            {
                applyDateFrom = DateTime.Parse(qtyDate1);
                applyDateTo = DateTime.Now.AddDays(1);
            }


            List<OutsideBmedListModel> rv = new List<OutsideBmedListModel>();
            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            //var urLocation = new DepartmentModel(_context).GetUserLocation(ur);

            //
            // 依照使用者ID 搜尋需處理案件

            var rps = _db.OutsideBmedFlows
                .Where(n => n.UserId == ur.Id )
                .Join(_db.Instruments, 
                d => d.DocId, f => f.DocId,
                               (d, f) => new
                               {
                                    signflow = d,
                                    signdata = f
                               });

            if (!string.IsNullOrEmpty(docid))   //表單編號
            {
                docid = docid.Trim();
                rps = rps.Where(v => v.signdata.DocId == docid);
            }

            if (!string.IsNullOrEmpty(dptid))   //申請部門
            {
                rps = rps.Where(v => v.signdata.UseUnit == dptid);
            }
            if (!string.IsNullOrEmpty(qtyVendor))   //廠商關鍵字
            {
                rps = rps.Where(v => v.signdata.Vendor.Contains(qtyVendor));
            }
            if (!string.IsNullOrEmpty(qtyClsUser))   //目前關卡人員
            {
                rps = rps.Where(r => r.signdata.ToUserId == Convert.ToInt32(qtyClsUser));
            }
            

            /* If no search result. */
            if (rps.Count() == 0)
            {
                return PartialView("List", rv.ToPagedList(page, pageSize));
            }
            //var flows = _db.OutsideBmedFlows.Where(f2 => f2.UserId == ur.Id).LastOrDefault();


            switch (ftype)
            {
                /* 與登入者相關且流程不在該登入者身上的文件 */
                case "流程中":
                    rps.Where(r => r.signflow.Status == "1" && r.signflow.UserId == ur.Id)
                       .Select(r => r.signflow.DocId).Distinct()
                       .Join(_db.OutsideBmedFlows.Where(f => f.Status == "?" && f.UserId != ur.Id),
                       r => r, f => f.DocId,
                       (r, f) => new
                       {
                           repair = r,
                           flow = f
                       })
                       .Join(_db.Instruments, m => m.repair, d => d.DocId,
                       (m, d) => new
                       {
                           repair = m.repair,
                           flow = m.flow,
                           repdtl = d
                       })
                       .ToList()
                       .ForEach(j => rv.Add(new OutsideBmedListModel
                       {
                           DocType = "外部醫療儀器使用申請",
                           Cls = j.flow.Cls,
                           DocId = j.flow.DocId,
                           UserName = j.flow.UserName,
                           Topic = j.flow.Opinion,
                           ApplyDate = j.repdtl.ApplyDate,
                           Rtt = j.flow.Rtt,
                           Status = "流程中",
                           Kind = ""
                       }));
                    break;
                /* 與登入者相關且結案的文件 */
                case "已結案":
                    /* Get all closed repair docs. */
                    var rf = rps.Where(f => f.signflow.Status == "2");

                    //if (userManager.IsInRole(User, "Admin") || userManager.IsInRole(User, "MedAdmin") ||
                    //    userManager.IsInRole(User, "Manager") || userManager.IsInRole(User, "MedEngineer"))
                    //{

                    //    /* If no other search values, search the docs belong the login engineer. */
                    //    if (userManager.IsInRole(User, "MedEngineer") && searchAllDoc == false)
                    //    {
                    //        rf = rf.Join(_db.OutsideBmedFlows.Where(f2 => f2.UserId == ur.Id),
                    //             f => f.DocId, f2 => f2.DocId, (f, f2) => f);
                    //    }
                    //}
                    //else /* If normal user, search the docs belong himself. */
                    //{
                    //    rf = rf.Join(_db.OutsideBmedFlows.Where(f2 => f2.UserId == ur.Id),
                    //         f => f.DocId, f2 => f2.DocId, (f, f2) => f);
                    //}

                    rf.Select(f => new
                    {
                        f.signdata.DocId,
                        f.signdata.UserId,
                        f.signflow.Status,
                        f.signflow.Cls,
                        f.signflow.Rtt
                    }).Distinct().Join(rps.DefaultIfEmpty(), f => f.DocId, r => r.signdata.DocId,
                    (f, r) => new
                    {
                        repair = r,
                        flow = f
                    })
                    .ToList()
                    .ForEach(j => rv.Add(new OutsideBmedListModel
                    {
                        DocType = "外部醫療儀器使用申請",
                        DocId = j.repair.signdata.DocId,
                        UserName = j.repair.signdata.UserName,
                        Topic = j.repair.signdata.Description,
                        ApplyDate = j.repair.signdata.ApplyDate,
                        Rtt = j.flow.Rtt,
                        Status = GetStatus(j.flow.Status),
                        Kind = "",
                        Cls = j.flow.Cls,
                    }));
                    break;
                /* 與登入者相關且流程在該登入者身上的文件 */
                case "待簽核":
                    /* Get all dealing repair docs. */
                    var repairFlows = rps.Where(f => f.signflow.Status == "?")
                        .Join(rps.DefaultIfEmpty(), f => f.signdata.DocId, r => r.signdata.DocId,
                    (f, r) => new
                    {
                        repair = r,
                        flow = f
                    });


                    /* 個人案件 */
                    repairFlows = repairFlows.Where(f => (f.repair.signflow.Status == "?" && f.repair.signflow.UserId == ur.Id));
                    //}

                    repairFlows.ToList()
                    .ForEach(j => rv.Add(new OutsideBmedListModel
                    {
                        DocType = "外部醫療儀器使用申請",
                        DocId = j.repair.signdata.DocId,
                        UserName = j.repair.signdata.UserName,
                        Topic = j.repair.signdata.Description,
                        ApplyDate = j.repair.signdata.ApplyDate,
                        Rtt = j.flow.signflow.Rtt,
                        Status = GetStatus(j.flow.signflow.Status),
                        Kind = "",
                        Cls = j.flow.signflow.Cls
                    }));
                    break;
                /* 不分流程的所有案件 */
                case "請選擇":
                    /* Get all dealing repair docs. */
                    string[] ss = new string[] { "?", "2" };
                    rps.Where(r => ss.Contains(r.signflow.Status))
                    .ToList()
                    .ForEach(j => rv.Add(new OutsideBmedListModel
                    {
                        DocType = "外部醫療儀器使用申請",
                        DocId = j.signdata.DocId,
                        UserName = j.signdata.UserName,
                        Topic = j.signdata.Description,
                        ApplyDate = j.signdata.ApplyDate,
                        Rtt = j.signflow.Rtt,
                        Status = GetStatus(j.signflow.Status),
                        Kind = "",
                        Cls = j.signflow.Cls,
                    }));
                    break;

            };

            /* Search date by DateType.(ApplyDate) */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)
            {
                if (qtyDateType == "申請日")
                {
                    rv = rv.Where(v => v.ApplyDate >= applyDateFrom && v.ApplyDate <= applyDateTo).ToList();
                }
            }




            /* Search date by DateType. */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)
            {
                if (qtyDateType == "結案日")
                {
                    rv = rv
                        .Where(v => v.Status == "2")
                        .Where(v => v.ApplyDate >= applyDateFrom && v.ApplyDate <= applyDateTo).ToList();
                }

            }



            //
            /* 處理轉單關卡的下拉選單 */
            List<SelectListItem> listItem1 = new List<SelectListItem>();
            listItem1.Add(new SelectListItem { Text = "設備工程師", Value = "設備工程師" });
            listItem1.Add(new SelectListItem { Text = "醫工主管", Value = "醫工主管" });
            listItem1.Add(new SelectListItem { Text = "賀康主管", Value = "賀康主管" });
            ViewData["AssignCls"] = new SelectList(listItem1, "Value", "Text");
            //
            var pageCount = rv.ToPagedList(page, pageSize).PageCount;
            pageCount = pageCount == 0 ? 1 : pageCount; // If no page.
            if (rv.ToPagedList(page, pageSize).Count <= 0)  //If the page has no items.
                return PartialView("List", rv.ToPagedList(pageCount, pageSize));

            return PartialView("List", rv.ToPagedList(page, pageSize));
           
        }

        public IActionResult List()
        {
            return PartialView();
        }

        // GET:Create
        [Authorize]
        public IActionResult Create()
        {
            Instrument medeue = new Instrument();
            AppUserModel u;
            //使用者資訊
            var ur = _userRepo.Find(uf => uf.UserName == this.User.Identity.Name).FirstOrDefault();

            string docid = "";
            do
            {
                System.Threading.Thread.Sleep(1000);
                docid = GetUseId();
            } while (string.IsNullOrEmpty(docid) || docid.Contains("Error"));

            List<SelectListItem> listItem1 = new List<SelectListItem>();
            List<SelectListItem> listItem2 = new List<SelectListItem>();
            List<SelectListItem> listItem3 = new List<SelectListItem>();

            //該單位所有人員
            _context.AppUsers.Where(d => d.DptId == ur.DptId).ToList()
                        .ForEach(x =>
                        {
                            //listItem1.Add(new SelectListItem { Text = u.UserName, Value = u.UserName });
                            listItem1.Add(new SelectListItem { Text = "("+x.UserName+")"+x.FullName, Value = x.UserName });
                            
                        });
            ViewData["ToUserId"] = new SelectList(listItem1, "Value", "Text", "");

            //該User單位
            _context.Departments.Where(d => d.DptId == ur.DptId).ToList()
                .ForEach(d =>
                {
                    listItem2.Add(new SelectListItem { Text = d.Name_C, Value = d.DptId });
                }
                );
            ViewData["UseUnit"] = new SelectList(listItem2, "Value", "Text", "");

            ////關卡
            //listItem3.Add(new SelectListItem { Text = "申請者", Value = "申請者" });
            //listItem3.Add(new SelectListItem { Text = "單位主管", Value = "單位主管" });
            //listItem3.Add(new SelectListItem { Text = "醫工承辦", Value = "醫工承辦" });
            //listItem3.Add(new SelectListItem { Text = "醫工工程師", Value = "醫工工程師" });
            ////listItem.Add(new SelectListItem { Text = "專責單位", Value = "專責單位" });
            //listItem3.Add(new SelectListItem { Text = "醫工部主管", Value = "醫工部主管" });
            //ViewData["FlowCls"] = new SelectList(listItem3, "Value", "Text", "");
            //

            medeue.DocId = docid;
            medeue.UserId = ur.UserName;
            medeue.UserName = ur.FullName;
            medeue.Day = "0";
            medeue.UseDayFrom = DateTime.Now;
            medeue.UseDayTo = DateTime.Now;
            medeue.ApplyDate = DateTime.Now;
            medeue.FlowCls = "申請單位主管";
            return View(medeue);
        }

        


        // POST: MedEqu
        [HttpPost]
        public IActionResult Create(Instrument instrument)
        {
            //檔案上傳確認
            AttainFile attain = _db.AttainFiles.Where(p => p.DocId == instrument.DocId).FirstOrDefault();
            if (instrument.Application != "患者自帶" && attain == null)
            {
                return BadRequest("審核內容需附上證明檔案");
            }

            if (instrument.Application == "患者自帶")
            {
                instrument.Vendor = null;
                instrument.Phone = null;
                instrument.Personnel = null;
                instrument.Content = null;
            }
            else if (instrument.Application != "臨床試驗")
            {
                instrument.ProjectId = null;
                instrument.IRB_NO = null;
                instrument.TrialHost = null;
            }
            
            if (!ModelState.IsValid)
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                return BadRequest(msg);
            }
            if (instrument.UseDayFrom >= instrument.UseDayTo)
            {
                return BadRequest("使用日期其日期選擇有誤，請重新選擇");
            }

            instrument.ToUserName = _context.AppUsers.Where(a => a.UserName == instrument.UserId).Select(a => a.FullName).FirstOrDefault();
           
            _db.Instruments.Add(instrument);

            //設定流程
            OutsideBmedFlow of;
            //使用者資訊
            var ur = _userRepo.Find(uf => uf.UserName == this.User.Identity.Name).FirstOrDefault();

            var id = _context.AppUsers.Where(i => i.UserName == instrument.UserId).Select(i => i.Id).FirstOrDefault();
            of = new OutsideBmedFlow();
            of.DocId = instrument.DocId;
            of.StepId = 1;
            of.UserId = ur.Id;
            of.UserName = ur.UserName;
            of.Status = "1";
            of.Cls = "申請者";
            of.Rtp = id;
            of.Rtt = DateTime.Now;
            of.item1 = false;
            of.item2 = false;
            of.item3 = false;
            of.item4 = false;
            of.item5 = false;
            of.item6 = false;
            of.item7 = false;
            _db.OutsideBmedFlows.Add(of);
            //
            of = new OutsideBmedFlow();
            of.DocId = instrument.DocId;    
            of.StepId = 2;
            of.UserId = instrument.ToUserId;
            of.UserName = _context.AppUsers.Where(a => a.Id == instrument.ToUserId).Select(c => c.UserName).FirstOrDefault().ToString();
            of.Status = "?";
            of.Cls = instrument.FlowCls;
            of.Rtp = id;
            of.Rtt = DateTime.Now;
            of.item1 = false;
            of.item2 = false;
            of.item3 = false;
            of.item4 = false;
            of.item5 = false;
            of.item6 = false;
            of.item7 = false;
            _db.OutsideBmedFlows.Add(of);
            _db.SaveChanges();
            return Ok(of);

        }

        public string GetUseId()
        {
            string did = "";
            try
            {
                DocIdStore ds = new DocIdStore();
                ds.DocType = "外部醫療儀器使用申請";
                string s = _dsRepo.Find(x => x.DocType == "外部醫療儀器使用申請").Select(x => x.DocId).Max();
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
                    var dataIsExist = _dsRepo.Find(x => x.DocType == "外部醫療儀器使用申請");
                    if (dataIsExist.Count() == 0)
                    {
                        _dsRepo.Create(ds);
                    }
                }
            }
            catch (Exception e)
            {
                RedirectToAction("Create", "OutsideBmed", new { Area = "FORMS" });
            }
            return did;
        }

        public string GetStatus(string status)
        {
            string s = "";
            if (string.IsNullOrEmpty(status))
            {
                return s;
            }

            switch (status)
            {
                case "?":
                    s = "待簽核";
                    break;
                case "1":
                    s = "流程中";
                    break;
                case "2":
                    s = "已結案";
                    break;
            }


            return s;
        }

        [HttpPost]
        public IActionResult GetDay(string UseDayFrom , string UseDayTo)
        {
            
            var action = Convert.ToDateTime(UseDayFrom);

            var end = Convert.ToDateTime(UseDayTo);

            //if (action > end)
            //{
            //    return NotFound();
            //}
            JObject jo = new JObject();
            //TimeSpan Days = new TimeSpan();
            var s =  (end-action).Days;

            var Days = s.ToString();
            return Json(Days);          
        }

        // GET: OutsideBmed/Details/
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Instrument signData = _db.Instruments.Find(id);

            if (signData == null)
            {
                return NotFound();
            }
            signData.UseUnit = _context.Departments.Find(signData.UseUnit).Name_C;
            return PartialView(signData);
        }

        // GET: OutsideBmed/Details/
        public IActionResult NewContent(string id)
        {
            Assign assign = new Assign();
            Instrument data = _db.Instruments.Find(id);
            OutsideBmedFlow of = _db.OutsideBmedFlows.Where(o => o.DocId == id).OrderBy(o => o.Rtt == data.ApplyDate).ToList().Last();   
            
            assign.item1=of.item1;
            assign.item2=of.item2;
            assign.item3=of.item3;
            assign.item4=of.item4;
            assign.item5=of.item5;
            assign.item6=of.item6;
            assign.item7=of.item7;
            assign.Application = data.Application;
            assign.Content = data.Content;
            return PartialView(assign);
        }

        public async Task<IActionResult> OutsideBmedEdit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Instrument instrument = await _db.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }
            //ViewData["kind"] = kind;

            return View(instrument);
        }

        // GET: Instrument/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var stepId = _db.OutsideBmedFlows.Where(o => o.DocId == id).Select(o => o.StepId).Max();
            OutsideBmedFlow instrument = await _db.OutsideBmedFlows.FindAsync(id, stepId);
            if (instrument == null)
            {
                return NotFound();
            }
            return View(instrument);
        }

        // GET: OutsideBmed/Details/
        public IActionResult PreviewData(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Instrument signData = _db.Instruments.Find(id);
            if (signData == null)
            {
                return NotFound();
            }
            return View(signData);
        }

       

        public IActionResult QryData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult QryData(FormCollection fc)
        {
            string sdate = fc["Sdate"];
            string edate = fc["Edate"];
            string name = fc["Name"];
            string model = fc["Model"];
            string serial = fc["Serial"];
            string useUnit = fc["UseUnit"];
            string label = fc["Label"];

            //使用者資訊
            var ur = _userRepo.Find(uf => uf.UserName == this.User.Identity.Name).FirstOrDefault();

            List<OutsideBmedListModel> sv = new List<OutsideBmedListModel>();
            string[] s = new string[] { "?", "2" };
            string s2 = "";
            DateTime dt;
            int uid = ur.Id;
            _db.OutsideBmedFlows.Where(f => f.UserId == uid).Select(f => f.DocId)
                .Join(_db.Instruments, t => t, d => d.DocId, (t, d) => d)
                .Join(_db.OutsideBmedFlows.Where(f => s.Contains(f.Status)), d => d.DocId, f => f.DocId,
                (d, f) => new
                {
                    leave = d,
                    leaveflow = f
                }).ToList()
                .ForEach(item =>
                {
                    switch (item.leaveflow.Status)
                    {
                        case "?":
                            s2 = "流程中";
                            break;
                        case "2":
                            s2 = "已結案";
                            break;
                        case "-":
                            s2 = "會簽中";
                            break;
                    };
                    sv.Add(new OutsideBmedListModel
                    {
                        DocType = "外部醫療儀器申請",
                        DocId = item.leave.DocId,
                        UserName = item.leave.UserName,
                        Topic = item.leave.Description,
                        ApplyDate = item.leave.ApplyDate,
                        Rtt = item.leave.ApplyDate,
                        Status = s2,
                        UseDayFrom = item.leave.UseDayFrom,
                        UseDayTo = item.leave.UseDayTo,
                        Name = item.leave.Name,
                        Model = item.leave.Model,
                        Serial = item.leave.Serial,
                        Label = item.leave.Label,
                        UseUnit = item.leave.UseUnit
                    });

                });
            if (!string.IsNullOrEmpty(name))
            {
               
                    sv = sv.Where(v => v.Name.Contains(name)).ToList();
                
            }
            if (!string.IsNullOrEmpty(model))
            {

                sv = sv.Where(v => v.Model.Contains(model)).ToList();
                
                
            }
            if (!string.IsNullOrEmpty(serial))
            {
               
                    sv = sv.Where(v => v.Serial.Contains(serial)).ToList();
                
            }
            if (!string.IsNullOrEmpty(label))
            {
                
                    sv = sv.Where(v => v.Label.Contains(label)).ToList();
                
            }
            if (!string.IsNullOrEmpty(useUnit))
            {
                
                    sv = sv.Where(v => v.UseUnit == useUnit).ToList();
                
            }
            if (!string.IsNullOrEmpty(sdate))
            {
                if (DateTime.TryParse(sdate, out dt))
                {
                    sv = sv.Where(v => v.UseDayFrom >= dt).ToList();
                }
            }
            if (!string.IsNullOrEmpty(edate))
            {
                if (DateTime.TryParse(edate, out dt))
                {
                    sv = sv.Where(v => v.UseDayTo <= dt).ToList();
                }
            }
            return PartialView("QryDataList", sv);
        }

        public IActionResult QryDataList()
        {
            List<OutsideBmedListModel> sv = new List<OutsideBmedListModel>();
            string[] s = new string[] { "?", "2" };
            string s2 = "";
           // DateTime dt;
            int uid = 123456;
            _db.OutsideBmedFlows.Where(f => f.UserId == uid).Select(f => f.DocId)
                .Join(_db.Instruments, t => t, d => d.DocId, (t, d) => d)
                .Join(_db.OutsideBmedFlows.Where(f => s.Contains(f.Status)), d => d.DocId, f => f.DocId,
                (d, f) => new
                {
                    leave = d,
                    leaveflow = f
                }).ToList()
                .ForEach(item =>
                {
                    switch (item.leaveflow.Status)
                    {
                        case "?":
                            s2 = "流程中";
                            break;
                        case "2":
                            s2 = "已結案";
                            break;
                        case "-":
                            s2 = "會簽中";
                            break;
                    };
                    sv.Add(new OutsideBmedListModel
                    {
                        DocType = "外部醫療儀器申請",
                        DocId = item.leave.DocId,
                        UserName = item.leave.UserName,
                        Topic = item.leave.Description,
                        ApplyDate = item.leave.ApplyDate,
                        Rtt = item.leave.ApplyDate,
                        Status = s2,
                        UseDayFrom = item.leave.UseDayFrom,
                        UseDayTo = item.leave.UseDayTo,
                        Name = item.leave.Name,
                        Model = item.leave.Model,
                        Serial = item.leave.Serial,
                        Label = item.leave.Label,
                        UseUnit = item.leave.UseUnit
                    });

                });

            return PartialView(sv);
        }

        // GET: OutsideBemd/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Instrument instrument= await _db.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }
            return View(instrument);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            //SignData signData = await db.SignDatas.FindAsync(id);
            //db.SignDatas.Remove(signData);
          
            //使用者資訊
            var ur = _userRepo.Find(uf => uf.UserName == this.User.Identity.Name).FirstOrDefault();

            string[] ss = new string[] { "?", "2"};
            OutsideBmedFlow of = await _db.OutsideBmedFlows.Where(s => s.DocId == id)
                .Where(s => ss.Contains(s.Status)).FirstOrDefaultAsync();
            of.Status = "3";
            of.Rtp = ur.Id;
            of.Rtt = DateTime.Now;
            _db.Entry(of).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        // GET: Repairs/PrintRepairDoc/5
        public IActionResult PrintRepairDoc(string DocId, int printType)
        {
            /* Get all print details according to the DocId. */
            Instrument repair = _db.Instruments.Find(DocId);


            /* Get the last flow. */
            string[] s = new string[] { "?", "2" };
            OutsideBmedFlow flow = _db.OutsideBmedFlows.Where(f => f.DocId == DocId)
                                                           .Where(f => s.Contains(f.Status)).FirstOrDefault();
            OutsideBmedPrintVModel vm = new OutsideBmedPrintVModel();
            if (repair == null)
            {
                return StatusCode(404);
            }
            else
            {
                var id = _context.AppUsers.Where(i => i.UserName == repair.UserId).Select(i => i.Id).FirstOrDefault();

                vm.DocId = DocId;
                vm.UserId = id;
                vm.UserName = _context.AppUsers.Find(id).FullName;
                vm.Contact = repair.Ext;
                vm.UserAccount = _context.AppUsers.Find(id).UserName;
                vm.Company = _context.Departments.Find(repair.UseUnit).Name_C;
                vm.AssetNam = repair.Name;
                vm.Model = repair.Model;
                vm.ApplyDate = repair.UseDayFrom;
                vm.EndDate = repair.UseDayTo;
                vm.Label = repair.Label;
                vm.Description = repair.Description;
                vm.Serial = repair.Serial;
                vm.Vendor = repair.Vendor;
                vm.Phone = repair.Phone;
                vm.Personnel = repair.Personnel;
                vm.Personnel = repair.Personnel;
                vm.IRB_NO = repair.IRB_NO;
                vm.TrialHost = repair.TrialHost;
                vm.Day = repair.Day;
                vm.Content = repair.Content;

                if (repair.Application == "患者自帶")
                    vm.Application = repair.Application + "(審核內容:6)";
                else
                    vm.Application = repair.Application + "(審核內容:1~5)";

                if (flow.item1 == true)
                {
                    vm.item1 = flow.item1;
                }

                if (flow.item4 == true && flow.item7 == false)
                {
                    vm.item4 = flow.item4;
                    vm.item7 = flow.item7;
                }
                else if (flow.item4 == false && flow.item7 == true)
                {
                    vm.item4 = flow.item4;
                    vm.item7 = flow.item7;
                }
                else
                {
                    vm.item4 = false;
                    vm.item7 = false;
                }

                var lastFlowEng = _db.OutsideBmedFlows.Where(rf => rf.DocId == DocId)
                                                          .Where(rf => rf.Cls.Contains("工程師"))
                                                          .OrderByDescending(rf => rf.StepId).FirstOrDefault();
                
                if (lastFlowEng != null)
                {
                    AppUserModel EngTemp = _context.AppUsers.Find(lastFlowEng.UserId);
                    vm.EngName = " (" + EngTemp.UserName + ")" + EngTemp.FullName;
                }
                else
                {
                    vm.EngName = "";
                }

                var engMgr = _db.OutsideBmedFlows.Where(r => r.DocId == DocId)
                                                     .Where(r => r.Cls.Contains("醫工部主管")).ToList();
                if (engMgr.Count() != 0)
                {
                    engMgr = engMgr.GroupBy(e => e.UserId).Select(group => group.FirstOrDefault()).ToList();
                    foreach (var item in engMgr)
                    {
                        vm.EngMgr += item == null ? "" : _context.AppUsers.Find(item.UserId).FullName + "  ";
                    }
                }

                var engUndertake = _db.OutsideBmedFlows.Where(r => r.DocId == DocId)
                                                          .Where(r => r.Cls.Contains("醫工承辦")).LastOrDefault();
                if (engUndertake != null)
                    vm.EngUndertake = engUndertake == null ? "" : _context.AppUsers.Find(engUndertake.UserId).FullName;
                else
                    vm.EngUndertake = "";

                var delivMgr = _db.OutsideBmedFlows.Where(r => r.DocId == DocId)
                                                       .Where(r => r.Cls.Contains("單位主管")).ToList();
                if (delivMgr.Count() != 0)
                {
                    delivMgr = delivMgr.GroupBy(e => e.UserId).Select(group => group.FirstOrDefault()).ToList();
                    foreach (var item in delivMgr)
                    {
                        vm.DelivMgr += item == null ? "" : _context.AppUsers.Find(item.UserId).FullName + "  ";
                    }
                }

               
                if (flow != null)
                {
                    if (flow.Status == "2")
                    {
                        vm.CloseDate = flow.Rtt;
                        AppUserModel u = _context.AppUsers.Find(flow.UserId);
                        if (u != null)
                        {
                            vm.DelivEmp = u.UserName;
                            vm.DelivEmpName = u.FullName;
                        }
                    }
                }

                /* Draw barcode and use Base64 to image to show barcode on view. */
                var barcodeString = repair.DocId.ToString();
                Zen.Barcode.Code128BarcodeDraw barcode1 = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                var barcodeImage = barcode1.Draw(barcodeString, 30);
                using (MemoryStream ms = new MemoryStream())
                {
                    barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();

                    ViewBag.Img = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
                }

            }
            if (printType == 1)   //一頁式列印(多簽核流程)
            {
                return View("PrintRepairDoc2", vm);
            }
            return View(vm);
        }

        public IActionResult ExportToExcel(string qtyDocId,   string qtyAssetName,
                                           string qtyDptId, string Date1, string Date2,
                                           string DateType, bool SearchAllDoc,
                                           string Vendor,string ClsUser,string qtyFlowType)
        {
            string docid = qtyDocId;
            //string ano = qtyAssetNo;
            //string acc = qtyAccDpt;
            string aname = qtyAssetName;
            string ftype = qtyFlowType;
            string dptid = qtyDptId; //字串null
            string qtyDate1 = Date1;
            string qtyDate2 = Date2;
            //string qtyDealStatus = DealStatus;
            //string qtyIsCharged = IsCharged;
            string qtyDateType = DateType;
            bool searchAllDoc = SearchAllDoc;
            //string qtyEngCode = EngCode;
            //string qtyTicketNo = TicketNo;
            string qtyVendor = Vendor;
            string qtyClsUser = ClsUser;//字串null

            DateTime applyDateFrom = DateTime.Now;
            DateTime applyDateTo = DateTime.Now;
            /* Dealing search by date. */
            if (qtyDate1 != null && qtyDate2 != null)// If 2 date inputs have been insert, compare 2 dates.
            {
                DateTime date1 = DateTime.Parse(qtyDate1);
                DateTime date2 = DateTime.Parse(qtyDate2).AddDays(1);
                int result = DateTime.Compare(date1, date2);
                if (result < 0)
                {
                    applyDateFrom = date1.Date;
                    applyDateTo = date2.Date;
                }
                else if (result == 0)
                {
                    applyDateFrom = date1.Date;
                    applyDateTo = date1.Date;
                }
                else
                {
                    applyDateFrom = date2.Date;
                    applyDateTo = date1.Date;
                }
            }
            else if (qtyDate1 == null && qtyDate2 != null)
            {
                applyDateFrom = new DateTime();
                applyDateTo = DateTime.Parse(qtyDate2).AddDays(1);
            }
            else if (qtyDate1 != null && qtyDate2 == null)
            {
                applyDateFrom = DateTime.Parse(qtyDate1);
                applyDateTo = DateTime.Now.AddDays(1);
            }


            List<OutsideBmedListModel> rv = new List<OutsideBmedListModel>();
            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            //var urLocation = new DepartmentModel(_context).GetUserLocation(ur);

            //
            // 依照使用者ID 搜尋需處理案件

            var rps = _db.OutsideBmedFlows
                .Where(n => n.UserId == ur.Id)
                .Join(_db.Instruments,
                d => d.DocId, f => f.DocId,
                               (d, f) => new
                               {
                                   signflow = d,
                                   signdata = f
                               });
            if (rps == null)
                return BadRequest("無資料");

            if (!string.IsNullOrEmpty(docid))   //表單編號
            {
                docid = docid.Trim();
                rps = rps.Where(v => v.signdata.DocId == docid);
            }

            if (!string.IsNullOrEmpty(dptid) && dptid != "null")   //申請部門
            {
                rps = rps.Where(v => v.signdata.UseUnit == dptid);
            }
            if (!string.IsNullOrEmpty(qtyVendor))   //廠商關鍵字
            {
                rps = rps.Where(v => v.signdata.Vendor.Contains(qtyVendor));
            }
            if (!string.IsNullOrEmpty(qtyClsUser) && qtyClsUser != "null")   //目前關卡人員
            {
                rps = rps.Where(r => r.signdata.ToUserId == Convert.ToInt32(qtyClsUser));
            }

            switch (ftype)
            {
                /* 與登入者相關且流程不在該登入者身上的文件 */
                case "流程中":
                    rps.Where(r => r.signflow.Status == "1" && r.signflow.UserId == ur.Id)
                        .Select(r => r.signflow.DocId).Distinct()
                        .Join(_db.OutsideBmedFlows.Where(f => f.Status == "?" && f.UserId != ur.Id),
                        r => r, f => f.DocId,
                        (r, f) => new
                        {
                            repair = r,
                            flow = f
                        })
                        .Join(_db.Instruments, m => m.repair, d => d.DocId,
                        (m, d) => new
                        {
                            repair = m.repair,
                            flow = m.flow,
                            repdtl = d
                        })
                        .ToList()
                        .ForEach(j => rv.Add(new OutsideBmedListModel
                        {
                            DocType = "外部醫療儀器使用申請",
                            Cls = j.flow.Cls,
                            DocId = j.flow.DocId,
                            UserName = j.flow.UserName,
                            Topic = j.flow.Opinion,
                            ApplyDate = j.repdtl.ApplyDate,
                            Rtt = j.flow.Rtt,
                            Status = "流程中",
                            Kind = ""
                        }));
                    break;
                /* 與登入者相關且結案的文件 */
                case "已結案":
                    /* Get all closed repair docs. */
                    var rf = rps.Where(f => f.signflow.Status == "2");

                    //if (userManager.IsInRole(User, "Admin") || userManager.IsInRole(User, "MedAdmin") ||
                    //    userManager.IsInRole(User, "Manager") || userManager.IsInRole(User, "MedEngineer"))
                    //{

                    //    /* If no other search values, search the docs belong the login engineer. */
                    //    if (userManager.IsInRole(User, "MedEngineer") && searchAllDoc == false)
                    //    {
                    //        rf = rf.Join(_db.OutsideBmedFlows.Where(f2 => f2.UserId == ur.Id),
                    //             f => f.DocId, f2 => f2.DocId, (f, f2) => f);
                    //    }
                    //}
                    //else /* If normal user, search the docs belong himself. */
                    //{
                    //    rf = rf.Join(_db.OutsideBmedFlows.Where(f2 => f2.UserId == ur.Id),
                    //         f => f.DocId, f2 => f2.DocId, (f, f2) => f);
                    //}

                    rf.Select(f => new
                    {
                        f.signdata.DocId,
                        f.signdata.UserId,
                        f.signflow.Status,
                        f.signflow.Cls,
                        f.signflow.Rtt
                    }).Distinct().Join(rps.DefaultIfEmpty(), f => f.DocId, r => r.signdata.DocId,
                    (f, r) => new
                    {
                        repair = r,
                        flow = f
                    })
                    .ToList()
                    .ForEach(j => rv.Add(new OutsideBmedListModel
                    {
                        DocType = "外部醫療儀器使用申請",
                        DocId = j.repair.signdata.DocId,
                        UserName = j.repair.signdata.UserName,
                        Topic = j.repair.signdata.Description,
                        ApplyDate = j.repair.signdata.ApplyDate,
                        Rtt = j.flow.Rtt,
                        Status = GetStatus(j.flow.Status),
                        Kind = "",
                        Cls = j.flow.Cls,
                        Model = j.repair.signdata.Model,
                        Serial = j.repair.signdata.Serial,
                        UseUnit = j.repair.signdata.UseUnit,
                        Label = j.repair.signdata.Label,
                        Name = j.repair.signdata.Name
                    }));
                    break;
                /* 與登入者相關且流程在該登入者身上的文件 */
                case "待簽核":
                    /* Get all dealing repair docs. */
                    rps.Where(f => f.signflow.Status == "?")
                       .ToList()
                        .ForEach(j => rv.Add(new OutsideBmedListModel
                        {
                            DocType = "外部醫療儀器使用申請",
                            DocId = j.signdata.DocId,
                            UserName = j.signdata.UserName,
                            Topic = j.signdata.Description,
                            ApplyDate = j.signdata.ApplyDate,
                            Rtt = j.signflow.Rtt,
                            Status = GetStatus(j.signflow.Status),
                            Kind = "",
                            Cls = j.signflow.Cls,
                            Model = j.signdata.Model,
                            Serial = j.signdata.Serial,
                            UseUnit = j.signdata.UseUnit,
                            Label = j.signdata.Label,
                            Name = j.signdata.Name
                        }));
                    break;
                /* 不分流程的所有案件 */
                case "請選擇":
                    /* Get all dealing repair docs. */
                    string[] ss = new string[] { "?", "2" };
                    rps.Where(r => ss.Contains(r.signflow.Status))
                    .ToList()
                    .ForEach(j => rv.Add(new OutsideBmedListModel
                    {
                        DocType = "外部醫療儀器使用申請",
                        DocId = j.signdata.DocId,
                        UserName = j.signdata.UserName,
                        Topic = j.signdata.Description,
                        ApplyDate = j.signdata.ApplyDate,
                        Rtt = j.signflow.Rtt,
                        Status = GetStatus(j.signflow.Status),
                        Kind = "",
                        Cls = j.signflow.Cls,
                        Model = j.signdata.Model,
                        Serial = j.signdata.Serial,
                        UseUnit = j.signdata.UseUnit,
                        Label = j.signdata.Label,
                        Name = j.signdata.Name
                    }));
                    break;

            };

            /* Search date by DateType.(ApplyDate) */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)
            {
                if (qtyDateType == "申請日")
                {
                    rv = rv.Where(v => v.ApplyDate >= applyDateFrom && v.ApplyDate <= applyDateTo).ToList();
                }
            }




            /* Search date by DateType. */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)
            {
                if (qtyDateType == "結案日")
                {
                    rv = rv
                        .Where(v => v.Status == "2")
                        .Where(v => v.ApplyDate >= applyDateFrom && v.ApplyDate <= applyDateTo).ToList();
                }

            }

            //ClosedXML的用法 先new一個Excel Workbook
            using (XLWorkbook workbook = new XLWorkbook())
            {
                //取得要塞入Excel內的資料
                var data = rv.Select(c => new {
                    c.DocType,
                    c.DocId,
                    c.ApplyDate,
                    AccDpt = c.UserName /*+ "(" + c.UserId + ")"*/,
                    //Asset = c.AssetName + "(" + c.AssetNo + ")",
                    c.Topic,
                    //Location = c.Location1 + c.Location2,
                    c.Rtt,
                    c.Status,
                    //c.UseDayFrom,
                    //c.UseDayTo,
                    c.UseUnit,
                    c.Name,
                    c.Model,
                    c.Serial,
                    c.Label,
                    c.Cls
                });

                //一個workbook內至少會有一個worksheet,並將資料Insert至這個位於A1這個位置上
                var ws = workbook.Worksheets.Add("sheet1", 1);

                //Title
                ws.Cell(1, 1).Value = "表單類別";
                ws.Cell(1, 2).Value = "表單編號";
                ws.Cell(1, 3).Value = "申請日期";
                ws.Cell(1, 4).Value = "申請人員";
                ws.Cell(1, 5).Value = "使用說明";
                ws.Cell(1, 6).Value = "抵達日期";
                ws.Cell(1, 7).Value = "處理狀態";
                //ws.Cell(1, 8).Value = "使用開始日期";
                //ws.Cell(1, 9).Value = "使用結束日期";
                ws.Cell(1, 8).Value = "使用部門";
                ws.Cell(1, 9).Value = "品名";
                ws.Cell(1, 10).Value = "型號";
                ws.Cell(1, 11).Value = "序號 ";
                ws.Cell(1, 12).Value = "廠牌";
                ws.Cell(1, 13).Value = "關卡人員";

                //如果是要塞入Query後的資料該資料一定要變成是data.AsEnumerable()
                ws.Cell(2, 1).InsertData(data);

                //因為是用Query的方式,這個地方要用串流的方式來存檔
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    //請注意 一定要加入這行,不然Excel會是空檔
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    //注意Excel的ContentType,是要用這個"application/vnd.ms-excel"
                    string fileName = "案件搜尋_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";
                    return this.File(memoryStream.ToArray(), "application/vnd.ms-excel", fileName);
                }
            }
        }

    }
}