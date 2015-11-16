using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toggles
{
    public interface IFeatureToggle
    {
        bool IsActive<TFeature>();
    }
}
