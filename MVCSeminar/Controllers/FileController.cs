using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSeminar.Controllers
{
    public class FileController : Controller
    {


        // GET: File
        public ActionResult Index()
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/TextFiles"));
            //Console.WriteLine(files[0].)           
            for(int i = 0; i < files.Length; ++i)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]);
            }
            return View(files);
        }

        public ActionResult Content(string id)
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/TextFiles"));
            string file = "";
            for(int i = 0; i < files.Length; ++i)
            {
                file = Path.GetFileName(files[i]);
                if (file.Contains(id))
                {
                    break;
                }
            }
            string text = System.IO.File.ReadAllText(Server.MapPath("~/TextFiles") + "/" + file);
            return View("Content", (object)text);
        }
    }    
}