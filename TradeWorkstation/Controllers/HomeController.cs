using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeWorkstation.Models;

namespace TradeWorkstation.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        // GET: Home
        //[Route("Index/{id:int}")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Publish()
        {
            return View();
        }
    }
}