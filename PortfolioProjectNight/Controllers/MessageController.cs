using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class MessageController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Inbox()
        {
            var values = context.Contact.ToList();
            return View(values);
        }

        public ActionResult MessageDetails(int id=1)
        {
            var values = context.Contact.Find(id);
            values.IsRead = true;
            context.SaveChanges();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var values = context.Contact.Find(id);
            context.Contact.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

    }
}