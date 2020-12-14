using EDIS.Areas.FORMS.Data;
using EDIS.Areas.FORMS.Models;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.FORMS.Components.OutsideBmed
{
    public class FORMSosbNextSFlowViewComponent : ViewComponent
    {
        private readonly BMEDDBContext _db;
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;

        public FORMSosbNextSFlowViewComponent(BMEDDBContext db,
                                        ApplicationDbContext context,
                                        IRepository<AppUserModel, int> userRepo,
                                        CustomUserManager customUserManager,
                                        CustomRoleManager customRoleManager)
        {
            _db = db;
            _context = context;
            _userRepo = userRepo;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            Assign assign = new Assign();
            assign.DocId = id;
            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "申請者", Value = "申請者" });
            listItem.Add(new SelectListItem { Text = "單位主管", Value = "單位主管" });
            listItem.Add(new SelectListItem { Text = "醫工承辦", Value = "醫工承辦" });
            listItem.Add(new SelectListItem { Text = "醫工工程師", Value = "醫工工程師" });
            //listItem.Add(new SelectListItem { Text = "專責單位", Value = "專責單位" });
            listItem.Add(new SelectListItem { Text = "醫工部主管", Value = "醫工部主管" });

            Instrument sdata = _db.Instruments.Find(id);
            OutsideBmedFlow of = _db.OutsideBmedFlows.Where(f => f.DocId == id && f.Status == "?").FirstOrDefault();
            var ur = _userRepo.Find(uf => uf.UserName == this.User.Identity.Name).FirstOrDefault();
            var rel = roleManager.GetRolesForUser(ur.Id);

            //AppUser appUser = db.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (of != null)
            {
                assign.ClsNow = of.Cls;
                if (sdata != null)
                {
                    if (of.Cls == "醫工主管" && rel.Contains("MedMgr"))
                    {
                        listItem.Add(new SelectListItem { Text = "結案", Value = "結案" });
                    }
                }

                if (of.Cls == "申請人")
                {
                    listItem.Add(new SelectListItem { Text = "廢除", Value = "廢除" });
                }
            }
            ViewData["FlowCls"] = new SelectList(listItem, "Value", "Text", "");

            List<SelectListItem> listItem3 = new List<SelectListItem>();
            ViewData["FlowUid"] = new SelectList(listItem3, "Value", "Text", "");


            //assign.Hint = "";
            assign.FlowUid = sdata.ToUserId;
            assign.Application = sdata.Application;
            assign.item1 = of.item1;
            assign.item2 = of.item2;
            assign.item3 = of.item3;
            assign.item4 = of.item4;
            assign.item5 = of.item5;
            assign.item6 = of.item6;
            assign.item7 = of.item7;
            return View(assign);
        }

    }
}