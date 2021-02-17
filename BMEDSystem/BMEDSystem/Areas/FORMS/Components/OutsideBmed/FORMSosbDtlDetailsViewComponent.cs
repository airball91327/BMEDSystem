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
    public class FORMSosbDtlDetailsViewComponent : ViewComponent
    {
        private readonly BMEDDBContext _db;
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly CustomUserManager userManager;

        public FORMSosbDtlDetailsViewComponent( BMEDDBContext db,
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
            Instrument signData = _db.Instruments.Find(id);
            signData.UseUnit = _context.Departments.Where(d => d.DptId == signData.UseUnit).Select(d => d.Name_C).FirstOrDefault();
            return View(signData);
        }

    }
}
