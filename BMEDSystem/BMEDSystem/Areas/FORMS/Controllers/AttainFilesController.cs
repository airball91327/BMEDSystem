using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDIS.Areas.FORMS.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Linq;
using EDIS.Areas.FORMS.Data;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EDIS.Areas.FORMS.Controllers
{
    public class AttainFilesController : Controller
    {
        private BMEDDBContext db = new BMEDDBContext();
        // GET: AttainFiles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(string doctype, string docid)
        {
            AttainFile attainFile = new AttainFile();
            attainFile.DocType = doctype;
            attainFile.DocId = docid;
            attainFile.SeqNo = 1;
            attainFile.IsPublic = "N";

            return PartialView(attainFile);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(AttainFile attainFile)
        {
            if (ModelState.IsValid)
            {
           
                try
                {
                    //AppUser appUser = db.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                    //接收文件
                    //HttpPostedFileBase file = Request.Files[0];
                    //文件扩展名
                    //string extension = Path.GetExtension(file.FileName);
                    string s = "/Files/OutsideBmed";
#if DEBUG
                    s = "/Files";
#endif
                    switch (attainFile.DocType)
                    {
                        case "OutsideBmed":
                            s += "/OutsideBmed";
                            break;
                       
                        default:
                            s += "/Sign";
                            break;
                    }
                    var i = db.AttainFiles
                        .Where(a => a.DocType == attainFile.DocType)
                        .Where(a => a.DocId == attainFile.DocId).ToList();
                    attainFile.SeqNo = i.Count == 0 ? 1 : i.Select(a => a.SeqNo).Max() + 1;

                    string path = Path.Combine(@"D:\" + s + attainFile.DocId + "_"
                    + attainFile.SeqNo.ToString() + Path.GetExtension(Request.Form.Files[0].FileName));
                    // Upload files.
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Request.Form.Files[0].CopyToAsync(stream);
                    }
                    string filelink = attainFile.DocId + "_"
                    + attainFile.SeqNo.ToString() + Path.GetExtension(Request.Form.Files[0].FileName);

                    switch (attainFile.DocType)
                    {
                        case "OutsideBmed":
                            attainFile.FileLink = "OutsideBmed/" + filelink;
                            break;
                        
                        default:
                            attainFile.FileLink = "Sign/" + filelink;
                            break;
                    }
                    attainFile.Rtt = DateTime.Now;
                    attainFile.Rtp = 123456;
                    db.AttainFiles.Add(attainFile);
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }

            return new JsonResult(new
            {
                Data = new { success = true, error = "" }
            });
        }

        public ActionResult List(string id = null, string typ = null)
        {
            List<AttainFile> af = new List<AttainFile>();
            
            af = db.AttainFiles.Where(f => f.DocType == typ).Where(f => f.DocId == id).ToList();
            foreach (AttainFile a in af)
            {               
                    a.UserName = "王曉明";
            }

            return PartialView(af);
        }

        public ActionResult PreviewList(string id = null, string typ = null)
        {
            List<AttainFile> af = new List<AttainFile>();
            //AppUser u;
            af = db.AttainFiles.Where(f => f.DocType == typ).Where(f => f.DocId == id).ToList();
            foreach (AttainFile a in af)
            {
                a.UserName = "王曉明";
            }

            return PartialView(af);
        }

        public ActionResult Delete(string id = null, int seq = 0, string typ = null)
        {
            AttainFile attainfiles = db.AttainFiles.Find(typ, id, seq);
            string path1 = Path.Combine(@"D:\" + "/Files/OutsideBmed/");
            if (attainfiles != null)
            {
                FileInfo ff;
                try
                {
                    if (typ == "2")
                    {
                        ff = new FileInfo(Path.Combine(path1, attainfiles.FileLink.Replace("Files/", "")));
                        ff.Delete();
                    }
                    else
                    {
                        ff = new FileInfo(Path.Combine(path1, attainfiles.FileLink));
                        ff.Delete();
                    }
                }
                catch (Exception e)
                {
                    return Content(e.Message);
                }
                db.AttainFiles.Remove(attainfiles);
                db.SaveChanges();
            }
            List<AttainFile> af = db.AttainFiles.Where(f => f.DocId == id)
                    .Where(f => f.DocType == typ).ToList();

            return PartialView("List", af);
        }

    }
}