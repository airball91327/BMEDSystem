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
using EDIS.Models;
using EDIS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EDIS.Areas.FORMS.Controllers
{
    [Area("FORMS")]
    [Authorize]
    public class AttainFilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BMEDDBContext _db;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AttainFilesController(BMEDDBContext db,
                                     ApplicationDbContext context,
                                    IRepository<AppUserModel, int> userRepo,
                                    IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _context = context;
            _userRepo = userRepo;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: AttainFile
        public async Task<IActionResult> Index()
        {
            return View(await _db.AttainFiles.ToListAsync());
        }

        // GET: /FROMS/AttainFile/Create
        public IActionResult Create(string id = null, string typ = null, string title = null, int? vendorId = null)
        {
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            AttainFile a = new AttainFile();
            a.DocType = typ;
            a.DocId = id;
            a.Title = title;
            if (typ == "3" && vendorId != null)
                a.Rtp = vendorId;
            else
                a.Rtp = ur.Id;
            a.Rtt = DateTime.Now;
            return View(a);
        }

        // POST: /AttainFiles/Create
        [HttpPost]
        public async Task<IActionResult> Create(AttainFile attainFile, IEnumerable<IFormFile> file)
        {
            //目前使用者資料
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();

            //文件臨時位置的完整路徑
            var filePath = Path.GetTempFileName();

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
                            s += "/OutsideBmed/";
                            break;

                        default:
                            s += "/Sign/";
                            break;
                    }
                    var i = _db.AttainFiles
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
                    attainFile.Rtp = ur.Id;
                    _db.AttainFiles.Add(attainFile);
                    _db.SaveChanges();

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

        

        [HttpPost]
        public async Task<IActionResult> Upload(AttainFile attainFile)
        {
            //目前使用者資料
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
           // long size = attainFile.Files.Sum(f => f.Length);

            //文件臨時位置的完整路徑
            var filePath = Path.GetTempFileName();

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
                    s = "Files";
#endif
                    switch (attainFile.DocType)
                    {
                        case "3":
                            s += "/OutsideBmed/";
                            break;
                       
                        default:
                            s += "/Sign/";
                            break;
                    }
                    var i = _db.AttainFiles
                        .Where(a => a.DocType == attainFile.DocType)
                        .Where(a => a.DocId == attainFile.DocId).ToList();
                    attainFile.SeqNo = i.Count == 0 ? 1 : i.Select(a => a.SeqNo).Max() + 1;

                    string path = Path.Combine(@"C:\" + s + attainFile.DocId + "_"
                    + attainFile.SeqNo.ToString() + Path.GetExtension(attainFile.Files[0].FileName));
                    // Upload files.
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Request.Form.Files[0].CopyToAsync(stream);
                    }
                    string filelink = attainFile.DocId + "_"
                    + attainFile.SeqNo.ToString() + Path.GetExtension(attainFile.Files[0].FileName);

                    switch (attainFile.DocType)
                    {
                        case "3":
                            attainFile.FileLink = "OutsideBmed/" + filelink;
                            break;
                        
                        default:
                            attainFile.FileLink = "Sign/" + filelink;
                            break;
                    }
                    attainFile.Rtt = DateTime.Now;
                    attainFile.Rtp = ur.Id;
                    //attainFile.FileLink = attainFile.Files[0].FileName;
                    _db.AttainFiles.Add(attainFile);
                    _db.SaveChanges();

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

        public IActionResult List(string docid = null, string typ = null)
        {
            List<AttainFile> af = new List<AttainFile>();
            af = _db.AttainFiles.Where(f => f.DocType == typ).Where(f => f.DocId == docid).ToList();
            return PartialView(af);
        }

        public IActionResult PreviewList(string id = null, string typ = null)
        {
            List<AttainFile> af = new List<AttainFile>();
            af = _db.AttainFiles.Where(f => f.DocType == typ).Where(f => f.DocId == id).ToList();
            return PartialView(af); 
        }

        public IActionResult Delete(string id = null, int seq = 0, string typ = null)
        {
            AttainFile attainfile = _db.AttainFiles.Find(typ, id, seq);
            if (attainfile == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    string WebRootPath = _hostingEnvironment.WebRootPath;
                    string filePath = Path.Combine(@"C:\" + "Files/");
                    FileInfo ff = new FileInfo(Path.Combine(filePath, attainfile.FileLink));
                    ff.Delete();
                    _db.AttainFiles.Remove(attainfile);
                    _db.SaveChanges();
                    //return Json(new { msg = "儲存成功!" }, JsonRequestBehavior.AllowGet);
                    return Content("");
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
        }

    }
}