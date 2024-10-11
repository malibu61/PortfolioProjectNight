using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PortfolioProjectNight.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult PartialHead()
        {

            return PartialView();

        }

        public PartialViewResult PartialSidebar()
        {

            return PartialView();

        }

        public PartialViewResult PartialNavbar()
        {

            return PartialView();

        }

        public PartialViewResult PartialScripts()
        {

            return PartialView();

        }

        public ActionResult LogOut()
        {
            return Content(@"<body>
                       <script type='text/javascript'>
                         window.close();
                       </script>
                     </body> ");
        }
    }
}