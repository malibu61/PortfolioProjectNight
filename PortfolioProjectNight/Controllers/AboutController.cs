using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class AboutController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        // GET: About

        public ActionResult AboutList()
        {
            var values = context.About.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.About.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.About.Find(about.AboutId);
            value.Title = about.Title;
            value.Description = about.Description;
            value.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }

}