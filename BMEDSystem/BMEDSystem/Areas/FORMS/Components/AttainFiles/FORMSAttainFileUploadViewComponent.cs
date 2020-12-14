using EDIS.Areas.FORMS.Models;
using EDIS.Models;
using EDIS.Models.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.FROMS.Components.AttainFiles
{
    public class FORMSAttainFileUploadViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string doctype, string docid, string viewType)
        {
            AttainFile attainFile = new AttainFile();
            attainFile.DocType = doctype;
            attainFile.DocId = docid;
            attainFile.SeqNo = 2;
            attainFile.IsPublic = "N";
            attainFile.FileLink = "default";

            if (viewType == "AjaxView")
            {
                return View("AjaxView", attainFile);
            }
            return View(attainFile);
        }
    }
}
