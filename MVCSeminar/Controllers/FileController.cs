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
                files[i] = Path.GetFileName(files[i]);
            }
            return View(files);
        }

        public ActionResult Content(int id)
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/TextFiles"));
            string file;
            int num = 0;
            for(int i = 0; i < files.Length; ++i)
            {
                file = Path.GetFileName(files[i]);
                if (file.Contains(id + ""))
                {
                    num = i;
                    break;
                }
            }
            string text = System.IO.File.ReadAllText(files[num]);
            return View("Content", (object)text);
        }
    }    
}