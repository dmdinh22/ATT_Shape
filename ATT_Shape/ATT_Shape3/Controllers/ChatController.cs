using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ATT_Shape.domain.Models;

namespace ATT_Shape3.Controllers
{
    //[System.Web.Mvc.RoutePrefix("chat")]
    public class ChatController  : Controller
    {
        //[System.Web.Mvc.Route]
        public ActionResult Index()
        {

            return View();
        }
    }
}
