using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.BMED.Components.QueDetails
{
    public class QueDetailsViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<RepairFlowModel, string[]> _repflowRepo;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;

        public QueDetailsViewComponent(ApplicationDbContext context,
                                            IRepository<RepairFlowModel, string[]> repairflowRepo,
                                            IRepository<AppUserModel, int> userRepo,
                                            CustomUserManager customUserManager)
        {
            _context = context;
            _repflowRepo = repairflowRepo;
            _userRepo = userRepo;
            userManager = customUserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            if (id == null)
            {
                id = -1;
            }

            QuestionnaireM questionnaireM = _context.QuestionnaireMs.Find(id);
            return View(questionnaireM);
        }
    }
}
