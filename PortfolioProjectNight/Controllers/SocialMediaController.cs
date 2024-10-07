using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var values = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(values);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialmedia)
        {
            context.SocialMedia.Add(socialmedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values = context.SocialMedia.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var values= context.SocialMedia.Find(socialMedia.SocialMediaId);
            values.Title=socialMedia.Title;
            values.Url=socialMedia.Url;
            values.Icon=socialMedia.Icon;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}