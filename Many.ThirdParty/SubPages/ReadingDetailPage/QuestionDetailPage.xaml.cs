using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using Windows.UI.Xaml.Controls;
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
            ViewModel = e.Parameter as QuestionDetailPageViewModel ?? null;  
        }
    }

    public sealed partial class QuestionDetailPage : Page
    {
        public string Hello { get; set; } 

        public QuestionDetailPageViewModel ViewModel { get; set; }
    }
}
