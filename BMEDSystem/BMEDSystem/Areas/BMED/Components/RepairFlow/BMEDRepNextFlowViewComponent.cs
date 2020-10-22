﻿using EDIS.Models;
using EDIS.Models.Identity;

using EDIS.Areas.BMED.Repositories;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.BMED.Components.RepairFlow
{
    public class BMEDRepNextFlowViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<RepairFlowModel, string[]> _repflowRepo;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;

        public BMEDRepNextFlowViewComponent(ApplicationDbContext context,
                                            IRepository<RepairFlowModel, string[]> repairflowRepo,
                                            IRepository<AppUserModel, int> userRepo,
                                            CustomUserManager customUserManager)
        {
            _context = context;
            _repflowRepo = repairflowRepo;
            _userRepo = userRepo;
            userManager = customUserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            /* Get repair and flow details. */
            RepairModel repair = _context.BMEDRepairs.Find(id);
            RepairDtlModel repairDtl = _context.BMEDRepairDtls.Find(id);
            RepairFlowModel repairFlow = _context.BMEDRepairFlows.Where(f => f.DocId == id && f.Status == "?")
                                                                 .FirstOrDefault();

            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "申請人", Value = "申請人" });
            listItem.Add(new SelectListItem { Text = "驗收人", Value = "驗收人" });
            listItem.Add(new SelectListItem { Text = "單位主管", Value = "單位主管" });
            //listItem.Add(new SelectListItem { Text = "維修工程師", Value = "維修工程師" });
            listItem.Add(new SelectListItem { Text = "設備工程師", Value = "設備工程師" });
            listItem.Add(new SelectListItem { Text = "賀康主管", Value = "賀康主管" });
            //總、分院不同關卡
            if (repair.Loc == "總院")
            {
                listItem.Add(new SelectListItem { Text = "醫工主管", Value = "醫工主管" });
            }
            else
            {
                listItem.Add(new SelectListItem { Text = "醫工分院主管", Value = "醫工分院主管" });
                listItem.Add(new SelectListItem { Text = "設備主管", Value = "設備主管" });
            }

            //額外流程控管
            if (repairDtl.IsCharged == "Y" && repairDtl.NotInExceptDevice == "N")   //有費用 & 非統包
            {
                var itemToRemove = listItem.SingleOrDefault(r => r.Value == "驗收人");  //移除驗收人關卡，只醫工主管可結案
                if (itemToRemove != null)
                {
                    listItem.Remove(itemToRemove);
                }
            }
            if (repairDtl.NotInExceptDevice == "N" || repairDtl.DealState == 4)    //非統包 or 報廢
            {
                var itemToRemove = listItem.SingleOrDefault(r => r.Value == "賀康主管");  //移除賀康主管關卡
                if (itemToRemove != null)
                {
                    listItem.Remove(itemToRemove);
                }
            }
            if (repairDtl.DealState == 4)   //報廢
            {
                var itemToRemove = listItem.SingleOrDefault(r => r.Value == "驗收人");  //移除驗收人關卡，只醫工主管可結案
                if (itemToRemove != null)
                {
                    listItem.Remove(itemToRemove);
                }
            }
            if (repairDtl.NotInExceptDevice == "Y" && repairDtl.DealState != 4)   // 統包 & 非報廢
            {
                var itemToRemove = listItem.SingleOrDefault(r => r.Value == "醫工主管"); //移除醫工主管關卡
                if (itemToRemove != null)
                {
                    listItem.Remove(itemToRemove);
                }
            }
            if (repairFlow.Cls == "驗收人" && repairDtl.IsCharged == "Y")  //有費用 & 關卡於驗收人，下一關只可給工程師
            {
                var itemToRemove = listItem.SingleOrDefault(r => r.Value == "醫工主管");
                if (itemToRemove != null)
                {
                    listItem.Remove(itemToRemove);
                }
                itemToRemove = listItem.SingleOrDefault(r => r.Value == "賀康主管");
                if (itemToRemove != null)
                {
                    listItem.Remove(itemToRemove);
                }
            }
            //
            listItem.Add(new SelectListItem { Text = "其他", Value = "其他" });
            /* Insert values. */
            AssignModel assign = new AssignModel();
            assign.DocId = id;

            /* 根據當下流程的人員做額外的流程控管 */
            if (repairFlow != null)
            {
                assign.Cls = repairFlow.Cls;

                if (repairFlow.Cls == "驗收人" || repairFlow.Cls == "醫工主管" || 
                    repairFlow.Cls == "賀康主管" || repairFlow.Cls == "設備主管")    //可結案人員
                {
                    listItem.Add(new SelectListItem { Text = "結案", Value = "結案" });
                }
                //有費用 & 關卡於驗收人 or 有費用 & 為報廢設備，驗收人不可結案
                if (repairFlow.Cls == "驗收人")  
                {
                    if (repairDtl.IsCharged == "Y" || repairDtl.DealState == 4)
                    {
                        var itemToRemove = listItem.SingleOrDefault(r => r.Value == "結案");
                        if (itemToRemove != null)
                        {
                            listItem.Remove(itemToRemove);
                        }
                    }
                }
                //無費用時單位主管可結案
                if (repairFlow.Cls == "單位主管")
                {
                    if (repairDtl != null)
                    {
                        if (repairDtl.IsCharged == "N")
                        {
                            listItem.Add(new SelectListItem { Text = "結案", Value = "結案" });
                        }
                    }
                }
            }
            ViewData["FlowCls"] = new SelectList(listItem, "Value", "Text", "");

            List<SelectListItem> listItem3 = new List<SelectListItem>();
            listItem3.Add(new SelectListItem { Text = "", Value = "" });
            ViewData["FlowUid"] = new SelectList(listItem3, "Value", "Text", "");

            /* Get Default Checker for MedEngineers to edit. */
            List<SelectListItem> listItem4 = new List<SelectListItem>();
            var defaultChecker = _context.AppUsers.Find(repair.CheckerId);
            listItem4.Add(new SelectListItem { Text = defaultChecker.FullName, Value = defaultChecker.Id.ToString() });
            ViewData["DefaultChecker"] = new SelectList(listItem4, "Value", "Text", defaultChecker.Id.ToString());

            /* 驗收人員所屬部門搜尋的下拉選單資料 */
            //var dptList = new[] { "K", "P", "C" };   //本院部門
            //var departments = _context.Departments.Where(d => dptList.Contains(d.Loc)).ToList();
            var departments = _context.Departments;
            List<SelectListItem> listItem5 = new List<SelectListItem>();
            foreach (var item in departments)
            {
                listItem5.Add(new SelectListItem
                {
                    Text = item.Name_C + "(" + item.DptId + ")",    //show DptName(DptId)
                    Value = item.DptId
                });
            }
            ViewData["BMEDQRYDPT"] = new SelectList(listItem5, "Value", "Text");

            //assign.Hint = "申請者→負責工程師→使用單位→[(若有費用及報廢)醫工部主管、賀康主管]→結案";
            assign.Hint = "申請者→負責工程師→使用單位→(若有費用)負責工程師→[醫工部主管、賀康主管]→結案";

            /* 於流程頁面顯示請修類型、及處理狀態*/
            string hintRepType = repair.RepType;
            string hintRepState = "";
            var repDtl = _context.BMEDRepairDtls.Where(dtl => dtl.DocId == id).FirstOrDefault();
            if (repDtl != null)
            {
                hintRepState = _context.BMEDDealStatuses.Find(repDtl.DealState).Title;
            }
            ViewData["HintRepType"] = hintRepType + " / " + hintRepState;

            return View(assign);
        }
    }
}
