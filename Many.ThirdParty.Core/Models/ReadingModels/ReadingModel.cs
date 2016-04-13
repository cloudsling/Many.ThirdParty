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
                    Author = "lingling",
                    ContentSummary = "dsfaadsfffffffffffffffffffffffffffffff",
                    Title = "jaoahaohaohao"
                }); ContentModelCollection.Add(new ReadingContentModel
                {
                    Author = "lingling",
                    ContentSummary = "dsfaadsfffffffffffffffffffffffffffffff",
                    Title = "jaoahaohaohao"
                });
            }

#endif
            ContentType = "reading";
            ContentModelCollection.Add(new ReadingContentModel
            {
                Author = "lingling",
                ContentSummary = "dsfaadsfffffffffffffffffffffffffffffff",
                Title = "jaoahaohaohao"
            });
            ContentModelCollection.Add(new ReadingContentModel
            {
                Author = "lingling",
                ContentSummary = "dsfaadsfffffffffffffffffffffffffffffff",
                Title = "jaoahaohaohao"
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
