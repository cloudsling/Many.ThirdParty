using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class ReadingModel : BindableBase
    {
        public ReadingModel()
        {
            ContentModelCollection = new ObservableCollection<IReadingModel>();
        }

        string _maketTime;
        public string MaketTime
        {
            get { return _maketTime; }
            set
            {
                SetProperty(ref _maketTime, value);
            }
        }

        public ObservableCollection<IReadingModel> ContentModelCollection { get; set; }
    }
}
