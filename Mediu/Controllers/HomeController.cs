using System;
using System.IO;
using System.Web.Mvc;
using Bussines;

namespace Mediu.Controllers
{
    public class HomeController : Controller
    {
        private readonly UploadHandler _uploadHandler;
        private readonly FilesHandler _filesHandler;
        private readonly RdfHandler _rdfHandler;
        public HomeController()
        {
            _uploadHandler=new UploadHandler();
            _filesHandler=new FilesHandler();
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"/Mediu.owl"));
            _rdfHandler = new RdfHandler(path);
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
            string path;

            var file = Request.Files["file"];
            if (file == null)
            {
                ViewBag.UploadMessage = "Failed to upload image";
            }
            else
            {
                ViewBag.UploadMessage = String.Format("Got file {0} of type {1} and size {2}",
                    file.FileName, file.ContentType, file.ContentLength);
                path=_uploadHandler.Upload(file.FileName,file.InputStream);
                _filesHandler.AddFile(path);
            }
            return View("Index");
        }

        public ActionResult GetProblemeDeMediu()
        {
            var result=_rdfHandler.GetProblemeDeMediu();
            return View(result);
        }

        public ActionResult GetSectoareSiActivitati()
        {
            var result = _rdfHandler.GetSectoareSiActivitati();
            return View(result);
        }
    }
}
