using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Toggles
{
    public class SimpleConfigToggleManager : IFeatureToggle
    {

        public bool IsActive<TFeature>()
        {
            var key = typeof(TFeature).Name;

            var result = false;
            
            bool.TryParse(ConfigurationManager.AppSettings[key], out result);

            return result;
        }
    }
}
