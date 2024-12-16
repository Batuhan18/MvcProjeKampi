using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult Sendbox(string p)
        {
            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var writer in results.Errors)
                {
                    ModelState.AddModelError(writer.PropertyName, writer.ErrorMessage);
                }
            }

            return View();
        }
    }
}