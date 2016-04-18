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
            _readingModel = new ObservableCollection<ReadingModel>();
            _readingModel.Add(new ReadingModel
            {
                MaketTime = "2016-04-13",
                ContentModelCollection = new ObservableCollection<IReadingModel>
                {
                   new SerialModel
                   {
                       Type = 2,
                       Content =new SerialContent
                       {
                           Title = "abcdefg",
                           ContentSummary = "Adfadgfaergrethtdyjf",
                           Author = new Models.CommonModels.AuthorModel
                           {
                               User_Name = "LingHao"
                           }
                       }
                   }
                }
            });
        }

        public void AddToCollection(ReadingModel model)
        {
            _readingModel.Add(model);
        }

        public async Task RefreshCollection()
        {

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
