using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.BMED.Components.QuestTitles
{
    public class QuestTitlesViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<RepairFlowModel, string[]> _repflowRepo;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;

        public QuestTitlesViewComponent(ApplicationDbContext context,
                                            IRepository<RepairFlowModel, string[]> repairflowRepo,
                                            IRepository<AppUserModel, int> userRepo,
                                            CustomUserManager customUserManager)
        {
            _context = context;
            _repflowRepo = repairflowRepo;
            _userRepo = userRepo;
            userManager = customUserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(ReportQryVModel v)
        {
            var titles = _context.QuestionnaireMs
               .Where(m => m.Flg == "Y" && m.Qname == v.Qname)
               .Join(_context.Questionnaires, 
                       m => m.VerId, 
                       q => q.VerId,
                       (m, q) => q)
               .Where(m => m.Required == "Y")
               .OrderBy(q => q.Qid)
               .Select(q => q.Qtitle);

            return View(titles);
        }
    }
}
