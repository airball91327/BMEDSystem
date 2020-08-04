using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EDIS.Models;


using EDIS.Models.Identity;
using EDIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class DeviceClassCodeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceClassCodeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetDataByKeyname(string keyname)
        {
            List<DeviceClassCode> ul = new List<DeviceClassCode>();
            string s = "";
            if (string.IsNullOrEmpty(keyname))
                ul = _context.BMEDDeviceClassCodes.ToList();
            else
            {
                if (_context.BMEDDeviceClassCodes.Find(keyname) != null)
                    ul.Add(_context.BMEDDeviceClassCodes.Find(keyname));
                ul.AddRange(_context.BMEDDeviceClassCodes.Where(p => p.M_name.Contains(keyname)).ToList());
            }
            s = JsonConvert.SerializeObject(ul);
            return Json(s);
        }
    }
}