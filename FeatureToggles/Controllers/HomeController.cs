using FeatureToggles.Controllers.Features;
using FeatureToggles.Toggles;
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
            var toggler = new SimpleConfigToggle();

            var isEnabled = toggler.IsActive<HomeTestFeature>();

            var dbToggler = new ExternalToggle();
            var isDbEnabled = dbToggler.IsActive<HomeTestFeature>();

            return View();
        }
    }
}
