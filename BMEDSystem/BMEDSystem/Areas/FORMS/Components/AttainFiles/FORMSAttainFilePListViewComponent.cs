using EDIS.Areas.FORMS.Data;
using EDIS.Areas.FORMS.Models;
using EDIS.Models;
using EDIS.Models.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EDIS.Areas.FORMS.Components.AttainFiles
{
    public class FORMSAttainFilePListViewComponent : ViewComponent
    {
        private readonly BMEDDBContext _context;

        public FORMSAttainFilePListViewComponent(BMEDDBContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id = null, string typ = null, string viewType = null)
        {
            List<AttainFile> af = new List<AttainFile>();
            //List<AttainFile> af2 = new List<AttainFile>();

            if (id != null)
            {
                //AppUserModel u;
                //int uno = Convert.ToInt32(uniteno);
                af = _context.AttainFiles.Where(f => f.DocType == typ).Where(f => f.DocId == id).ToList();

            }
            else
            {
                AppUserModel u;
                af = _context.AttainFiles.ToList();
                foreach (AttainFile a in af)
                {
                    if (a.Rtp != null)
                    {
                        u = _context.AppUsers.Find(a.Rtp);
                        a.UserName = u.FullName;
                    }
                }
            }
            return View(af);
        }
    }
}
