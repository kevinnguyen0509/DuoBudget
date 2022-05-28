using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuoBudget.Controllers
{
    public class HomeController : Controller
    {
        string IndexRoute = "~/Views/Home/Index/Index.cshtml";
        public ActionResult Index()
        {
            return View(IndexRoute);
        }
    }
}