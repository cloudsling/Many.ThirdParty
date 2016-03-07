using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Many.ThirdParty.CustomControls
{
    public sealed class HomeButton : Windows.UI.Xaml.Controls.Button
    {
        public HomeButton()
        {
            this.DefaultStyleKey = typeof(HomeButton);
        }
        
    }
}
