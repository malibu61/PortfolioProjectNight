using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class WorkController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        public ActionResult WorkList()
        {
            var values = context.Works.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateWork()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWork(Works works)
        {
            context.Works.Add(works);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        public ActionResult DeleteWork(int id)
        {
            var value = context.Works.Find(id);
            context.Works.Remove(value);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        [HttpGet]
        public ActionResult UpdateWork(int id)
        {
            var value = context.Works.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateWork(Works works)
        {
            var value = context.Works.Find(works.WorkId);
            value.Title = works.Title;
            value.Description = works.Description;
            value.ImageUrl = works.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
    }
}