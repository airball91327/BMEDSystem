using EDIS.Models;

using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Components.BMEDKeep
{
    public class BMEDKeepIndexViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomRoleManager roleManager;
        private readonly IRepository<AppUserModel, int> _userRepo;

        public BMEDKeepIndexViewComponent(ApplicationDbContext context,
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
            ViewData["BMEDKeepFlowType"] = new SelectList(FlowlistItem, "Value", "Text", "待簽核");

            /* 成本中心 & 申請部門的下拉選單資料 */
            var dptList = new[] { "K", "P", "C" };   //本院部門
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
            ViewData["BMEDKeepAccDpt"] = new SelectList(listItem, "Value", "Text");
            ViewData["BMEDKeepApplyDpt"] = new SelectList(listItem, "Value", "Text");

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
            ViewData["BMEDKeepResult"] = new SelectList(listItem2, "Value", "Text");

            /* 處理有無費用的下拉選單 */
            List<SelectListItem> listItem3 = new List<SelectListItem>();
            listItem3.Add(new SelectListItem { Text = "有", Value = "Y" });
            listItem3.Add(new SelectListItem { Text = "無", Value = "N" });
            ViewData["BMEDIsCharged"] = new SelectList(listItem3, "Value", "Text");

            /* 處理日期查詢的下拉選單 */
            List<SelectListItem> listItem4 = new List<SelectListItem>();
            listItem4.Add(new SelectListItem { Text = "送單日", Value = "送單日" });
            listItem4.Add(new SelectListItem { Text = "完工日", Value = "完工日" });
            listItem4.Add(new SelectListItem { Text = "結案日", Value = "結案日" });
            ViewData["BMEDKeepDateType"] = new SelectList(listItem4, "Value", "Text", "送單日");

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

            List<SelectListItem> listItem7 = new List<SelectListItem>();
            listItem7.Add(new SelectListItem { Text = "總院", Value = "總院" });
            listItem7.Add(new SelectListItem { Text = "二林", Value = "L" });
            listItem7.Add(new SelectListItem { Text = "員林", Value = "B" });
            listItem7.Add(new SelectListItem { Text = "南投", Value = "N" });
            listItem7.Add(new SelectListItem { Text = "鹿基", Value = "U" });
            listItem7.Add(new SelectListItem { Text = "雲基", Value = "T" });
            ViewData["Location"] = new SelectList(listItem7, "Value", "Text");


            QryKeepListData data = new QryKeepListData();

            return View(data);
        }
    }
}
