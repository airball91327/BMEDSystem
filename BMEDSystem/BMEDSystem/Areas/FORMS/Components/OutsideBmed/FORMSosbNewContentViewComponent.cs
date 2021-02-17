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
    public class FORMSosbNewContentViewComponent : ViewComponent
    {
        private readonly BMEDDBContext _db;
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;

        public FORMSosbNewContentViewComponent(BMEDDBContext db,
                                        ApplicationDbContext context,
                                        IRepository<AppUserModel, int> userRepo,
                                        CustomUserManager customUserManager)
        {
            _db = db;
            _context = context;
            _userRepo = userRepo;
            userManager = customUserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            
            Assign assign = new Assign();
            Instrument data = _db.Instruments.Find(id);
            OutsideBmedFlow of = _db.OutsideBmedFlows.Where(o => o.DocId == id).OrderBy(o => o.Rtt == data.ApplyDate).ToList().Last();

            assign.item1 = of.item1;
            assign.item2 = of.item2;
            assign.item3 = of.item3;
            assign.item4 = of.item4;
            assign.item5 = of.item5;
            assign.item6 = of.item6;
            assign.item7 = of.item7;
            assign.Application = data.Application;
            assign.Content = data.Content;

            return View(assign);
        }

    }
}
