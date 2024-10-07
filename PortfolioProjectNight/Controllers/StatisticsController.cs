using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using PortfolioProjectNight.Models;

namespace PortfolioProjectNight.Controllers
{
    public class StatisticsController : Controller
    {

        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            ViewBag.totalMessageCount = context.Contact.Count();

            ViewBag.messageIsReadTrueCount = context.Contact.Where(x => x.IsRead == true).Count();

            ViewBag.messageIsReadFalseCount = context.Contact.Where(x => x.IsRead == false).Count();

            ViewBag.skillCount = context.Skill.Count();

            ViewBag.skillRateSum = context.Skill.Sum(x => x.Rate);

            ViewBag.skillRateAvg = context.Skill.Average(x => x.Rate);

            var maxRate = context.Skill.Max(x => x.Rate);
            ViewBag.maxRateSkillName = context.Skill.Where(x => x.Rate == maxRate).Select(y => y.SkillName).FirstOrDefault();

            ViewBag.getMessageCountBySubjectReferences = context.Contact.Where(x => x.Subject == "Referans").Count();

            ViewBag.getMessageCountByEmailContainAAndIsReadTrue = context.Contact.Where(x => x.IsRead == true && x.Email.Contains("h")).Count();

            ViewBag.getSkillNameByRate90 = context.Skill.Where(x => x.Rate == 90).Select(y => y.SkillName).FirstOrDefault();

            return View();
        }

    }
}


