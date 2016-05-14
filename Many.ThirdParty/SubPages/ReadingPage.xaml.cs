using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Config;
using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using Many.ThirdParty.Core.Factories;
using Windows.UI.Core;

namespace Many.ThirdParty.SubPages
{
    /// <summary>
    /// auto event
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        private void fv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GetIndexFromFlipView(sender) >= 0 && GetIndexFromFlipView(sender) <= 8)
            {
                ChangeAllEllipseColor(ManyEllipse.Children, GetIndexFromFlipView(sender));
            }
        }
        
        private int GetIndexFromFlipView(object sender) => (sender as FlipView).SelectedIndex;

        private async void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReadingModelBase modelBase = e.ClickedItem as ReadingModelBase;
 
            this.Frame.Navigate(
                NavigationManager.MainScenarios[modelBase.Type + 4].PageType,
                await ReadingViewModelFactory.CreateReadingDetailPageViewModel(modelBase));
        }
        
        private void BlankButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }

    /// <summary>
    /// field and properties
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        public ReadingPageViewModel ReadingPageViewModel { get; set; }

        private static ReadingPage CurrentReadingPage;

        private static readonly List<SolidColorBrush> EllipseBackgroundColorCollection = new List<SolidColorBrush> {
            new SolidColorBrush(Colors.SkyBlue),
            new SolidColorBrush(Colors.White),
        };
    }

    /// <summary>
    /// entry and methods
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        public ReadingPage()
        {
            ReadingPageViewModel = new ReadingPageViewModel();

            InitializeComponent();
            CurrentReadingPage = this;

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ReadingPageViewModel.CarouselModelCollection.Count <= 0)
            {
                await ReadingPageViewModel.RefreshCollection();
                await ReadingPageViewModel.RefreshListView();
            }
        }


        /// <summary>
        /// 改变所有的圆点的颜色
        /// </summary>
        /// <param name="CurrentIndex"></param>
        private void ChangeAllEllipseColor(UIElementCollection collection, int currentIndex)
        {
            for (int index = 0; index < collection.Count; index++)
            {
                (collection[index] as Ellipse).Fill = EllipseBackgroundColorCollection[index == currentIndex ? 0 : 1];
            }
        }

        public static void NavigateToDetail(Type pageType)
        {
            CurrentReadingPage.Frame.Navigate(pageType);
        }
    }
}

//1.中午下班，饥肠辘辘，此时你会选择去哪家快餐店饱腹一番？
//A.肯德基
//B.麦当劳
//C.华莱士
//D.必胜客
//2.新闻界召开短跑大赛，哪里的记者铁定会夺取第一？
//A.西方记者
//B.香港记者
//C.大陆记者
//D.日本记者
//3.你觉得一个地区该怎样选取领导人？
//A.民主选拔
//B.军事独裁
//C.单姓王朝
//D.钦点
//4.你觉得哪句俗语让你受益匪浅？
//A.闷声大发财
//B.说曹操曹操到
//C.失败乃成功之母
//D.知之者不如好之者
//5.“好啊”用广东话怎么说？
//A.豪啊
//B.合啊
//C.吼啊
//D.呼啊
//6.下列四个关于“笑”成语你觉得哪个与众不同？
//A.开怀大笑
//B.笑面老虎
//C.谈笑风生
//D.笑里藏刀
//7.“比喻看势头或看别人的眼色行事，根据形势的变化而改变方向或态度”这是哪个成语/俗语的释义？
//A.见得风是得雨
//B.见风使舵
//C.墙头草随风倒
//D.随机应变
//8.年轻的你应该向谁请教一点“人生的经验”？
//A.父母
//B.长者
//C.老师
//D.大哥
//9.怎样形容别人年少无知？
//A.青春少年狂
//B.小孩子不识世间事
//C.经验不足、阅历太浅
//D.too young