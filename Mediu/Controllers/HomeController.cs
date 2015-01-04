using System;
using System.Web;
using System.Web.Mvc;
using Bussines;

namespace Mediu.Controllers
{
    public class HomeController : Controller
    {
        private readonly UploadHandler _uploadHandler;

        public HomeController()
        {
            _uploadHandler=new UploadHandler();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Load()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Loadd()
        {
            string path = @"D:\Temp\";

            var file = Request.Files["file"];
            if (file == null)
            {
                ViewBag.UploadMessage = "Failed to upload image";
            }
            else
            {
                ViewBag.UploadMessage = String.Format("Got image {0} of type {1} and size {2}",
                    file.FileName, file.ContentType, file.ContentLength);
                _uploadHandler.Upload(file.FileName,file.InputStream);
            }
            return View("Index");
        }
    }
}
