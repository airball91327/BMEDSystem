using EDIS.Areas.FORMS.Data;
using EDIS.Areas.FORMS.Models;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.FORMS.Components.OutsideBmed
{
    public class FORMSOsbFlowListViewComponent : ViewComponent
    {
        private readonly BMEDDBContext _db;
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;

        public FORMSOsbFlowListViewComponent(BMEDDBContext db,
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
            OutsideBmedFlowModel fw = new OutsideBmedFlowModel();
            List<OutsideBmedFlowModel> flows = new List<OutsideBmedFlowModel>();

            _db.OutsideBmedFlows.Where(f => f.DocId == id)
                .Join(_db.Instruments, f => f.DocId, a => a.DocId,
                (f, a) => new
                {   
                    DocId = f.DocId,
                    StepId = f.StepId,
                    UserId = f.UserId,
                    UserName = f.UserName,
                    Opinions = a.Description,
                    Status = f.Status,
                    Rtt = f.Rtt,
                    Rtp = f.Rtp,
                    Cls = f.Cls
                }).ToList()
                .ForEach(f =>
                {
                    flows.Add(new OutsideBmedFlowModel
                    {
                        DocId = f.DocId,
                        StepId = f.StepId,
                        UserId = f.UserId,
                        UserName = _db.AppUsers.Find(f.UserId).FullName,
                        Opinions = f.Opinions,
                        Status = f.Status,
                        Rtt = f.Rtt,
                        Rtp = f.Rtp,
                        Cls = f.Cls
                    });
                });
            flows = flows.OrderBy(f => f.StepId).ToList();

            foreach (var item in flows)
            {
                if (item.Status != "?")
                {
                    if (item.UserId != item.Rtp)
                    {
                        item.UserName += "(" + _context.AppUsers.Find(item.Rtp).FullName + "代替)";
                    }
                }
            }

            return View(flows);
        }
    }
}
