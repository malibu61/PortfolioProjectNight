using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ReferenceController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        public ActionResult ReferenceList()
        {
            var values = context.Reference.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateReference()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateReference(Reference reference)
        {
            context.Reference.Add(reference);
            context.SaveChanges();
            return RedirectToAction("ReferenceList");
        }

        public ActionResult DeleteReference(int id)
        {
            var value = context.Reference.Find(id);
            context.Reference.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ReferenceList");
        }

        [HttpGet]
        public ActionResult UpdateReference(int id)
        {
            var value = context.Reference.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateReference(Reference reference)
        {
            var value = context.Reference.Find(reference.ReferenceId);
            value.NameSurname = reference.NameSurname;
            value.Title = reference.Title;
            value.Comment = reference.Comment;
            value.Image = reference.Image;
            context.SaveChanges();
            return RedirectToAction("ReferenceList");
        }
    }
}