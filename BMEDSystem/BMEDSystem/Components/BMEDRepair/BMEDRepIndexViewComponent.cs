using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Components.BMEDRepair
{
    public class BMEDRepIndexViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomRoleManager roleManager;
        private readonly IRepository<AppUserModel, int> _userRepo;

        public BMEDRepIndexViewComponent(ApplicationDbContext context,
                                         CustomRoleManager customRoleManager,
                                         IRepository<AppUserModel, int> userRepo)
        {
            _context = context;
            roleManager = customRoleManager;
            _userRepo = userRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Get current user.
            var user = _userRepo.Find(u => u.UserName == User.Identity.Name).FirstOrDefault();

            /* 流程的下拉選單 */
            List<SelectListItem> FlowlistItem = new List<SelectListItem>();
            FlowlistItem.Add(new SelectListItem { Text = "待簽核", Value = "待簽核" });
            FlowlistItem.Add(new SelectListItem { Text = "流程中", Value = "流程中" });
            FlowlistItem.Add(new SelectListItem { Text = "已結案", Value = "已結案" });
            FlowlistItem.Add(new SelectListItem { Text = "請選擇", Value = "請選擇" });
            ViewData["BMEDFlowType"] = new SelectList(FlowlistItem, "Value", "Text", "待簽核");

            /* 成本中心 & 申請部門的下拉選單資料 */
            var dptList = new[] { "K", "P", "C" };   //本院部門
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
            ViewData["BMEDAccDpt"] = new SelectList(listItem, "Value", "Text");
            ViewData["BMEDApplyDpt"] = new SelectList(listItem, "Value", "Text");

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
            ViewData["BMEDDealStatus"] = new SelectList(listItem2, "Value", "Text");

            /* 處理有無費用的下拉選單 */
            List<SelectListItem> listItem3 = new List<SelectListItem>();
            listItem3.Add(new SelectListItem { Text = "有", Value = "Y" });
            listItem3.Add(new SelectListItem { Text = "無", Value = "N" });
            ViewData["BMEDIsCharged"] = new SelectList(listItem3, "Value", "Text");

            /* 處理日期查詢的下拉選單 */
            List<SelectListItem> listItem4 = new List<SelectListItem>();
            listItem4.Add(new SelectListItem { Text = "申請日", Value = "申請日" });
            listItem4.Add(new SelectListItem { Text = "完工日", Value = "完工日" });
            listItem4.Add(new SelectListItem { Text = "結案日", Value = "結案日" });
            ViewData["BMEDDateType"] = new SelectList(listItem4, "Value", "Text", "申請日");

            /* 處理工程師查詢的下拉選單 */
            var engs = roleManager.GetUsersInRole("MedEngineer").ToList();
            List<SelectListItem> listItem5 = new List<SelectListItem>();
            foreach (string l in engs)
            {
                var u = _context.AppUsers.Where(ur => ur.UserName == l && ur.Status == "Y").FirstOrDefault();
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
            var dptUsers = _context.AppUsers.Where(a => a.DptId == user.DptId && a.Status == "Y").ToList();
            List<SelectListItem> dptMemberList = new List<SelectListItem>();
            foreach (var item in dptUsers)
            {
                dptMemberList.Add(new SelectListItem
                {
                    Text = item.FullName + "(" + item.UserName + ")",
                    Value = item.Id.ToString()
                });
            }

            // 使用者為工程師，帶工程師列表，其餘帶同部門人員
            if (user.DptId == "7084" || user.DptId == "8420")
            {
                ViewData["BMEDClsUsers"] = new SelectList(listItem5, "Value", "Text");
            }
            else
            {
                ViewData["BMEDClsUsers"] = new SelectList(dptMemberList, "Value", "Text");
            }

            QryRepListData data = new QryRepListData();

            return View(data);
        }
    }
}
