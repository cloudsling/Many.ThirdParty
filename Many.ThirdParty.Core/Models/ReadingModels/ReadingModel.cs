using Many.ThirdParty.Core.Commons;
using System.Collections.ObjectModel;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class ReadingModel : BindableBase
    {
        public ReadingModel()
        {
            _contentModelCollection = new ObservableCollection<ReadingModelBase>();
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
