using FeatureToggles.Controllers.Features;
using FeatureToggles.Models;
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
            var model = new HomeModel();
            var toggler = new SimpleConfigToggle();

            #region toggle in web.config
            //if (toggler.IsActive<HomeTestFeature>())
            //{
            //    model.ImageUrl = "\\Images\\image0.jpg";
            //}
            #endregion

            #region toggle managed by external database
            var dbToggler = new ExternalToggle();
            if (dbToggler.IsActive<HomeTestFeature>())
            {
                     model.ImageUrl = "\\Images\\image0.jpg";
            }
            else
            {
                model.ImageUrl = "\\Images\\image1.jpg";
            }
            #endregion


            return View(model);
        }
    }
}
