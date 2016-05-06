using Many.ThirdParty.Core.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Popups;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class ReadingModel : BindableBase
    {
        public ReadingModel()
        {
            ContentModelCollection = new ObservableCollection<ReadingModelBase>();

            //NavigateToDetailCommand = new CommandBase(GetTest);
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

        public void AddToCollection(ReadingModelBase model)
        {
            ContentModelCollection.Add(model);
        }
         
        ObservableCollection<ReadingModelBase> _contentModelCollection;
        public ObservableCollection<ReadingModelBase> ContentModelCollection
        {
            get { return _contentModelCollection; }
            set
            {
                SetProperty(ref _contentModelCollection, value);
            }
        }
    }
}
