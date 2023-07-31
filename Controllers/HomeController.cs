using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MyFiles()
        {
            string mypath = ControllerContext.HttpContext.Server.MapPath("~/Farahmand");
            DirectoryInfo dirInfo = new DirectoryInfo(mypath);
            List<FileInfo> files = dirInfo.GetFiles().ToList();
            return View(files);
        }


        public FileResult DownloadFile( string filename)
        {
            string path = Server.MapPath("~/Farahmand/") + filename;
            //read the file to byte array
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            // send file to download
            return File(bytes, "application/octet-stream", filename);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}