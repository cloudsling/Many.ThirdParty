using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.SubPages.ReadingDetailPage
{
    public sealed partial class QuestionDetailPage : Page
    {
        public QuestionDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //ViewModel = await QuestionDetailPageViewModel.CreateQuestionDetailPageViewModel(e.Parameter as string ?? string.Empty);
            ViewModel = e.Parameter as QuestionDetailPageViewModel ?? null;
        }

    }

    public sealed partial class QuestionDetailPage : Page
    {
        public string Hello { get; set; }

        public QuestionDetailPageViewModel ViewModel { get; set; }
    }
}
