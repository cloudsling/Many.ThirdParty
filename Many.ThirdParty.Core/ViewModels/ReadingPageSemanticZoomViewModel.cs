using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.ViewModels
{
    public class ReadingPageSemanticZoomViewModel : BindableBase
    {
        public ReadingPageSemanticZoomViewModel()
        {
            _readingModel = new ObservableCollection<ReadingModel> {
                new ReadingModel(),
                new ReadingModel(),
                new ReadingModel(),
                new ReadingModel(),
                new ReadingModel(),
            };
        }

        ObservableCollection<ReadingModel> _readingModel;
        public ObservableCollection<ReadingModel> ReadingModel
        {
            get { return _readingModel; }
            set
            {
                SetProperty(ref _readingModel, value);
            }
        }
    }
}
