using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcproje.Controllers
{
    public class WriterMessageController : Controller
    {
        // GET: WriterMessage

        MessageManager ms = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendBox()
        {
            var messageList = ms.GetListSendBox();
            return View(messageList);
        }
        public ActionResult Inbox()
        {
            var messageList = ms.GetListInbox();

            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();

        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = ms.GetByID(id);
            return View(values);

        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = ms.GetByID(id);
            return View(values);

        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message m)
        {

            ValidationResult results = messagevalidator.Validate(m);


            if (results.IsValid)
            {
                m.SenderMail = "admin@gmail.com";
                m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                ms.MessageAdd(m);
                return RedirectToAction("SendBox");
            }
            else
            {

                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }
    }
}