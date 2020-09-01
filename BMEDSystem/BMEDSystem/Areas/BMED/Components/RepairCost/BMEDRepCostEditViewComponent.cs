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
using Microsoft.EntityFrameworkCore;

namespace EDIS.Areas.BMED.Components.RepairCost
{
    public class BMEDRepCostEditViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<RepairFlowModel, string[]> _repflowRepo;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;

        public BMEDRepCostEditViewComponent(ApplicationDbContext context,
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
            RepairCostModel cost = new RepairCostModel();
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();

            /* Check the device's contract. */
            var repairDtl = _context.BMEDRepairDtls.Find(id);
            if (repairDtl.NotInExceptDevice == "Y") //該案件為統包
            {
                ViewData["HideCost"] = "Y";
            }
            else
            {
                ViewData["HideCost"] = "N";
            }

            int seqno = _context.BMEDRepairCosts.Where(c => c.DocId == id)
                                                .Select(c => c.SeqNo).DefaultIfEmpty().Max();
            cost.DocId = id;
            cost.Qty = 1;   //Default value.
            cost.SeqNo = seqno + 1;
            RepairFlowModel rf = _context.BMEDRepairFlows.Where(f => f.DocId == id)
                                                         .Where(f => f.Status == "?").FirstOrDefault();
            var isEngineer = false;
            if (ur.DptId == "8420" || ur.DptId == "7084")
            {
                isEngineer = true;
            }
            if (!(rf.Cls.Contains("工程師") && rf.UserId == ur.Id))    /* 流程 => 其他 */
            {
                if (rf.Cls.Contains("工程師") && isEngineer == true)   /* 流程 => 工程師，Login User => 非負責之工程師 */
                {
                    return View(cost);
                }
                if (rf.Cls.Contains("醫工主管") || rf.Cls.Contains("賀康主管")) /* 流程 => 醫工、賀康主管 */
                {
                    if (rf.UserId == ur.Id)     
                    {
                        return View(cost);
                    }
                }
                List<RepairCostModel> t = _context.BMEDRepairCosts.Include(r => r.TicketDtl).Where(c => c.DocId == id).ToList();
                return View("List", t);
            }
            /* 流程 => 工程師，Login User => 負責之工程師 */
            return View(cost);
        }
    }
}
