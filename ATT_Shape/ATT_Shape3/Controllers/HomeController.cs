using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATT_Shape3.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

		public ActionResult ChannelDemo()
		{
			return View();
		}

        public ActionResult VideoWidgetTest()
        {
            return View();
        }

        public ActionResult MeetUpWidgetTest()
        {
            return View();
        }

        public ActionResult NewsPage()
        {
            return View();
        }
        public ActionResult ProfileView()
        {
            return View();
        }
    }
}