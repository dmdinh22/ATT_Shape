using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATT_Shape3.Controllers
{
	[RoutePrefix("Channels")]
    public class ChannelsController : Controller
    {
		public ActionResult Food()
		{
			return View();
		}

		public ActionResult Cars()
		{
			return View();
		}

		public ActionResult Code()
		{
			return View();
		}

		public ActionResult Music()
		{
			return View();
		}

		public ActionResult Travel()
		{
			return View();
		}

		public ActionResult Film()
		{
			return View();
		}
		
		public ActionResult CodeCategory()
		{
			return View();
		}

		[Route("CodeChannel/Java")]
		public ActionResult Java()
		{
			return View("~/Views/Channels/Code/Java.cshtml");
		}

		[Route("CodeChannel/CSharp")]
		public ActionResult CSharp()
		{
			return View("~/Views/Channels/Code/CSharp.cshtml");
		}

		[Route("CodeChannel/Javascript")]
		public ActionResult Javascript()
		{
			return View("~/Views/Channels/Code/Javascript.cshtml");
		}

		[Route("CodeChannel/Python")]
		public ActionResult Python()
		{
			return View("~/Views/Channels/Code/Python.cshtml");
		}

		[Route("CodeChannel/React")]
		public ActionResult React()
		{
			return View("~/Views/Channels/Code/React.cshtml");
		}

		[Route("CodeChannel/SQLServer")]
		public ActionResult SQLServer()
		{
			return View("~/Views/Channels/Code/SQLServer.cshtml");
		}

		public ActionResult CookingCategory()
		{
			return View();
		}

		[Route("CookingChannel/American")]
		public ActionResult American()
		{
			return View("~/Views/Channels/Cooking/American.cshtml");
		}

		[Route("CookingChannel/French")]
		public ActionResult French()
		{
			return View("~/Views/Channels/Cooking/French.cshtml");
		}

		[Route("CookingChannel/Greek")]
		public ActionResult Greek()
		{
			return View("~/Views/Channels/Cooking/Greek.cshtml");
		}

		[Route("CookingChannel/Italian")]
		public ActionResult Italian()
		{
			return View("~/Views/Channels/Cooking/Italian.cshtml");
		}

		[Route("CookingChannel/Mexican")]
		public ActionResult Mexican()
		{
			return View("~/Views/Channels/Cooking/Mexican.cshtml");
		}

		[Route("CookingChannel/Thai")]
		public ActionResult Thai()
		{
			return View("~/Views/Channels/Cooking/Thai.cshtml");
		}

		public ActionResult CarCategory()
		{
			return View();
		}

		[Route("CarChannel/Racing")]
		public ActionResult Racing()
		{
			return View("~/Views/Channels/Car/Racing.cshtml");
		}

		[Route("CarChannel/MuscleCars")]
		public ActionResult MuscleCars()
		{
			return View("~/Views/Channels/Car/MuscleCars.cshtml");
		}

		[Route("CarChannel/EngineBuilding")]
		public ActionResult EngineBuilding()
		{
			return View("~/Views/Channels/Car/EngineBuilding.cshtml");
		}
	}
}