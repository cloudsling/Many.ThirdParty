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
            ContentModelCollection = new ObservableCollection<ReadingContentModel>();

#if DEBUG
            if (DesignMode.DesignModeEnabled)
            {
                ContentModelCollection.Add(new ReadingContentModel
                {
                    Author = "王若虚",
                    ContentSummary = "重要的眼角和项链一样闪着微光，空中飘着小于版的彩带，吃剩的火锅冒着仅存的那白色热气，整个房间里都弥漫着火锅香料和白酒的想起",
                    Title = "《火锅杀》第八话：重要的生日"
                });
                ContentModelCollection.Add(new ReadingContentModel
                {
                    Author = "lingling",
                    ContentSummary = "dsfaadsfffffffffffffffffffffffffffffff",
                    Title = "jaoahaohaohao"
                });
            }
#endif
            ContentType = "2016-04-14";
            ContentModelCollection.Add(new ReadingContentModel
            {
                Author = "王若虚",
                ContentSummary = "重要的眼角和项链一样闪着微光，空中飘着小于版的彩带，吃剩的火锅冒着仅存的那白色热气，整个房间里都弥漫着火锅香料和白酒的想起",
                Title = "《火锅杀》第八话：重要的生日"
            });
            ContentModelCollection.Add(new ReadingContentModel
            {
                Author = "王若虚",
                ContentSummary = "重要的眼角和项链一样闪着微光，空中飘着小于版的彩带，吃剩的火锅冒着仅存的那白色热气，整个房间里都弥漫着火锅香料和白酒的想起",
                Title = "《火锅杀》第八话：重要的生日"
            });
            ContentModelCollection.Add(new ReadingContentModel
            {
                Author = "lingling",
                ContentSummary = "dsfaadsfffffffffffffffffffffffffffffff",
                Title = "jaoahaohaohao"
            });
        }

        string _contentTpe;
        public string ContentType
        {
            get { return _contentTpe; }
            set
            {
                SetProperty(ref _contentTpe, value);
            }
        }

        public ObservableCollection<ReadingContentModel> ContentModelCollection { get; set; }
    }
}
