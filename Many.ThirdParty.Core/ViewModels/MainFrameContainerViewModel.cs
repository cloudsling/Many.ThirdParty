using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Many.ThirdParty.Core.ViewModels
{
    public class MainFrameContainerViewModel : BindableBase
    {
        double _windowCurrentWidth;
        public double WindowCurrentWidth
        {
            get { return _windowCurrentWidth; }
            set
            {
                SetProperty(ref _windowCurrentWidth, value);
            }
        }

        string _pageTitle;
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                SetProperty(ref _pageTitle, value);
            }
        }

        Visibility _opacityGridVisbility;
        public Visibility OpacityGridVisbility
        {
            get { return _opacityGridVisbility; }
            set
            {
                SetProperty(ref _opacityGridVisbility, value);
            }
        }

        Visibility _bottomNavBtnAndProfileVisibility;
        public Visibility BottomNavBtnAndProfileVisibility
        {
            get
            {
                return _bottomNavBtnAndProfileVisibility;
            }
            set
            {
                SetProperty(ref _bottomNavBtnAndProfileVisibility, value);
            }
        }

        public void SetBottomNavBtnAndProfileVisibe() => BottomNavBtnAndProfileVisibility = Visibility.Visible;
        public void SetBottomNavBtnAndProfileCollapsed() => BottomNavBtnAndProfileVisibility = Visibility.Collapsed;
    }
}
