using EDIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EDIS.Repositories;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using X.PagedList;
using System.Data;
using OfficeOpenXml;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private int pageSize = 50;

        public SearchController(ApplicationDbContext context,
                                IRepository<AppUserModel, int> userRepo,
                                CustomUserManager customUserManager,
                                CustomRoleManager customRoleManager)
        {
            _context = context;
            _userRepo = userRepo;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }

        /// <summary>
        /// The Index of searching all repair docs.
        /// </summary>
        /// <returns></returns>
        // GET: BMED/Search/RepIndex
        public IActionResult RepIndex()
        {
            List<SelectListItem> FlowlistItem = new List<SelectListItem>();
            FlowlistItem.Add(new SelectListItem { Text = "未結案", Value = "未結案" });
            FlowlistItem.Add(new SelectListItem { Text = "已結案", Value = "已結案" });
            ViewData["FLOWTYPE"] = new SelectList(FlowlistItem, "Value", "Text");

            /* 成本中心 & 申請部門的下拉選單資料 */
            var dptList = new[] { "K", "P", "C" };  //本院部門
            //var departments = _context.Departments.Where(d => dptList.Contains(d.Loc)).ToList();
            var departments = _context.Departments.ToList();
            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (var item in departments)
            {
                listItem.Add(new SelectListItem
                {
                    Text = item.Name_C + "(" + item.DptId + ")",    //show DptName(DptId)
                    Value = item.DptId
                });
            }

            ViewData["ACCDPT"] = new SelectList(listItem, "Value", "Text");
            ViewData["APPLYDPT"] = new SelectList(listItem, "Value", "Text");

            /* 處理狀態的下拉選單 */
            var dealStatuses = _context.BMEDDealStatuses.ToList();
            List<SelectListItem> listItem2 = new List<SelectListItem>();
            foreach (var item in dealStatuses)
            {
                listItem2.Add(new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Title
                });
            }
            ViewData["DealStatus"] = new SelectList(listItem2, "Value", "Text");

            /* 處理有無費用的下拉選單 */
            List<SelectListItem> listItem3 = new List<SelectListItem>();
            listItem3.Add(new SelectListItem { Text = "有", Value = "Y" });
            listItem3.Add(new SelectListItem { Text = "無", Value = "N" });
            ViewData["IsCharged"] = new SelectList(listItem3, "Value", "Text");

            /* 處理日期查詢的下拉選單 */
            List<SelectListItem> listItem4 = new List<SelectListItem>();
            listItem4.Add(new SelectListItem { Text = "申請日", Value = "申請日" });
            listItem4.Add(new SelectListItem { Text = "完工日", Value = "完工日" });
            listItem4.Add(new SelectListItem { Text = "結案日", Value = "結案日" });
            ViewData["DateType"] = new SelectList(listItem4, "Value", "Text", "申請日");

            /* 處理工程師查詢的下拉選單 */
            var engs = roleManager.GetUsersInRole("MedEngineer").ToList();
            List<SelectListItem> listItem5 = new List<SelectListItem>();
            foreach (string l in engs)
            {
                var u = _context.AppUsers.Where(r => r.UserName == l).FirstOrDefault();
                if (u != null)
                {
                    listItem5.Add(new SelectListItem
                    {
                        Text = u.FullName + "(" + u.UserName + ")",
                        Value = u.Id.ToString()
                    });
                }
            }
            ViewData["BMEDEngs"] = new SelectList(listItem5, "Value", "Text");
            /* 擷取該使用者單位底下所有人員 */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            var dptUsers = _context.AppUsers.Where(a => a.DptId == ur.DptId && a.Status == "Y").ToList();
            List<SelectListItem> dptMemberList = new List<SelectListItem>();
            foreach (var item in dptUsers)
            {
                dptMemberList.Add(new SelectListItem
                {
                    Text = item.FullName + "(" + item.UserName + ")",
                    Value = item.Id.ToString()
                });
            }
            ViewData["DptMembers"] = new SelectList(dptMemberList, "Value", "Text");
            /* 擷取所有人員 */
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var item in _context.AppUsers.Where(a => a.Status == "Y").ToList())
            {
                userList.Add(new SelectListItem
                {
                    Text = item.FullName + "(" + item.UserName + ")",
                    Value = item.Id.ToString()
                });
            }
            ViewData["BMEDUsers"] = new SelectList(userList, "Value", "Text");
            QryRepListData data = new QryRepListData();

            return View(data);
        }

        public IActionResult MedTransRdIdx()
        {
            List<SelectListItem> FlowlistItem = new List<SelectListItem>();
            FlowlistItem.Add(new SelectListItem { Text = "送件", Value = "送件" });
            FlowlistItem.Add(new SelectListItem { Text = "取件", Value = "取件" });
            ViewData["STATUS"] = new SelectList(FlowlistItem, "Value", "Text");
            /* 成本中心 & 申請部門的下拉選單資料 */
            var dptList = new[] { "K", "P", "C" };  //本院部門
            var departments = _context.Departments.Where(d => dptList.Contains(d.Loc)).ToList();
            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (var item in departments)
            {
                listItem.Add(new SelectListItem
                {
                    Text = item.Name_C + "(" + item.DptId + ")",    //show DptName(DptId)
                    Value = item.DptId
                });
            }

            ViewData["ACCDPT"] = new SelectList(listItem, "Value", "Text");
            ViewData["APPLYDPT"] = new SelectList(listItem, "Value", "Text");

            MedTransRdQModel data = new MedTransRdQModel();

            return View(data);
        }

        /// <summary>
        /// The Index of searching all keep docs.
        /// </summary>
        /// <returns></returns>
        // GET: BMED/Search/KeepIndex
        public IActionResult KeepIndex()
        {
            List<SelectListItem> FlowlistItem = new List<SelectListItem>();
            FlowlistItem.Add(new SelectListItem { Text = "未結案", Value = "未結案" });
            FlowlistItem.Add(new SelectListItem { Text = "已結案", Value = "已結案" });
            ViewData["FLOWTYPE"] = new SelectList(FlowlistItem, "Value", "Text");

            /* 成本中心 & 申請部門的下拉選單資料 */
            var dptList = new[] { "K", "P", "C" };  //本院部門
            //var departments = _context.Departments.Where(d => dptList.Contains(d.Loc)).ToList();
            var departments = _context.Departments.ToList();
            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (var item in departments)
            {
                listItem.Add(new SelectListItem
                {
                    Text = item.Name_C + "(" + item.DptId + ")",    //show DptName(DptId)
                    Value = item.DptId
                });
            }

            ViewData["ACCDPT"] = new SelectList(listItem, "Value", "Text");
            ViewData["APPLYDPT"] = new SelectList(listItem, "Value", "Text");

            /* 處理保養狀態的下拉選單 */
            var keepResults = _context.BMEDKeepResults.ToList();
            List<SelectListItem> listItem2 = new List<SelectListItem>();
            foreach (var item in keepResults)
            {
                listItem2.Add(new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                });
            }
            ViewData["KeepResults"] = new SelectList(listItem2, "Value", "Text");

            /* 處理有無費用的下拉選單 */
            List<SelectListItem> listItem3 = new List<SelectListItem>();
            listItem3.Add(new SelectListItem { Text = "有", Value = "Y" });
            listItem3.Add(new SelectListItem { Text = "無", Value = "N" });
            ViewData["IsCharged"] = new SelectList(listItem3, "Value", "Text");

            /* 處理日期查詢的下拉選單 */
            List<SelectListItem> listItem4 = new List<SelectListItem>();
            listItem4.Add(new SelectListItem { Text = "送單日", Value = "送單日" });
            listItem4.Add(new SelectListItem { Text = "完工日", Value = "完工日" });
            listItem4.Add(new SelectListItem { Text = "結案日", Value = "結案日" });
            ViewData["DateType"] = new SelectList(listItem4, "Value", "Text", "申請日");

            /* 處理工程師查詢的下拉選單 */
            var engs = roleManager.GetUsersInRole("MedEngineer").ToList();
            List<SelectListItem> listItem5 = new List<SelectListItem>();
            foreach (string l in engs)
            {
                var u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                if (u != null)
                {
                    listItem5.Add(new SelectListItem
                    {
                        Text = u.FullName + "(" + u.UserName + ")",
                        Value = u.Id.ToString()
                    });
                }
            }
            ViewData["BMEDEngs"] = new SelectList(listItem5, "Value", "Text");

            /* 處理保養方式的下拉選單 */
            List<SelectListItem> listItem6 = new List<SelectListItem>();
            listItem6.Add(new SelectListItem { Text = "自行", Value = "自行" });
            listItem6.Add(new SelectListItem { Text = "委外", Value = "委外" });
            listItem6.Add(new SelectListItem { Text = "租賃", Value = "租賃" });
            listItem6.Add(new SelectListItem { Text = "保固", Value = "保固" });
            ViewData["BMEDKeepInOut"] = new SelectList(listItem6, "Value", "Text", "");

            /* 擷取所有人員 */
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var item in _context.AppUsers.Where(a => a.Status == "Y").ToList())
            {
                userList.Add(new SelectListItem
                {
                    Text = item.FullName + "(" + item.UserName + ")",
                    Value = item.Id.ToString()
                });
            }
            ViewData["BMEDUsers"] = new SelectList(userList, "Value", "Text");

            QryKeepListData data = new QryKeepListData();

            return View(data);
        }

        /// <summary>
        /// The Index of searching all delivery docs.
        /// </summary>
        /// <returns></returns>
        // GET: BMED/Search/DelivIndex
        public IActionResult DelivIndex()
        {
            //
            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "所有", Value = "所有" });
            listItem.Add(new SelectListItem { Text = "已處理", Value = "已處理" });
            listItem.Add(new SelectListItem { Text = "已結案", Value = "已結案" });
            ViewData["FLOWTYP"] = new SelectList(listItem, "Value", "Text", "所有");
            //
            List<SelectListItem> listItem2 = new List<SelectListItem>();
            SelectListItem li;
            _context.Departments.ToList()
                .ForEach(d =>
                {
                    li = new SelectListItem();
                    li.Text = d.Name_C;
                    li.Value = d.DptId;
                    listItem2.Add(li);

                });
            ViewData["ACCDPT"] = new SelectList(listItem2, "Value", "Text");
            if (userManager.IsInRole(User, "Usual"))
            {
                //listItem2.Clear();
                //AppUserModel u = _context.AppUsers.Find(WebSecurity.CurrentUserId);
                //if (u != null)
                //{
                //    li = new SelectListItem();
                //    li.Text = _context.Departments.Find(u.DptId).Name_C;
                //    li.Value = u.DptId;
                //    listItem2.Add(li);
                //}
            }
            ViewData["APPLYDPT"] = new SelectList(listItem2, "Value", "Text");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetMedTransRdQList(MedTransRdQModel qdata)
        {
            List<MedTransRd> rv = new List<MedTransRd>();
            //
            HttpClient client = new HttpClient();
            var str = JsonConvert.SerializeObject(qdata);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://dms.cch.org.tw/CchBmedWebApi/");
            string url = "api/MedTransRds"; //BmedWebApi
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = await client.GetAsync(url);
            HttpResponseMessage response = await client.PostAsync(url, content);
            string rstr = "";
            if (response.IsSuccessStatusCode)
            {
                rstr = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(rstr))
                {
                    rv.AddRange(JsonConvert.DeserializeObject<List<MedTransRd>>(rstr));
                }
            }
            client.Dispose();

            return View("MedTransRdQList", rv);
        }
        /// <summary>
        /// Get the query result list of repair docs.
        /// </summary>
        /// <param name="qdata"></param>
        /// <returns></returns>
        // POST: BMED/Search/GetRepQryList
        [HttpPost]
        public IActionResult GetRepQryList(QryRepListData qdata, int page = 1)
        {
            TempData["qry"] = JsonConvert.SerializeObject(qdata);
            string docid = qdata.BMEDqtyDOCID;
            string ano = qdata.BMEDqtyASSETNO;
            string acc = qdata.BMEDqtyACCDPT;
            string aname = qdata.BMEDqtyASSETNAME;
            string ftype = qdata.BMEDqtyFLOWTYPE;
            string dptid = qdata.BMEDqtyDPTID;
            string qtyDate1 = qdata.BMEDqtyApplyDateFrom;
            string qtyDate2 = qdata.BMEDqtyApplyDateTo;
            string qtyIsCharged = qdata.BMEDqtyIsCharged;
            string qtyDealStatus = qdata.BMEDqtyDealStatus;
            string qtyDateType = qdata.BMEDqtyDateType;
            string qtyEngCode = qdata.BMEDqtyEngCode;
            string qtyTicketNo = qdata.BMEDqtyTicketNo;
            string qtyVendor = qdata.BMEDqtyVendor;
            string qtyTroubledes = qdata.BMEDqtyTROUBLEDES;
            string qtyUserId = qdata.BMEDqtyUserId;
            string qtyClsUser = qdata.BMEDqtyClsUser;
            DateTime applyDateFrom = DateTime.Now;
            DateTime applyDateTo = DateTime.Now;
            /* Dealing search by date. */
            if (qtyDate1 != null && qtyDate2 != null)// If 2 date inputs have been insert, compare 2 dates.
            {
                DateTime date1 = DateTime.Parse(qtyDate1);
                DateTime date2 = DateTime.Parse(qtyDate2);
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
                applyDateFrom = DateTime.Parse(qtyDate2);
                applyDateTo = DateTime.Parse(qtyDate2);
            }
            else if (qtyDate1 != null && qtyDate2 == null)
            {
                applyDateFrom = DateTime.Parse(qtyDate1);
                applyDateTo = DateTime.Parse(qtyDate1);
            }


            List<RepairSearchListVModel> rv = new List<RepairSearchListVModel>();

            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            var urLocation = new DepartmentModel(_context).GetUserLocation(ur);
            //
            // 依照院區搜尋Repair主檔
            var rps = _context.BMEDRepairs.Where(r => r.Loc == urLocation);
            //var repairFlows = _context.BMEDRepairFlows.AsQueryable();
            //var repairDtls = _context.BMEDRepairDtls.AsQueryable();
            //var departments = _context.Departments.AsQueryable();
            if (!string.IsNullOrEmpty(docid))   //表單編號
            {
                docid = docid.Trim();
                rps = rps.Where(v => v.DocId == docid);
            }
            if (!string.IsNullOrEmpty(ano))     //財產編號
            {
                rps = rps.Where(v => v.AssetNo == ano);
            }
            if (!string.IsNullOrEmpty(dptid))   //所屬部門編號
            {
                rps = rps.Where(v => v.DptId == dptid);
            }
            if (!string.IsNullOrEmpty(acc))     //成本中心
            {
                rps = rps.Where(v => v.AccDpt == acc);
            }
            if (!string.IsNullOrEmpty(aname))   //財產名稱
            {
                rps = rps.Where(v => v.AssetName != null)
                         .Where(v => v.AssetName.Contains(aname));
            }
            if (!string.IsNullOrEmpty(qtyTroubledes))   //故障描述
            {
                rps = rps.Where(v => v.TroubleDes != null)
                         .Where(v => v.TroubleDes.Contains(qtyTroubledes));
            }
            if (!string.IsNullOrEmpty(qtyUserId))     //申請人
            {
                int uid = Convert.ToInt32(qtyUserId);
                rps = rps.Where(v => v.UserId == uid);
            }
            if (!string.IsNullOrEmpty(qtyTicketNo))   //發票號碼
            {
                qtyTicketNo = qtyTicketNo.ToUpper();
                rps = rps.Join(_context.BMEDRepairCosts.Where(c => c.TicketDtlNo == qtyTicketNo), r => r.DocId, c => c.DocId,
                    (r, c) => r).Distinct();
                //var resultDocIds = _context.BMEDRepairCosts.Include(rc => rc.TicketDtl)
                //                                           .Where(rc => rc.TicketDtl.TicketDtlNo == qtyTicketNo)
                //                                           .Select(rc => rc.DocId).Distinct();
                //rps = (from r in rps
                //       where resultDocIds.Any(val => r.DocId.Contains(val))
                //       select r);
            }
            if (!string.IsNullOrEmpty(qtyVendor))   //廠商關鍵字
            {
                var resultDocIds = _context.BMEDRepairCosts.Include(rc => rc.TicketDtl)
                                                           .Where(rc => rc.VendorName.Contains(qtyVendor))
                                                           .Select(rc => rc.DocId).Distinct();
                rps = (from r in rps
                       where resultDocIds.Any(val => r.DocId.Contains(val))
                       select r);
            }
            if (!string.IsNullOrEmpty(qtyEngCode))     //負責工程師
            {
                rps = rps.Where(v => v.EngId == Convert.ToInt32(qtyEngCode));
            }
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)  //申請日
            {
                if (qtyDateType == "申請日")
                {
                    rps = rps.Where(v => v.ApplyDate >= applyDateFrom && v.ApplyDate <= applyDateTo);
                }
            }
            if (!string.IsNullOrEmpty(ftype))   //流程狀態
            {
                switch (ftype)
                {
                    case "未結案":
                        var repairFlows = rps.Join(_context.BMEDRepairFlows.Where(f => f.Status == "?"), r => r.DocId, f => f.DocId,
                            (r, f) => new { repair = r, flow = f });
                        repairFlows.Join(_context.BMEDRepairDtls, m => m.repair.DocId, d => d.DocId,
                    (m, d) => new
                    {
                        repair = m.repair,
                        flow = m.flow,
                        repdtl = d
                    })
                    .Join(_context.Departments, j => j.repair.AccDpt, d => d.DptId,
                    (j, d) => new
                    {
                        repair = j.repair,
                        flow = j.flow,
                        repdtl = j.repdtl,
                        dpt = d
                    }).Join(_context.Departments, j => j.repair.AccDpt, d => d.DptId,
                    (j, d) => new
                    {
                        repair = j.repair,
                        flow = j.flow,
                        repdtl = j.repdtl,
                        dpt = d
                    }).ToList()
                      .ForEach(j => rv.Add(new RepairSearchListVModel
                    {
                        DocType = "請修",
                        RepType = j.repair.RepType,
                        DocId = j.repair.DocId,
                        ApplyDate = j.repair.ApplyDate,
                        PlaceLoc = j.repair.PlaceLoc,
                        ApplyDpt = j.repair.DptId,
                        AccDpt = j.repair.AccDpt,
                        AccDptName = j.dpt.Name_C,
                        TroubleDes = j.repair.TroubleDes,
                        DealState = _context.BMEDDealStatuses.Find(j.repdtl.DealState).Title,
                        DealDes = j.repdtl.DealDes,
                        Cost = j.repdtl.Cost,
                        Days = DateTime.Now.Subtract(j.repair.ApplyDate).Days,
                        Flg = j.flow.Status,
                        FlowUid = j.flow.UserId,
                        FlowCls = j.flow.Cls,
                        FlowUidName = _context.AppUsers.Find(j.flow.UserId).FullName,
                        EndDate = j.repdtl.EndDate,
                        CloseDate = j.repdtl.CloseDate,
                        IsCharged = j.repdtl.IsCharged,
                        IsPurchase = j.repair.IsPurchased,
                        repdata = j.repair
                    }));
                        break;
                    case "已結案":
                        var repairFlows2 = rps.Join(_context.BMEDRepairFlows.Where(f => f.Status == "2"), r => r.DocId, f => f.DocId,
                            (r, f) => new { repair = r, flow = f });
                        repairFlows2.Join(_context.BMEDRepairDtls, m => m.repair.DocId, d => d.DocId,
                    (m, d) => new
                    {
                        repair = m.repair,
                        flow = m.flow,
                        repdtl = d
                    })
                    .Join(_context.Departments, j => j.repair.AccDpt, d => d.DptId,
                    (j, d) => new
                    {
                        repair = j.repair,
                        flow = j.flow,
                        repdtl = j.repdtl,
                        dpt = d
                    }).ToList()
                    .ForEach(j => rv.Add(new RepairSearchListVModel
                    {
                        DocType = "請修",
                        RepType = j.repair.RepType,
                        DocId = j.repair.DocId,
                        ApplyDate = j.repair.ApplyDate,
                        PlaceLoc = j.repair.PlaceLoc,
                        ApplyDpt = j.repair.DptId,
                        AccDpt = j.repair.AccDpt,
                        AccDptName = j.dpt.Name_C,
                        TroubleDes = j.repair.TroubleDes,
                        DealState = _context.BMEDDealStatuses.Find(j.repdtl.DealState).Title,
                        DealDes = j.repdtl.DealDes,
                        Cost = j.repdtl.Cost,
                        Days = DateTime.Now.Subtract(j.repair.ApplyDate).Days,
                        Flg = j.flow.Status,
                        FlowUid = j.flow.UserId,
                        FlowCls = j.flow.Cls,
                        FlowUidName = _context.AppUsers.Find(j.flow.UserId).FullName,
                        EndDate = j.repdtl.EndDate,
                        CloseDate = j.repdtl.CloseDate,
                        IsCharged = j.repdtl.IsCharged,
                        IsPurchase = j.repair.IsPurchased,
                        repdata = j.repair
                    }));
                        break;
                }
            }
            //else
            //{
            //    repairFlows = repairFlows.GroupBy(f => f.DocId).Where(group => group.Last().Status != "3")
            //                                                   .Select(group => group.Last());
            //}
            if (!string.IsNullOrEmpty(qtyDealStatus))   //處理狀態
            {
                rv = rv.Where(r => r.DealState == qtyDealStatus).ToList();
            }
            if (!string.IsNullOrEmpty(qtyIsCharged))    //有無費用
            {
                rv = rv.Where(r => r.IsCharged == qtyIsCharged).ToList();
            }
            if (!string.IsNullOrEmpty(qtyClsUser))   //目前關卡人員
            {
                rv = rv.Where(r => r.FlowUid == Convert.ToInt32(qtyClsUser)).ToList();
            }

            /* If no search result. */
            if (rv.Count() == 0)
            {
                return PartialView("RepQryList", rv.ToPagedList(page, pageSize));
            }
            
            /* 設備編號"有"、"無"的對應，"有"讀取table相關data，"無"只顯示申請人輸入的設備名稱 */
            foreach (var item in rv)
            {
                var repairDoc = _context.BMEDRepairs.Find(item.DocId);
                if (repairDoc.AssetNo != null)
                {
                    var asset = _context.BMEDAssets.Where(a => a.AssetNo == repairDoc.AssetNo).FirstOrDefault();
                    if (asset != null)
                    {
                        item.AssetNo = asset.AssetNo;
                        item.AssetName = asset.Cname;
                        item.Brand = asset.Brand;
                        item.Type = asset.Type;
                    }
                }
                else
                {
                    item.AssetName = repairDoc.AssetName;
                }
                // 檢查報廢案件是否已經請購
                //if (item.DealState == "報廢")
                //{
                //    HttpClient client = new HttpClient();
                //    client.BaseAddress = new Uri("http://dms.cch.org.tw/");
                //    string url = "Cchwebapi/api/purchase?docid=" + item.DocId;
                //    client.DefaultRequestHeaders.Accept.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(
                //        new MediaTypeWithQualityHeaderValue("application/json"));
                //    HttpResponseMessage response = await client.GetAsync(url);
                //    string rstr = "";
                //    if (response.IsSuccessStatusCode)
                //    {
                //        rstr = await response.Content.ReadAsStringAsync();
                //        if (rstr == "true")
                //        {
                //            item.IsPurchase = "Y";
                //        }
                //    }
                //    client.Dispose();
                //}
            }

            /* Search date by DateType. */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)
            {
                if (qtyDateType == "結案日")
                {
                    rv = rv.Where(v => v.CloseDate >= applyDateFrom && v.CloseDate <= applyDateTo).ToList();
                }
                else if (qtyDateType == "完工日")
                {
                    rv = rv.Where(v => v.EndDate >= applyDateFrom && v.EndDate <= applyDateTo).ToList();
                }
            }

            /* Sorting search result. */
            if (rv.Count() != 0)
            {
                if (qtyDateType == "結案日")
                {
                    rv = rv.OrderByDescending(r => r.CloseDate).ThenByDescending(r => r.DocId).ToList();
                }
                else if (qtyDateType == "完工日")
                {
                    rv = rv.OrderByDescending(r => r.EndDate).ThenByDescending(r => r.DocId).ToList();
                }
                else
                {
                    rv = rv.OrderByDescending(r => r.ApplyDate).ThenByDescending(r => r.DocId).ToList();
                }
            }
            //
            if (rv.ToPagedList(page, pageSize).Count <= 0)
                return PartialView("RepQryList", rv.ToPagedList(1, pageSize));
            return PartialView("RepQryList", rv.ToPagedList(page, pageSize));
            //return View("RepQryList", rv);
        }

        public List<RepairSearchListVModel> GetRepQryData(QryRepListData qdata)
        {
            string docid = qdata.BMEDqtyDOCID;
            string ano = qdata.BMEDqtyASSETNO;
            string acc = qdata.BMEDqtyACCDPT;
            string aname = qdata.BMEDqtyASSETNAME;
            string ftype = qdata.BMEDqtyFLOWTYPE;
            string dptid = qdata.BMEDqtyDPTID;
            string qtyDate1 = qdata.BMEDqtyApplyDateFrom;
            string qtyDate2 = qdata.BMEDqtyApplyDateTo;
            string qtyIsCharged = qdata.BMEDqtyIsCharged;
            string qtyDealStatus = qdata.BMEDqtyDealStatus;
            string qtyDateType = qdata.BMEDqtyDateType;
            string qtyEngCode = qdata.BMEDqtyEngCode;
            string qtyTicketNo = qdata.BMEDqtyTicketNo;
            string qtyVendor = qdata.BMEDqtyVendor;
            string qtyTroubledes = qdata.BMEDqtyTROUBLEDES;
            string qtyUserId = qdata.BMEDqtyUserId;
            string qtyClsUser = qdata.BMEDqtyClsUser;
            DateTime applyDateFrom = DateTime.Now;
            DateTime applyDateTo = DateTime.Now;
            /* Dealing search by date. */
            if (qtyDate1 != null && qtyDate2 != null)// If 2 date inputs have been insert, compare 2 dates.
            {
                DateTime date1 = DateTime.Parse(qtyDate1);
                DateTime date2 = DateTime.Parse(qtyDate2);
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
                applyDateFrom = DateTime.Parse(qtyDate2);
                applyDateTo = DateTime.Parse(qtyDate2);
            }
            else if (qtyDate1 != null && qtyDate2 == null)
            {
                applyDateFrom = DateTime.Parse(qtyDate1);
                applyDateTo = DateTime.Parse(qtyDate1);
            }


            List<RepairSearchListVModel> rv = new List<RepairSearchListVModel>();

            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            var urLocation = new DepartmentModel(_context).GetUserLocation(ur);
            //
            // 依照院區搜尋Repair主檔
            var rps = _context.BMEDRepairs.Where(r => r.Loc == urLocation);
            //var repairFlows = _context.BMEDRepairFlows.AsQueryable();
            //var repairDtls = _context.BMEDRepairDtls.AsQueryable();
            //var departments = _context.Departments.AsQueryable();
            if (!string.IsNullOrEmpty(docid))   //表單編號
            {
                docid = docid.Trim();
                rps = rps.Where(v => v.DocId == docid);
            }
            if (!string.IsNullOrEmpty(ano))     //財產編號
            {
                rps = rps.Where(v => v.AssetNo == ano);
            }
            if (!string.IsNullOrEmpty(dptid))   //所屬部門編號
            {
                rps = rps.Where(v => v.DptId == dptid);
            }
            if (!string.IsNullOrEmpty(acc))     //成本中心
            {
                rps = rps.Where(v => v.AccDpt == acc);
            }
            if (!string.IsNullOrEmpty(aname))   //財產名稱
            {
                rps = rps.Where(v => v.AssetName != null)
                         .Where(v => v.AssetName.Contains(aname));
            }
            if (!string.IsNullOrEmpty(qtyTroubledes))   //故障描述
            {
                rps = rps.Where(v => v.TroubleDes != null)
                         .Where(v => v.TroubleDes.Contains(qtyTroubledes));
            }
            if (!string.IsNullOrEmpty(qtyUserId))     //申請人
            {
                int uid = Convert.ToInt32(qtyUserId);
                rps = rps.Where(v => v.UserId == uid);
            }
            if (!string.IsNullOrEmpty(qtyTicketNo))   //發票號碼
            {
                qtyTicketNo = qtyTicketNo.ToUpper();
                rps = rps.Join(_context.BMEDRepairCosts.Where(c => c.TicketDtlNo == qtyTicketNo), r => r.DocId, c => c.DocId,
                    (r, c) => r).Distinct();
                //var resultDocIds = _context.BMEDRepairCosts.Include(rc => rc.TicketDtl)
                //                                           .Where(rc => rc.TicketDtl.TicketDtlNo == qtyTicketNo)
                //                                           .Select(rc => rc.DocId).Distinct();
                //rps = (from r in rps
                //       where resultDocIds.Any(val => r.DocId.Contains(val))
                //       select r);
            }
            if (!string.IsNullOrEmpty(qtyVendor))   //廠商關鍵字
            {
                var resultDocIds = _context.BMEDRepairCosts.Include(rc => rc.TicketDtl)
                                                           .Where(rc => rc.VendorName.Contains(qtyVendor))
                                                           .Select(rc => rc.DocId).Distinct();
                rps = (from r in rps
                       where resultDocIds.Any(val => r.DocId.Contains(val))
                       select r);
            }
            if (!string.IsNullOrEmpty(qtyEngCode))     //負責工程師
            {
                rps = rps.Where(v => v.EngId == Convert.ToInt32(qtyEngCode));
            }
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)  //申請日
            {
                if (qtyDateType == "申請日")
                {
                    rps = rps.Where(v => v.ApplyDate >= applyDateFrom && v.ApplyDate <= applyDateTo);
                }
            }
            if (!string.IsNullOrEmpty(ftype))   //流程狀態
            {
                switch (ftype)
                {
                    case "未結案":
                        var repairFlows = rps.Join(_context.BMEDRepairFlows.Where(f => f.Status == "?"), r => r.DocId, f => f.DocId,
                            (r, f) => new { repair = r, flow = f });
                        repairFlows.Join(_context.BMEDRepairDtls, m => m.repair.DocId, d => d.DocId,
                    (m, d) => new
                    {
                        repair = m.repair,
                        flow = m.flow,
                        repdtl = d
                    })
                    .Join(_context.Departments, j => j.repair.AccDpt, d => d.DptId,
                    (j, d) => new
                    {
                        repair = j.repair,
                        flow = j.flow,
                        repdtl = j.repdtl,
                        dpt = d
                    }).Join(_context.Departments, j => j.repair.AccDpt, d => d.DptId,
                    (j, d) => new
                    {
                        repair = j.repair,
                        flow = j.flow,
                        repdtl = j.repdtl,
                        dpt = d
                    }).ToList()
                      .ForEach(j => rv.Add(new RepairSearchListVModel
                      {
                          DocType = "請修",
                          RepType = j.repair.RepType,
                          DocId = j.repair.DocId,
                          ApplyDate = j.repair.ApplyDate,
                          PlaceLoc = j.repair.PlaceLoc,
                          ApplyDpt = j.repair.DptId,
                          AccDpt = j.repair.AccDpt,
                          AccDptName = j.dpt.Name_C,
                          TroubleDes = j.repair.TroubleDes,
                          DealState = _context.BMEDDealStatuses.Find(j.repdtl.DealState).Title,
                          DealDes = j.repdtl.DealDes,
                          Cost = j.repdtl.Cost,
                          Days = DateTime.Now.Subtract(j.repair.ApplyDate).Days,
                          Flg = j.flow.Status,
                          FlowUid = j.flow.UserId,
                          FlowCls = j.flow.Cls,
                          FlowUidName = _context.AppUsers.Find(j.flow.UserId).FullName,
                          EndDate = j.repdtl.EndDate,
                          CloseDate = j.repdtl.CloseDate,
                          IsCharged = j.repdtl.IsCharged,
                          IsPurchase = j.repair.IsPurchased,
                          repdata = j.repair
                      }));
                        break;
                    case "已結案":
                        var repairFlows2 = rps.Join(_context.BMEDRepairFlows.Where(f => f.Status == "2"), r => r.DocId, f => f.DocId,
                            (r, f) => new { repair = r, flow = f });
                        repairFlows2.Join(_context.BMEDRepairDtls, m => m.repair.DocId, d => d.DocId,
                    (m, d) => new
                    {
                        repair = m.repair,
                        flow = m.flow,
                        repdtl = d
                    })
                    .Join(_context.Departments, j => j.repair.AccDpt, d => d.DptId,
                    (j, d) => new
                    {
                        repair = j.repair,
                        flow = j.flow,
                        repdtl = j.repdtl,
                        dpt = d
                    }).ToList()
                    .ForEach(j => rv.Add(new RepairSearchListVModel
                    {
                        DocType = "請修",
                        RepType = j.repair.RepType,
                        DocId = j.repair.DocId,
                        ApplyDate = j.repair.ApplyDate,
                        PlaceLoc = j.repair.PlaceLoc,
                        ApplyDpt = j.repair.DptId,
                        AccDpt = j.repair.AccDpt,
                        AccDptName = j.dpt.Name_C,
                        TroubleDes = j.repair.TroubleDes,
                        DealState = _context.BMEDDealStatuses.Find(j.repdtl.DealState).Title,
                        DealDes = j.repdtl.DealDes,
                        Cost = j.repdtl.Cost,
                        Days = DateTime.Now.Subtract(j.repair.ApplyDate).Days,
                        Flg = j.flow.Status,
                        FlowUid = j.flow.UserId,
                        FlowCls = j.flow.Cls,
                        FlowUidName = _context.AppUsers.Find(j.flow.UserId).FullName,
                        EndDate = j.repdtl.EndDate,
                        CloseDate = j.repdtl.CloseDate,
                        IsCharged = j.repdtl.IsCharged,
                        IsPurchase = j.repair.IsPurchased,
                        repdata = j.repair
                    }));
                        break;
                }
            }
            if (!string.IsNullOrEmpty(qtyDealStatus))   //處理狀態
            {
                rv = rv.Where(r => r.DealState == qtyDealStatus).ToList();
            }
            if (!string.IsNullOrEmpty(qtyIsCharged))    //有無費用
            {
                rv = rv.Where(r => r.IsCharged == qtyIsCharged).ToList();
            }
            if (!string.IsNullOrEmpty(qtyClsUser))   //目前關卡人員
            {
                rv = rv.Where(r => r.FlowUid == Convert.ToInt32(qtyClsUser)).ToList();
            }

            /* 設備編號"有"、"無"的對應，"有"讀取table相關data，"無"只顯示申請人輸入的設備名稱 */
            foreach (var item in rv)
            {
                var repairDoc = _context.BMEDRepairs.Find(item.DocId);
                if (repairDoc.AssetNo != null)
                {
                    var asset = _context.BMEDAssets.Where(a => a.AssetNo == repairDoc.AssetNo).FirstOrDefault();
                    if (asset != null)
                    {
                        item.AssetNo = asset.AssetNo;
                        item.AssetName = asset.Cname;
                        item.Brand = asset.Brand;
                        item.Type = asset.Type;
                    }
                }
                else
                {
                    item.AssetName = repairDoc.AssetName;
                }
               
            }

            /* Search date by DateType. */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)
            {
                if (qtyDateType == "結案日")
                {
                    rv = rv.Where(v => v.CloseDate >= applyDateFrom && v.CloseDate <= applyDateTo).ToList();
                }
                else if (qtyDateType == "完工日")
                {
                    rv = rv.Where(v => v.EndDate >= applyDateFrom && v.EndDate <= applyDateTo).ToList();
                }
            }

            /* Sorting search result. */
            if (rv.Count() != 0)
            {
                if (qtyDateType == "結案日")
                {
                    rv = rv.OrderByDescending(r => r.CloseDate).ThenByDescending(r => r.DocId).ToList();
                }
                else if (qtyDateType == "完工日")
                {
                    rv = rv.OrderByDescending(r => r.EndDate).ThenByDescending(r => r.DocId).ToList();
                }
                else
                {
                    rv = rv.OrderByDescending(r => r.ApplyDate).ThenByDescending(r => r.DocId).ToList();
                }
            }
            //
            return rv;
        }
        public IActionResult ExcelQryRepair(QryRepListData v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("請修類別");
            dt.Columns.Add("表單編號");
            dt.Columns.Add("申請日期");
            dt.Columns.Add("成本中心名稱");
            dt.Columns.Add("財產編號");
            dt.Columns.Add("儀器名稱");
            dt.Columns.Add("請修地點");
            dt.Columns.Add("故障描述");
            dt.Columns.Add("處理狀態");
            dt.Columns.Add("處理描述");
            dt.Columns.Add("天數");
            dt.Columns.Add("完工日期");
            dt.Columns.Add("文件狀態");
            dt.Columns.Add("關卡人員");
            List<RepairSearchListVModel> mv = GetRepQryData(v);
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.RepType;
                dw[1] = m.DocId;
                dw[2] = m.ApplyDate;
                dw[3] = m.AccDptName;
                dw[4] = m.AssetNo;
                dw[5] = m.AssetName;
                dw[6] = m.PlaceLoc;
                dw[7] = m.TroubleDes;
                dw[8] = m.DealState;
                dw[9] = m.DealDes;
                dw[10] = m.Days;
                dw[11] = m.EndDate;
                dw[12] = m.Flg == "2" ? "已結案" : "未結案";
                dw[13] = m.FlowUidName;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("全院查詢維修清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "QryRepairData.xlsx"
            );
        }
        /// <summary>
        /// Get the query result list of keep docs.
        /// </summary>
        /// <param name="qdata"></param>
        /// <returns></returns>
        // POST: BMED/Search/GetKeepQryList
        [HttpPost]
        public IActionResult GetKeepQryList(QryKeepListData qdata, int page = 1)
        {
            string docid = qdata.BMEDKqtyDOCID;
            string ano = qdata.BMEDKqtyASSETNO;
            string acc = qdata.BMEDKqtyACCDPT;
            string aname = qdata.BMEDKqtyASSETNAME;
            string ftype = qdata.BMEDKqtyFLOWTYPE;
            string dptid = qdata.BMEDKqtyDPTID;
            string qtyDate1 = qdata.BMEDKqtyApplyDateFrom;
            string qtyDate2 = qdata.BMEDKqtyApplyDateTo;
            string qtyKeepResult = qdata.BMEDKqtyKeepResult;
            string qtyIsCharged = qdata.BMEDKqtyIsCharged;
            string qtyDateType = qdata.BMEDKqtyDateType;
            bool searchAllDoc = qdata.BMEDKqtySearchAllDoc;
            string qtyEngCode = qdata.BMEDKqtyEngCode;
            string qtyTicketNo = qdata.BMEDKqtyTicketNo;
            string qtyVendor = qdata.BMEDKqtyVendor;
            string qtyClsUser = qdata.BMEDKqtyClsUser;
            string qtyInOut = qdata.BMEDKInOut;
            TempData["qry"] = qdata;
            DateTime applyDateFrom = DateTime.Now;
            DateTime applyDateTo = DateTime.Now;
            /* Dealing search by date. */
            if (qtyDate1 != null && qtyDate2 != null)// If 2 date inputs have been insert, compare 2 dates.
            {
                DateTime date1 = DateTime.Parse(qtyDate1);
                DateTime date2 = DateTime.Parse(qtyDate2);
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
                applyDateFrom = DateTime.Parse(qtyDate2);
                applyDateTo = DateTime.Parse(qtyDate2);
            }
            else if (qtyDate1 != null && qtyDate2 == null)
            {
                applyDateFrom = DateTime.Parse(qtyDate1);
                applyDateTo = DateTime.Parse(qtyDate1);
            }


            List<KeepSearchListViewModel> kv = new List<KeepSearchListViewModel>();
            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            var urLocation = new DepartmentModel(_context).GetUserLocation(ur);
            //
            // 依照院區搜尋Keep主檔
            var kps = _context.BMEDKeeps.Where(r => r.Loc == urLocation);
            var keepFlows = _context.BMEDKeepFlows.AsQueryable();
            var keepDtls = _context.BMEDKeepDtls.AsQueryable();
            if (!string.IsNullOrEmpty(docid))   //表單編號
            {
                docid = docid.Trim();
                kps = kps.Where(v => v.DocId == docid);
            }
            if (!string.IsNullOrEmpty(ano))     //財產編號
            {
                kps = kps.Where(v => v.AssetNo == ano);
            }
            if (!string.IsNullOrEmpty(dptid))   //所屬部門編號
            {
                kps = kps.Where(v => v.DptId == dptid);
            }
            if (!string.IsNullOrEmpty(acc))     //成本中心
            {
                kps = kps.Where(v => v.AccDpt == acc);
            }
            if (!string.IsNullOrEmpty(aname))   //財產名稱
            {
                kps = kps.Where(v => v.AssetName != null)
                         .Where(v => v.AssetName.Contains(aname));
            }
            if (!string.IsNullOrEmpty(qtyTicketNo))   //發票號碼
            {
                qtyTicketNo = qtyTicketNo.ToUpper();
                var resultDocIds = _context.BMEDKeepCosts.Include(kc => kc.TicketDtl)
                                                         .Where(kc => kc.TicketDtl.TicketDtlNo == qtyTicketNo)
                                                         .Select(kc => kc.DocId).Distinct();
                kps = (from k in kps
                       where resultDocIds.Any(val => k.DocId.Contains(val))
                       select k);
            }
            if (!string.IsNullOrEmpty(qtyVendor))   //廠商關鍵字
            {
                var resultDocIds = _context.BMEDKeepCosts.Include(kc => kc.TicketDtl)
                                                         .Where(kc => kc.VendorName.Contains(qtyVendor))
                                                         .Select(kc => kc.DocId).Distinct();
                kps = (from k in kps
                       where resultDocIds.Any(val => k.DocId.Contains(val))
                       select k);
            }
            if (!string.IsNullOrEmpty(qtyEngCode))     //負責工程師
            {
                kps = kps.Where(v => v.EngId == Convert.ToInt32(qtyEngCode));
            }
            /* Search date by DateType.(ApplyDate) */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false) //送單日
            {
                if (qtyDateType == "送單日")
                {
                    kps = kps.Where(v => v.SentDate >= applyDateFrom && v.SentDate <= applyDateTo);
                }
            }

            if (!string.IsNullOrEmpty(ftype))   //流程狀態
            {
                switch (ftype)
                {
                    case "未結案":
                        keepFlows = _context.BMEDKeepFlows.Where(kf => kf.Status == "?");
                        break;
                    case "已結案":
                        keepFlows = _context.BMEDKeepFlows.Where(kf => kf.Status == "2");
                        break;
                }
            }
            else
            {
                keepFlows = _context.BMEDKeepFlows.Where(kf => kf.Status == "?" || kf.Status == "2");
            }
            if (!string.IsNullOrEmpty(qtyClsUser))   //目前關卡人員
            {
                keepFlows = keepFlows.GroupBy(f => f.DocId).Where(group => group.OrderBy(g => g.StepId).Last().UserId == Convert.ToInt32(qtyClsUser))
                                     .Select(group => group.Last());
            }

            /* If no search result. */
            if (kps.Count() == 0)
            {
                return PartialView("KeepQryList", kv.ToPagedList(page, pageSize));
            }

            kps.Join(keepFlows, k => k.DocId, f => f.DocId,
                (k, f) => new
                {
                    keep = k,
                    flow = f
                })
                .Join(_context.BMEDKeepDtls, m => m.keep.DocId, d => d.DocId,
                (m, d) => new
                {
                    keep = m.keep,
                    flow = m.flow,
                    keepdtl = d
                })
                .Join(_context.Departments, j => j.keep.AccDpt, d => d.DptId,
                (j, d) => new
                {
                    keep = j.keep,
                    flow = j.flow,
                    keepdtl = j.keepdtl,
                    dpt = d
                }).ToList()
                .ForEach(j => kv.Add(new KeepSearchListViewModel
                {
                    DocType = "保養",
                    DocId = j.keep.DocId,
                    AssetNo = j.keep.AssetNo,
                    AssetName = j.keep.AssetName,
                    //Brand = j.asset.Brand,
                    //Type = j.asset.Type,
                    PlaceLoc = j.keep.PlaceLoc,
                    ApplyDpt = j.keep.DptId,
                    AccDpt = j.keep.AccDpt,
                    AccDptName = j.dpt.Name_C,
                    Result = (j.keepdtl.Result == null || j.keepdtl.Result == 0) ? "" : _context.BMEDKeepResults.Find(j.keepdtl.Result).Title,
                    InOut = j.keepdtl.InOut == "0" ? "自行" :
                    j.keepdtl.InOut == "1" ? "委外" :
                    j.keepdtl.InOut == "2" ? "租賃" :
                    j.keepdtl.InOut == "3" ? "保固" : "",
                    Memo = j.keepdtl.Memo,
                    Cost = j.keepdtl.Cost,
                    Days = DateTime.Now.Subtract(j.keep.SentDate.GetValueOrDefault()).Days,
                    Flg = j.flow.Status,
                    FlowUid = j.flow.UserId,
                    FlowCls = j.flow.Cls,
                    FlowUidName = _context.AppUsers.Find(j.flow.UserId).FullName,
                    Src = j.keep.Src,
                    SentDate = j.keep.SentDate,
                    EndDate = j.keepdtl.EndDate,
                    CloseDate = j.keepdtl.CloseDate,
                    IsCharged = j.keepdtl.IsCharged,
                    keepdata = j.keep
                }));
            /* 設備編號"有"、"無"的對應，"有"讀取table相關data，"無"只顯示申請人輸入的設備名稱 */
            foreach (var item in kv)
            {
                if (item.AssetNo != null)
                {
                    var asset = _context.BMEDAssets.Where(a => a.AssetNo == item.AssetNo).FirstOrDefault();
                    if (asset != null)
                    {
                        item.AssetNo = asset.AssetNo;
                        item.AssetName = asset.Cname;
                        item.Brand = asset.Brand;
                        item.Type = asset.Type;
                    }
                }
            }
            /* Search date by DateType. */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)
            {
                if (qtyDateType == "結案日")
                {
                    kv = kv.Where(v => v.CloseDate >= applyDateFrom && v.CloseDate <= applyDateTo).ToList();
                }
                else if (qtyDateType == "完工日")
                {
                    kv = kv.Where(v => v.EndDate >= applyDateFrom && v.EndDate <= applyDateTo).ToList();
                }
            }

            /* Sorting search result. */
            if (kv.Count() != 0)
            {
                if (qtyDateType == "結案日")
                {
                    kv = kv.OrderByDescending(r => r.CloseDate).ThenByDescending(r => r.DocId).ToList();
                }
                else if (qtyDateType == "完工日")
                {
                    kv = kv.OrderByDescending(r => r.EndDate).ThenByDescending(r => r.DocId).ToList();
                }
                else
                {
                    kv = kv.OrderByDescending(r => r.SentDate).ThenByDescending(r => r.DocId).ToList();
                }
            }

            /* Search Keep InOut. */
            if (!string.IsNullOrEmpty(qtyInOut))
            {
                kv = kv.Where(k => k.InOut == qtyInOut).ToList();
            }
            /* Search KeepResults. */
            if (!string.IsNullOrEmpty(qtyKeepResult))
            {
                kv = kv.Where(r => r.Result == _context.BMEDKeepResults.Find(Convert.ToInt32(qtyKeepResult)).Title).ToList();
            }
            /* Search IsCharged. */
            if (!string.IsNullOrEmpty(qtyIsCharged))
            {
                kv = kv.Where(r => r.IsCharged == qtyIsCharged).ToList();
            }
            //
            if (kv.ToPagedList(page, pageSize).Count <= 0)
                return PartialView("KeepQryList", kv.ToPagedList(1, pageSize));
            return PartialView("KeepQryList", kv.ToPagedList(page, pageSize));
            //return View("KeepQryList", kv);
        }
        public List<KeepSearchListViewModel> GetKeepQryData(QryKeepListData qdata)
        {
            string docid = qdata.BMEDKqtyDOCID;
            string ano = qdata.BMEDKqtyASSETNO;
            string acc = qdata.BMEDKqtyACCDPT;
            string aname = qdata.BMEDKqtyASSETNAME;
            string ftype = qdata.BMEDKqtyFLOWTYPE;
            string dptid = qdata.BMEDKqtyDPTID;
            string qtyDate1 = qdata.BMEDKqtyApplyDateFrom;
            string qtyDate2 = qdata.BMEDKqtyApplyDateTo;
            string qtyKeepResult = qdata.BMEDKqtyKeepResult;
            string qtyIsCharged = qdata.BMEDKqtyIsCharged;
            string qtyDateType = qdata.BMEDKqtyDateType;
            bool searchAllDoc = qdata.BMEDKqtySearchAllDoc;
            string qtyEngCode = qdata.BMEDKqtyEngCode;
            string qtyTicketNo = qdata.BMEDKqtyTicketNo;
            string qtyVendor = qdata.BMEDKqtyVendor;
            string qtyClsUser = qdata.BMEDKqtyClsUser;
            string qtyInOut = qdata.BMEDKInOut;

            DateTime applyDateFrom = DateTime.Now;
            DateTime applyDateTo = DateTime.Now;
            /* Dealing search by date. */
            if (qtyDate1 != null && qtyDate2 != null)// If 2 date inputs have been insert, compare 2 dates.
            {
                DateTime date1 = DateTime.Parse(qtyDate1);
                DateTime date2 = DateTime.Parse(qtyDate2);
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
                applyDateFrom = DateTime.Parse(qtyDate2);
                applyDateTo = DateTime.Parse(qtyDate2);
            }
            else if (qtyDate1 != null && qtyDate2 == null)
            {
                applyDateFrom = DateTime.Parse(qtyDate1);
                applyDateTo = DateTime.Parse(qtyDate1);
            }


            List<KeepSearchListViewModel> kv = new List<KeepSearchListViewModel>();
            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            var urLocation = new DepartmentModel(_context).GetUserLocation(ur);
            //
            // 依照院區搜尋Keep主檔
            var kps = _context.BMEDKeeps.Where(r => r.Loc == urLocation);
            var keepFlows = _context.BMEDKeepFlows.AsQueryable();
            var keepDtls = _context.BMEDKeepDtls.AsQueryable();
            if (!string.IsNullOrEmpty(docid))   //表單編號
            {
                docid = docid.Trim();
                kps = kps.Where(v => v.DocId == docid);
            }
            if (!string.IsNullOrEmpty(ano))     //財產編號
            {
                kps = kps.Where(v => v.AssetNo == ano);
            }
            if (!string.IsNullOrEmpty(dptid))   //所屬部門編號
            {
                kps = kps.Where(v => v.DptId == dptid);
            }
            if (!string.IsNullOrEmpty(acc))     //成本中心
            {
                kps = kps.Where(v => v.AccDpt == acc);
            }
            if (!string.IsNullOrEmpty(aname))   //財產名稱
            {
                kps = kps.Where(v => v.AssetName != null)
                         .Where(v => v.AssetName.Contains(aname));
            }
            if (!string.IsNullOrEmpty(qtyTicketNo))   //發票號碼
            {
                qtyTicketNo = qtyTicketNo.ToUpper();
                var resultDocIds = _context.BMEDKeepCosts.Include(kc => kc.TicketDtl)
                                                         .Where(kc => kc.TicketDtl.TicketDtlNo == qtyTicketNo)
                                                         .Select(kc => kc.DocId).Distinct();
                kps = (from k in kps
                       where resultDocIds.Any(val => k.DocId.Contains(val))
                       select k);
            }
            if (!string.IsNullOrEmpty(qtyVendor))   //廠商關鍵字
            {
                var resultDocIds = _context.BMEDKeepCosts.Include(kc => kc.TicketDtl)
                                                         .Where(kc => kc.VendorName.Contains(qtyVendor))
                                                         .Select(kc => kc.DocId).Distinct();
                kps = (from k in kps
                       where resultDocIds.Any(val => k.DocId.Contains(val))
                       select k);
            }
            if (!string.IsNullOrEmpty(qtyEngCode))     //負責工程師
            {
                kps = kps.Where(v => v.EngId == Convert.ToInt32(qtyEngCode));
            }
            /* Search date by DateType.(ApplyDate) */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false) //送單日
            {
                if (qtyDateType == "送單日")
                {
                    kps = kps.Where(v => v.SentDate >= applyDateFrom && v.SentDate <= applyDateTo);
                }
            }

            if (!string.IsNullOrEmpty(ftype))   //流程狀態
            {
                switch (ftype)
                {
                    case "未結案":
                        keepFlows = _context.BMEDKeepFlows.Where(kf => kf.Status == "?");
                        break;
                    case "已結案":
                        keepFlows = _context.BMEDKeepFlows.Where(kf => kf.Status == "2");
                        break;
                }
            }
            else
            {
                keepFlows = _context.BMEDKeepFlows.Where(kf => kf.Status == "?" || kf.Status == "2");
            }
            if (!string.IsNullOrEmpty(qtyClsUser))   //目前關卡人員
            {
                keepFlows = keepFlows.GroupBy(f => f.DocId).Where(group => group.OrderBy(g => g.StepId).Last().UserId == Convert.ToInt32(qtyClsUser))
                                     .Select(group => group.Last());
            }

            /* If no search result. */
            if (kps.Count() == 0)
            {
                return kv;
            }

            kps.Join(keepFlows, k => k.DocId, f => f.DocId,
                (k, f) => new
                {
                    keep = k,
                    flow = f
                })
                .Join(_context.BMEDKeepDtls, m => m.keep.DocId, d => d.DocId,
                (m, d) => new
                {
                    keep = m.keep,
                    flow = m.flow,
                    keepdtl = d
                })
                .Join(_context.Departments, j => j.keep.AccDpt, d => d.DptId,
                (j, d) => new
                {
                    keep = j.keep,
                    flow = j.flow,
                    keepdtl = j.keepdtl,
                    dpt = d
                }).ToList()
                .ForEach(j => kv.Add(new KeepSearchListViewModel
                {
                    DocType = "保養",
                    DocId = j.keep.DocId,
                    AssetNo = j.keep.AssetNo,
                    AssetName = j.keep.AssetName,
                    //Brand = j.asset.Brand,
                    //Type = j.asset.Type,
                    PlaceLoc = j.keep.PlaceLoc,
                    ApplyDpt = j.keep.DptId,
                    AccDpt = j.keep.AccDpt,
                    AccDptName = j.dpt.Name_C,
                    Result = (j.keepdtl.Result == null || j.keepdtl.Result == 0) ? "" : _context.BMEDKeepResults.Find(j.keepdtl.Result).Title,
                    InOut = j.keepdtl.InOut == "0" ? "自行" :
                    j.keepdtl.InOut == "1" ? "委外" :
                    j.keepdtl.InOut == "2" ? "租賃" :
                    j.keepdtl.InOut == "3" ? "保固" : "",
                    Memo = j.keepdtl.Memo,
                    Cost = j.keepdtl.Cost,
                    Days = DateTime.Now.Subtract(j.keep.SentDate.GetValueOrDefault()).Days,
                    Flg = j.flow.Status,
                    FlowUid = j.flow.UserId,
                    FlowCls = j.flow.Cls,
                    FlowUidName = _context.AppUsers.Find(j.flow.UserId).FullName,
                    Src = j.keep.Src,
                    SentDate = j.keep.SentDate,
                    EndDate = j.keepdtl.EndDate,
                    CloseDate = j.keepdtl.CloseDate,
                    IsCharged = j.keepdtl.IsCharged,
                    keepdata = j.keep
                }));
            /* 設備編號"有"、"無"的對應，"有"讀取table相關data，"無"只顯示申請人輸入的設備名稱 */
            foreach (var item in kv)
            {
                if (item.AssetNo != null)
                {
                    var asset = _context.BMEDAssets.Where(a => a.AssetNo == item.AssetNo).FirstOrDefault();
                    if (asset != null)
                    {
                        item.AssetNo = asset.AssetNo;
                        item.AssetName = asset.Cname;
                        item.Brand = asset.Brand;
                        item.Type = asset.Type;
                    }
                }
            }
            /* Search date by DateType. */
            if (string.IsNullOrEmpty(qtyDate1) == false || string.IsNullOrEmpty(qtyDate2) == false)
            {
                if (qtyDateType == "結案日")
                {
                    kv = kv.Where(v => v.CloseDate >= applyDateFrom && v.CloseDate <= applyDateTo).ToList();
                }
                else if (qtyDateType == "完工日")
                {
                    kv = kv.Where(v => v.EndDate >= applyDateFrom && v.EndDate <= applyDateTo).ToList();
                }
            }

            /* Sorting search result. */
            if (kv.Count() != 0)
            {
                if (qtyDateType == "結案日")
                {
                    kv = kv.OrderByDescending(r => r.CloseDate).ThenByDescending(r => r.DocId).ToList();
                }
                else if (qtyDateType == "完工日")
                {
                    kv = kv.OrderByDescending(r => r.EndDate).ThenByDescending(r => r.DocId).ToList();
                }
                else
                {
                    kv = kv.OrderByDescending(r => r.SentDate).ThenByDescending(r => r.DocId).ToList();
                }
            }

            /* Search Keep InOut. */
            if (!string.IsNullOrEmpty(qtyInOut))
            {
                kv = kv.Where(k => k.InOut == qtyInOut).ToList();
            }
            /* Search KeepResults. */
            if (!string.IsNullOrEmpty(qtyKeepResult))
            {
                kv = kv.Where(r => r.Result == _context.BMEDKeepResults.Find(Convert.ToInt32(qtyKeepResult)).Title).ToList();
            }
            /* Search IsCharged. */
            if (!string.IsNullOrEmpty(qtyIsCharged))
            {
                kv = kv.Where(r => r.IsCharged == qtyIsCharged).ToList();
            }
            //
           
            return kv;
            //return View("KeepQryList", kv);
        }
        public IActionResult QryKeepListExcel(QryKeepListData qdata)
        {
            
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("表單編號");
            dt.Columns.Add("申請日期");
            dt.Columns.Add("成本中心名稱");
            dt.Columns.Add("財產編號");
            dt.Columns.Add("儀器名稱");
            dt.Columns.Add("放置地點");
            dt.Columns.Add("保養方式");
            dt.Columns.Add("保養結果");
            dt.Columns.Add("保養描述");
            dt.Columns.Add("文件狀態");
            dt.Columns.Add("關卡人員");

            List<KeepSearchListViewModel> mv = GetKeepQryData(qdata);
            
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.DocId;
                dw[1] = m.SentDate;
                dw[2] = m.AccDptName;
                dw[3] = m.AssetNo;
                dw[4] = m.AssetName;
                dw[5] = m.PlaceLoc;
                dw[6] = m.InOut;
                dw[7] = m.Result;
                dw[8] = m.Memo;
                dw[9] = m.Flg == "?" ? "未結案" : "已結案";
                dw[10] = m.FlowUidName;
        
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("全院保養查詢清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "全院保養查詢清單.xlsx"
            );
        }

        /// <summary>
        /// Get the query result list of delivery docs.
        /// </summary>
        /// <param name="qdata"></param>
        /// <returns></returns>
        // POST: BMED/Search/GetDelivQryList
        [HttpPost]
        public IActionResult GetDelivQryList(IFormCollection form)
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "待處理", Value = "待處理" });
            listItem.Add(new SelectListItem { Text = "已處理", Value = "已處理" });
            listItem.Add(new SelectListItem { Text = "已結案", Value = "已結案" });
            ViewData["FLOWTYP"] = new SelectList(listItem, "Value", "Text", "待處理");
            //
            List<DeliveryListVModel> vm;
            vm = GetDeliveryList(form["qtyFLOWTYP"]);
            if (!string.IsNullOrEmpty(form["qtyDOCID"]))
            {
                vm = vm.Where(m => m.DocId == form["qtyDOCID"]).ToList();
            }
            if (!string.IsNullOrEmpty(form["qtyPURCHASENO"]))
            {
                vm = vm.Where(m => m.PurchaseNo == form["qtyPURCHASENO"]).ToList();
            }
            if (!string.IsNullOrEmpty(form["qtyDPTID"]))
            {
                vm = vm.Where(m => m.Company == form["qtyDPTID"]).ToList();
            }
            if (!string.IsNullOrEmpty(form["qtyACCDPT"]))
            {
                vm = vm.Where(m => m.AccDpt == form["qtyACCDPT"]).ToList();
            }
            if (!string.IsNullOrEmpty(form["qtyBUDGETID"]))
            {
                vm = vm.Where(m => m.BudgetId == form["qtyBUDGETID"]).ToList();
            }
            if (!string.IsNullOrEmpty(form["qtyCONTRACTNO"]))
            {
                vm = vm.Where(m => m.ContractNo == form["qtyCONTRACTNO"]).ToList();
            }
            if (!string.IsNullOrEmpty(form["qtyASSETNO"]))
            {
                AssetModel at = _context.BMEDAssets.Find(form["qtyASSETNO"]);
                if (at != null)
                {
                    vm = vm.Where(m => m.DocId == at.Docid).ToList();
                }
                else
                    vm.Clear();
            }
            if (form["qtyVENDOR"] != "")
            {
                string s = form["qtyVENDOR"];
                List<VendorModel> vs = _context.BMEDVendors.Where(a => a.VendorName.Contains(s))
                    .ToList();
                if (vs != null)
                {
                    vm = vm.Join(vs, v => Convert.ToInt32(v.VendorNo), a => a.VendorId,
                        (v, a) => v).ToList();
                }
                else
                    vm.Clear();
            }
            foreach (var item in vm)
            {
                var u = _context.AppUsers.Find(item.UserId);
                item.Contact = u == null ? "" : u.Ext;
                u = _context.AppUsers.Find(item.FlowUid);
                item.FlowUname = u == null ? "" : u.FullName;
                item.CompanyNam = _context.Departments.Find(item.Company) == null ? "" : _context.Departments.Find(item.Company).Name_C;
            }
            vm = vm.OrderByDescending(v => v.ApplyDate).ToList();
            return PartialView("DelivQryList", vm);
        }

        public List<DeliveryListVModel> GetDeliveryList(string cls = null)
        {
            List<DeliveryListVModel> dv = new List<DeliveryListVModel>();
            List<DelivFlowModel> rf = new List<DelivFlowModel>();
            IQueryable<DelivFlowModel> rf2;
            // Get Login User's details.
            var ur = _userRepo.Find(usr => usr.UserName == User.Identity.Name).FirstOrDefault();
            switch (cls)
            {
                case "已處理":
                    rf2 = _context.DelivFlows.Where(df => df.Status == "?")
                                             .Where(m => m.UserId != ur.Id);
                    if (!userManager.IsInRole(User, "Usual"))
                    {
                        rf.AddRange(rf2);
                    }
                    else
                    {
                        foreach (DelivFlowModel f in rf2)
                        {
                            if (_context.DelivFlows.Where(m => m.DocId == f.DocId).Where(m => m.UserId == ur.Id).Count() > 0)
                            {
                                rf.Add(f);
                            }
                        }
                    }

                    break;
                case "已結案":
                    rf2 = _context.DelivFlows.Where(df => df.Status == "2");
                    if (!userManager.IsInRole(User, "Usual"))
                    {
                        rf.AddRange(rf2);
                    }
                    else
                    {
                        foreach (DelivFlowModel f in rf2)
                        {
                            if (_context.DelivFlows.Where(m => m.DocId == f.DocId).Where(m => m.UserId == ur.Id).Count() > 0)
                            {
                                rf.Add(f);
                            }
                        }
                    }
                    break;
                case "所有":
                    rf2 = _context.DelivFlows.Where(df => df.Status == "2" || df.Status == "?");
                    if (!userManager.IsInRole(User, "Usual"))
                    {
                        rf.AddRange(rf2);
                    }
                    else
                    {
                        foreach (DelivFlowModel f in rf2)
                        {
                            if (_context.DelivFlows.Where(m => m.DocId == f.DocId).Where(m => m.UserId == ur.Id).Count() > 0)
                            {
                                rf.Add(f);
                            }
                        }
                    }
                    break;
                case "查詢":
                    rf2 = _context.DelivFlows.Where(df => df.Status == "?");
                    DeliveryModel r;
                    foreach (DelivFlowModel f in rf2)
                    {
                        r = _context.Deliveries.Find(f.DocId);
                        rf.Add(f);
                    }
                    break;
                default:
                    rf = _context.DelivFlows.Where(df => df.Status == "?")
                                            .Where(m => m.UserId == ur.Id).ToList();
                    break;
            }
            rf.OrderByDescending(m => m.Rtt);
            DeliveryListVModel i;
            foreach (DelivFlowModel f in rf)
            {
                DeliveryModel r = _context.Deliveries.Find(f.DocId);
                AppUserModel p = r == null ? null : _context.AppUsers.Find(r.UserId);
                DepartmentModel c = p == null ? null : _context.Departments.Find(p.DptId);
                //BuyEvaluate b = db.BuyEvaluates.Find(r.PurchaseNo);
                if (r != null)
                {
                    i = new DeliveryListVModel();
                    i.DocType = "驗收";
                    i.DocId = r.DocId;
                    i.UserId = r.UserId;
                    i.UserName = r.UserName;
                    if (p != null)
                    {
                        i.Company = p.DptId;
                        i.CompanyNam = c == null ? "" : c.Name_C;
                    }
                    i.ContractNo = r.ContractNo;
                    i.PurchaseNo = r.PurchaseNo;
                    i.CrlItemNo = r.CrlItemNo;
                    i.AccDpt = r.AccDpt;
                    var accDpt = _context.Departments.Find(r.AccDpt);
                    i.AccDptNam = accDpt == null ? "" : accDpt.Name_C;
                    i.BudgetId = "";
                    if (f.Status == "?")
                        i.Days = DateTime.Now.Subtract(r.ApplyDate.GetValueOrDefault()).Days;
                    else
                        i.Days = null;
                    i.Flg = f.Status;
                    i.FlowUid = f.UserId;
                    i.VendorNo = r.VendorId;
                    i.ApplyDate = r.ApplyDate;
                    dv.Add(i);
                }
            }
            //
            return dv;
        }

    }
}