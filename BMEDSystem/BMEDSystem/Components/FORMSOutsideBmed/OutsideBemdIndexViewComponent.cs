using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Components.FORMSOutsideBmed
{
    public class OutsideBemdIndexViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomRoleManager roleManager;
        private readonly IRepository<AppUserModel, int> _userRepo;

        public OutsideBemdIndexViewComponent(ApplicationDbContext context,
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
            ViewData["FORMSFlowType"] = new SelectList(FlowlistItem, "Value", "Text", "待簽核");


           

            /* 處理日期查詢的下拉選單 */
            List<SelectListItem> listItem4 = new List<SelectListItem>();
            listItem4.Add(new SelectListItem { Text = "申請日", Value = "申請日" });
            listItem4.Add(new SelectListItem { Text = "結案日", Value = "結案日" });
            ViewData["FORMSDateType"] = new SelectList(listItem4, "Value", "Text", "申請日");

           
           

           

            //申請部門
            List<SelectListItem> listItem = new List<SelectListItem>();
            _context.Departments.Where(d => d.DptId == user.DptId).Select(c => c.Name_C).ToList()
               .ForEach(d =>
               {
                   listItem.Add(new SelectListItem { Text = d, Value = d });
               }
               );
            ViewData["FORMSqtyDPTID"] = new SelectList(listItem, "Value", "Text");


            //負責人員
            List<SelectListItem> listItem1 = new List<SelectListItem>();
            ViewData["FORMSqtyClsUser"] = new SelectList(listItem1, "Value", "Text");


            QryOsbListData data = new QryOsbListData();

            return View(data);
        }
    }
}
