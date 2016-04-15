using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Many.ThirdParty.Core.ViewModels
{
    public partial class ReadingPageViewModel : BindableBase
    {
        public ReadingPageViewModel()
        {
            ReadingPageFlipViewImageSource = new ObservableCollection<string>();
            //_readingModel = new ObservableCollection<ReadingModel> {
            //    new ReadingModel(),
            //    new ReadingModel(),
            //    new ReadingModel(),
            //    new ReadingModel(),
            //    new ReadingModel(),
            //};
            ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
            ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
            ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
            ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
            ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
            ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
            ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
            ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
            ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
#if DEBUG
            if (DesignMode.DesignModeEnabled)
            {
                //TODO: do something in design mode
                ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
                ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
                ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
                ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
                ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
                ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
                ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
                ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
                ReadingPageFlipViewImageSource.Add("ms-appx:///Resources/Test/cover.jpg");
            }
#endif

        }
    }

    public partial class ReadingPageViewModel
    {
        public ObservableCollection<string> ReadingPageFlipViewImageSource { get; set; }

        //ObservableCollection<ReadingModel> _readingModel;
        //public ObservableCollection<ReadingModel> ReadingModel
        //{
        //    get { return _readingModel; }
        //    set
        //    {
        //        SetProperty(ref _readingModel, value);
        //    }
        //}
    }
}
