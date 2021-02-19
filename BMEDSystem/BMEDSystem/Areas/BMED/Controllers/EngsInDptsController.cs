using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDIS.Models;
using EDIS.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using EDIS.Repositories;
using System.Data;
using OfficeOpenXml;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class EngsInDptsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomRoleManager roleManager;
        private readonly IRepository<AppUserModel, int> _userRepo;


        public EngsInDptsController(ApplicationDbContext context,
                                    CustomRoleManager customRoleManager,
                                     IRepository<AppUserModel, int> userRepo
                                   )
        {
            _context = context;
            roleManager = customRoleManager;
            _userRepo = userRepo;
        }

        // GET: BMED/EngsInDpts
        public async Task<IActionResult> Index()
        {
            List<EngsInDptsViewModel> vmodel = new List<EngsInDptsViewModel>();
            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            var urLocation = new DepartmentModel(_context).GetUserLocation(ur);

            var dpt = GetDepartmentsByLoc(urLocation);

            _context.EngsInDpts.Include(e => e.AppUsers)
                                .Join(dpt, e => e.AccDptId, d => d.DptId,
                                (e, d) => new 
                                { 
                                    engsInDpts = e,
                                    department = d
                                }).ToList()
                                .ForEach(e => vmodel.Add(new EngsInDptsViewModel()
                                {
                                    DptName = e.department.Name_C,
                                    DptId = e.department.DptId,
                                    EngId = e.engsInDpts.EngId,
                                    EngName = e.engsInDpts.AppUsers.FullName,
                                    EngUserName = e.engsInDpts.UserName,
                                    RtpName = e.engsInDpts.Rtp == null ? "" : _context.AppUsers.Find(e.engsInDpts.Rtp).FullName,
                                    Rtt = e.engsInDpts.Rtt,
                                    AppUsers = e.engsInDpts.AppUsers
                                }));
            return View(vmodel);
        }

        public List<EngsInDptsViewModel> IndexValue()
        {
            List<EngsInDptsViewModel> vmodel = new List<EngsInDptsViewModel>();
            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            var urLocation = new DepartmentModel(_context).GetUserLocation(ur);

            var dpt = GetDepartmentsByLoc(urLocation);

            _context.EngsInDpts.Include(e => e.AppUsers)
                                .Join(dpt, e => e.AccDptId, d => d.DptId,
                                (e, d) => new
                                {
                                    engsInDpts = e,
                                    department = d
                                }).ToList()
                                .ForEach(e => vmodel.Add(new EngsInDptsViewModel()
                                {
                                    DptName = e.department.Name_C,
                                    DptId = e.department.DptId,
                                    EngId = e.engsInDpts.EngId,
                                    EngName = e.engsInDpts.AppUsers.FullName,
                                    EngUserName = e.engsInDpts.UserName,
                                    RtpName = e.engsInDpts.Rtp == null ? "" : _context.AppUsers.Find(e.engsInDpts.Rtp).FullName,
                                    Rtt = e.engsInDpts.Rtt,
                                    AppUsers = e.engsInDpts.AppUsers
                                }));
            return vmodel;
        }

        public IActionResult ExcelIndex()
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("部門代號");
            dt.Columns.Add("部門名稱");
            dt.Columns.Add("負責工程師");
            dt.Columns.Add("工程師代號");
            dt.Columns.Add("異動人員");
            dt.Columns.Add("異動時間");
            

            List<EngsInDptsViewModel>  mv = IndexValue();
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.DptId;
                dw[1] = m.DptName;
                dw[2] = m.EngName;
                dw[3] = m.EngUserName;
                dw[4] = m.RtpName;
                dw[5] = m.Rtt;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("部門對應工程師");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Excel.xlsx"
            );
        }

        // GET: BMED/EngsInDpts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engsInDptsModel = await _context.EngsInDpts
                .Include(e => e.AppUsers)
                .FirstOrDefaultAsync(m => m.AccDptId == id);
            if (engsInDptsModel == null)
            {
                return NotFound();
            }

            return View(engsInDptsModel);
        }

        // GET: BMED/EngsInDpts/Create
        public IActionResult Create()
        {
            // Get all Med Engineers to dropdownlist.
            List<SelectListItem> list = new List<SelectListItem>();
            List<string> s = new List<string>();
            SelectListItem li;
            AppUserModel u;
            s = roleManager.GetUsersInRole("MedEngineer").ToList();
            list = new List<SelectListItem>();
            if (s.Count() > 0)
            {
                foreach (string l in s)
                {
                    u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                    if (u != null)
                    {
                        li = new SelectListItem();
                        li.Text = u.FullName + "(" + u.UserName + ")";
                        li.Value = u.Id.ToString();
                        list.Add(li);
                    }
                }
            }
            ViewData["EngId"] = new SelectList(list, "Value", "Text");
            // Get all departments.
            //var dptList = new[] { "K", "P", "C" };   //本院部門
            //var departments = _context.Departments.Where(d => dptList.Contains(d.Loc)).ToList();
            var departments = _context.Departments.ToList();
            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (var item in departments)
            {
                listItem.Add(new SelectListItem
                {
                    Text = item.Name_C + "(" + item.DptId + ")",
                    Value = item.DptId
                });
            }
            ViewData["AccDptId"] = new SelectList(listItem, "Value", "Text");

            return View();
        }

        // POST: BMED/EngsInDpts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccDptId,EngId")] EngsInDptsModel engsInDptsModel)
        {

            ModelState.Remove("UserName");
            if (ModelState.IsValid)
            {
                var isExist = _context.EngsInDpts.Find(engsInDptsModel.AccDptId, engsInDptsModel.EngId);
                if (isExist != null)    // Data is already in DB.
                {
                    ModelState.AddModelError("", "該部門已設定相同工程師!");
                }
                else
                {
                    engsInDptsModel.UserName = _context.AppUsers.Find(engsInDptsModel.EngId).UserName;
                    engsInDptsModel.Rtp = _context.AppUsers.Where(a => a.UserName == User.Identity.Name).First().Id;
                    engsInDptsModel.Rtt = DateTime.Now;
                    _context.Add(engsInDptsModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            //
            // Get all Med Engineers to dropdownlist.
            List<SelectListItem> list = new List<SelectListItem>();
            List<string> s = new List<string>();
            SelectListItem li;
            AppUserModel u;
            s = roleManager.GetUsersInRole("MedEngineer").ToList();
            list = new List<SelectListItem>();
            if (s.Count() > 0)
            {
                foreach (string l in s)
                {
                    u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                    if (u != null)
                    {
                        li = new SelectListItem();
                        li.Text = u.FullName + "(" + u.UserName + ")";
                        li.Value = u.Id.ToString();
                        list.Add(li);
                    }
                }
            }
            ViewData["EngId"] = new SelectList(list, "Value", "Text");
            // Get all departments.
            //var dptList = new[] { "K", "P", "C" };   //本院部門
            //var departments = _context.Departments.Where(d => dptList.Contains(d.Loc)).ToList();
            var departments = _context.Departments.ToList();
            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (var item in departments)
            {
                listItem.Add(new SelectListItem
                {
                    Text = item.Name_C + "(" + item.DptId + ")",
                    Value = item.DptId
                });
            }
            ViewData["AccDptId"] = new SelectList(listItem, "Value", "Text");
            return View(engsInDptsModel);
        }

        // GET: BMED/EngsInDpts/Edit/5
        public async Task<IActionResult> Edit(string AccDptId, string EngId)
        {
            if (AccDptId == null || EngId == null)
            {
                return NotFound();
            }
            //
            int engId = Convert.ToInt32(EngId);
            var engsInDptsModel = await _context.EngsInDpts.FindAsync(AccDptId, engId);
            if (engsInDptsModel == null)
            {
                return NotFound();
            }
            //
            engsInDptsModel.DptName = _context.Departments.Find(engsInDptsModel.AccDptId).Name_C;
            engsInDptsModel.EngIdOrigin = engId;
            // Get all Med Engineers to dropdownlist.
            List<SelectListItem> list = new List<SelectListItem>();
            List<string> s = new List<string>();
            SelectListItem li;
            AppUserModel u;
            s = roleManager.GetUsersInRole("MedEngineer").ToList();
            list = new List<SelectListItem>();
            if (s.Count() > 0)
            {
                foreach (string l in s)
                {
                    u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                    if (u != null)
                    {
                        li = new SelectListItem();
                        li.Text = u.FullName + "(" + u.UserName + ")";
                        li.Value = u.Id.ToString();
                        list.Add(li);
                    }
                }
            }
            ViewData["EngId"] = new SelectList(list, "Value", "Text", engsInDptsModel.EngId);
            return View(engsInDptsModel);
        }

        // POST: BMED/EngsInDpts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("AccDptId,EngId,EngIdOrigin,DptName")] EngsInDptsModel engsInDptsModel)
        {
            var usr = _context.AppUsers.Find(engsInDptsModel.EngId);
            if (usr != null)
            {
                engsInDptsModel.UserName = usr.UserName;
                ModelState.Remove("UserName");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var isExist = _context.EngsInDpts.Find(engsInDptsModel.AccDptId, engsInDptsModel.EngId);
                    if (isExist != null)    // Data is already in DB.
                    {
                        ModelState.AddModelError("", "該部門已設定相同工程師!");
                    }
                    else
                    {
                        // Get origin data and delete.
                        var originModel = _context.EngsInDpts.Find(engsInDptsModel.AccDptId, engsInDptsModel.EngIdOrigin);
                        _context.EngsInDpts.Remove(originModel);
                        // Add new data.
                        engsInDptsModel.Rtp = _context.AppUsers.Where(a => a.UserName == User.Identity.Name).First().Id;
                        engsInDptsModel.Rtt = DateTime.Now;
                        _context.EngsInDpts.Add(engsInDptsModel);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngsInDptsModelExists(engsInDptsModel.AccDptId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            // Get all Med Engineers to dropdownlist.
            List<SelectListItem> list = new List<SelectListItem>();
            List<string> s = new List<string>();
            SelectListItem li;
            AppUserModel u;
            s = roleManager.GetUsersInRole("MedEngineer").ToList();
            list = new List<SelectListItem>();
            if (s.Count() > 0)
            {
                foreach (string l in s)
                {
                    u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                    if (u != null)
                    {
                        li = new SelectListItem();
                        li.Text = u.FullName + "(" + u.UserName + ")";
                        li.Value = u.Id.ToString();
                        list.Add(li);
                    }
                }
            }
            ViewData["EngId"] = new SelectList(list, "Value", "Text", engsInDptsModel.EngId);
            //            
            engsInDptsModel.DptName = _context.Departments.Find(engsInDptsModel.AccDptId).Name_C;
            return View(engsInDptsModel);
        }

        // GET: BMED/EngsInDpts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engsInDptsModel = await _context.EngsInDpts
                .Include(e => e.AppUsers)
                .FirstOrDefaultAsync(m => m.AccDptId == id);
            if (engsInDptsModel == null)
            {
                return NotFound();
            }

            return View(engsInDptsModel);
        }

        // POST: BMED/EngsInDpts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var engsInDptsModel = await _context.EngsInDpts.FindAsync(id);
            _context.EngsInDpts.Remove(engsInDptsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Get Departments by location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartmentsByLoc(string location)
        {
            List<DepartmentModel> departments = null;
            if (location == "總院")
            {
                departments = _context.Departments.Where(d => d.Loc == "C" || d.Loc == "P" || d.Loc == "K").ToList();
            }
            else
            {
                departments = _context.Departments.Where(d => d.Loc == location).ToList();
            }
            return departments;
        }

        private bool EngsInDptsModelExists(string id)
        {
            return _context.EngsInDpts.Any(e => e.AccDptId == id);
        }
    }
}
