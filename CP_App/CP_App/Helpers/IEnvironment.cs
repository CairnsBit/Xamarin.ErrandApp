using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CP_App.Helpers
{
    public interface IEnvironment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
