using EntityLayer.Concrete;
using DataAccsessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcproje.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();

            //FirstOrDefault  sadece bir değer döndürür.
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminUserPassword == p.AdminUserPassword);
          
            if(adminuserinfo != null)
            {
                //false sürekli,kalıcı bir kullanıcı oluşturulmasın anlamındadır.
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName; //sessionname ismi sisteme giriş yapmaya çalışan isimle aynı mı diye kontrol edilir.

                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            
        }


        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
          {

            Context c = new Context();
            //FirstOrDefault  sadece bir değer döndürür.
            var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            if (writeruserinfo != null)
            {
                //false sürekli,kalıcı bir kullanıcı oluşturulmasın anlamındadır.
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail; //sessionname ismi sisteme giriş yapmaya çalışan isimle aynı mı diye kontrol edilir.

                return RedirectToAction("MyContent", "UserWriter");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
    }
}