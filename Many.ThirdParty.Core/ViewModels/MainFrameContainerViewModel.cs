using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace Many.ThirdParty.Core.ViewModels
{
    public class MainFrameContainerViewModel : BindableBase
    {
        public MainFrameContainerViewModel()
        {
#if DEBUG
            if (DesignMode.DesignModeEnabled)
            {
                //TODO: do something in design mode
                CurrentWindowWidth = 500; //Window.Current.Bounds.Width;
               
            }
#endif
        }

        double _currentWindowWidth;
        public double CurrentWindowWidth
        {
            get { return _currentWindowWidth; }
            set
            {
                SetProperty(ref _currentWindowWidth, value);
            }
        }
        
        double _currentWindowHeight;
        public double CurrentWindowHeight
        {
            get { return _currentWindowHeight; }
            set
            {
                SetProperty(ref _currentWindowHeight, value);
            }
        }
    }
}
