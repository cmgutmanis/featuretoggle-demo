using FeatureToggles.Controllers.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toggles;

namespace FeatureToggles.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var toggler = new SimpleConfigToggleManager();

            var isEnabled = toggler.IsActive<HomeTestFeature>();

            return View();
        }
    }
}
