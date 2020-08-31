using EDIS.Models;
using EDIS.Models.Identity;


using EDIS.Areas.BMED.Repositories;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.BMED.Components.KeepFlow
{
    public class BMEDKeepNextFlowViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;

        public BMEDKeepNextFlowViewComponent(ApplicationDbContext context,
                                             IRepository<AppUserModel, int> userRepo,
                                             CustomUserManager customUserManager)
        {
            _context = context;
            _userRepo = userRepo;
            userManager = customUserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            /* Get repair and flow details. */
            KeepModel keep = _context.BMEDKeeps.Find(id);
            KeepDtlModel keepDtl = _context.BMEDKeepDtls.Find(id);
            KeepFlowModel keepFlow = _context.BMEDKeepFlows.Where(f => f.DocId == id && f.Status == "?")
                                                           .FirstOrDefault();

            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "申請人", Value = "申請人" });
            listItem.Add(new SelectListItem { Text = "驗收人", Value = "驗收人" });
            listItem.Add(new SelectListItem { Text = "單位主管", Value = "單位主管" });
            listItem.Add(new SelectListItem { Text = "維修工程師", Value = "維修工程師" });
            listItem.Add(new SelectListItem { Text = "設備工程師", Value = "設備工程師" });
            listItem.Add(new SelectListItem { Text = "醫工主管", Value = "醫工主管" });
            listItem.Add(new SelectListItem { Text = "賀康主管", Value = "賀康主管" });
            //listItem.Add(new SelectListItem { Text = "醫工主任", Value = "醫工主任" });
            listItem.Add(new SelectListItem { Text = "其他", Value = "其他" });

            //額外流程控管
            if (keepDtl.IsCharged == "Y" && keepDtl.NotInExceptDevice == "N")   //有費用 & 非統包
            {
                var itemToRemove = listItem.Single(r => r.Value == "驗收人");
                listItem.Remove(itemToRemove);    //只醫工主管可結案
            }
            if (keepDtl.NotInExceptDevice == "N")    //非統包
            {
                var itemToRemove = listItem.Single(r => r.Value == "賀康主管");
                listItem.Remove(itemToRemove);
            }
            if (keepFlow.Cls == "驗收人" && keepDtl.IsCharged == "Y")  //有費用 & 關卡於驗收人，下一關只可給工程師
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

            /* Insert values. */
            AssignModel assign = new AssignModel();
            assign.DocId = id;

            /* 根據當下流程的人員做額外的流程控管 */
            if (keepFlow != null)
            {
                assign.Cls = keepFlow.Cls;

                if (keepFlow.Cls == "驗收人" || keepFlow.Cls == "醫工主管" || keepFlow.Cls == "賀康主管")    
                {
                    listItem.Add(new SelectListItem { Text = "結案", Value = "結案" });
                }
                if (keepFlow.Cls == "驗收人" && keepDtl.IsCharged == "Y")  //有費用 & 關卡於驗收人，下一關只可給工程師
                {
                    var itemToRemove = listItem.SingleOrDefault(r => r.Value == "結案");
                    if (itemToRemove != null)
                    {
                        listItem.Remove(itemToRemove);
                    }
                }
                //無費用時單位主管可結案
                if (keepFlow.Cls == "單位主管")
                {
                    if (keepDtl != null)
                    {
                        if (keepDtl.IsCharged == "N")
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

            assign.Hint = "申請者→負責工程師→使用單位→(若有費用)負責工程師→[醫工部主管、賀康主管]→結案";

            return View(assign);
        }

    }
}
