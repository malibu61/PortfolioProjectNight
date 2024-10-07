using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Collections;
using System.Web.Helpers;


namespace PortfolioProjectNight.Controllers
{
    public class SkillController : Controller
    {

        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        public ActionResult SkillList(int page = 1)
        {
            var values = context.Skill.ToList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var value = context.Skill.Find(skill.SkillId);
            value.SkillName = skill.SkillName;
            value.Rate = skill.Rate;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult SkillsGraphic()
        {
            return Json(SkillGraphicStatistic(), JsonRequestBehavior.AllowGet);
        }

        public List<Models.Skill> SkillGraphicStatistic()
        {
            List<Models.Skill> GraphicSkillList = new List<Models.Skill>();
            GraphicSkillList = context.Skill.Select(x => new Models.Skill
            {
                SkillName = x.SkillName,
                Rate = x.Rate
            }).ToList();
            return GraphicSkillList;
        }

        public ActionResult SkillStatisticIndex()
        {
            var values = context.Skill.ToList();
            return View(values);
        }

        public ActionResult SkillStatisticGraphic2()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var values = context.Skill.ToList();
            values.ToList().ForEach(x => xvalue.Add(x.SkillName));
            values.ToList().ForEach(y => yvalue.Add(y.Rate));
            var graphic = new Chart(width: 1000, height: 500).AddTitle("Yetenekler").AddSeries(chartType: "Column", name: "Yetenek", xValue: xvalue, yValues: yvalue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");
        }
    }
}