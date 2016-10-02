

using Microsoft.Ajax.Utilities;

namespace ShipsService.Controllers
{
    using System.Drawing;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}