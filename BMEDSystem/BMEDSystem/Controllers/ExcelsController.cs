using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Fliters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EDIS.Controllers
{
    public class ExcelsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ExcelsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [TypeFilter(typeof(DeleteFileHandler))] //下載完後自動刪除檔案
        public ActionResult Download(string file)
        {
            var path = _hostingEnvironment.WebRootPath + @"\Files";
            //到伺服器臨時檔案目錄下載相應的檔案
            string fullPath = "/Files/" + file;
            //返回檔案物件，這裡用的是Excel，所以檔案頭使用了 "application/vnd.ms-excel"
            return File(fullPath, "application/vnd.ms-excel", file);
        }
    }
}
