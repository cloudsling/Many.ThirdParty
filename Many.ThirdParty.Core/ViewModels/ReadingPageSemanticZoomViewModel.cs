using Many.ThirdParty.Core.Data;
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
            _readingModelCollection = new ObservableCollection<ReadingModel>();
            // OnNavigatedTo();
            #region ZS
            //_readingModelCollection.Add(new ReadingModel
            //{
            //    MaketTime = "2016-1-12",
            //    ContentModelCollection = new ObservableCollection<ReadingModelBase>
            //    {
            //        new EssayModel()
            //        {
            //            Type=1,
            //            Time="2016-1-1",
            //            Content = new EssayContent
            //            {
            //                AuthorContent ="aaaaaaaaaaaaaaaaaaaaaaa",
            //                ContentSummary = "bbbbbbbbbbb",
            //                Guide_Word = "ccccccccccccccc",
            //                Hp_Title = "dddddddddddddd",
            //                Author = new List<Models.CommonModels.AuthorModel>
            //                {
            //                    new Models.CommonModels.AuthorModel
            //                    {
            //                        User_Name= "linghao"
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}); 
            #endregion
        }

        //protected void OnNavigatedTo()
        //{
        //    AddToCollection(async () => await LoadResources.GetReadingModel("0"));
        //    //var collection = await LoadResources.GetReadingModel("0");
        //}


        public void AddToCollection(ReadingModel model)
        {
            _readingModelCollection.Add(model);
        }

        public async void AddToCollection(Func<Task<ObservableCollection<ReadingModel>>> func)
        {
            ReadingModelCollection = await func();
        }

        ObservableCollection<ReadingModel> _readingModelCollection;

        public ObservableCollection<ReadingModel> ReadingModelCollection
        {
            get { return _readingModelCollection; }
            set
            {
                SetProperty(ref _readingModelCollection, value);
            }
        }
    }
}
