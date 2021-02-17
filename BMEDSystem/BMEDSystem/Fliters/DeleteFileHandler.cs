using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace EDIS.Fliters
{
    public class DeleteFileHandler : ActionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public DeleteFileHandler(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.OnCompleted(() =>
            {
                return Task.Run(() =>
                {
                    //將當前filter context轉換成具體操作的檔案並獲取檔案路徑
                    string filePath = (filterContext.Result as VirtualFileResult).FileName;
                    string path = _hostingEnvironment.WebRootPath + filePath;
                    //有檔案路徑後就可以直接刪除相關檔案了
                    System.IO.File.Delete(path);
                });
            });
            
        }
    }
}
