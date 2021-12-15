using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mvcproje.Controllers
{
    public class WriterContentController : Controller
    {
        // GET: WriterContent
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (String)Session["WriterMail"]; //p değeri dışarıdan değişken olarak verilir.
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y =>y.WriterID).FirstOrDefault(); //dışarıdan gönderilen parametreye 


            //Böylece sisteme kim girerse onun bilgisini getirir.
            var contentvalues = cm.GetListByWriter(writeridinfo); //dışarıdan gelen idye göre
            return View(contentvalues);
           
        }
        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {

            String mail = (String)Session["WriterMail"]; //mail değeri dışarıdan değişken olarak verilir.
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault(); //dışarıdan gönderilen parametreye 

            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}