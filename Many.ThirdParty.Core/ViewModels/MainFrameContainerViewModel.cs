using Many.ThirdParty.Core.Commons;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Many.ThirdParty.Core.ViewModels
{
    public class MainFrameContainerViewModel : ViewModelBase
    {
        public MainFrameContainerViewModel()
        {
            TitleBar = _colorsCollection?.TitleBar;

            OnThemeChanged += (coll) =>
            {
                TitleBar = coll.TitleBar;
                MainBackground = coll.MainBackground;
            };
        }

        private Brush _mainBackground;

        public Brush MainBackground
        {
            get { return _mainBackground; }
            set
            {
                SetProperty(ref _mainBackground, value);
            }
        }
        private Brush _titleBar;

        public Brush TitleBar
        {
            get { return _titleBar; }
            set
            {
                SetProperty(ref _titleBar, value);
            }
        }

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
