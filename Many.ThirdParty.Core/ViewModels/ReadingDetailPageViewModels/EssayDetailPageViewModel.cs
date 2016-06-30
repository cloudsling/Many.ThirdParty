using System.Collections.Generic;
using System.Text;
using Many.ThirdParty.Core.Models.CommonModels;

namespace Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels
{
    public class EssayDetailPageViewModel : ReadingDetailPageViewModelBase
    {  
        public string Content_Id { get; set; }

        public string Hp_Title { get; set; }

        public string Sub_Title { get; set; }

        public string Auth_It { get; set; }

        public string Hp_Author_Introduce { get; set; }

        public string Hp_MaketTime { get; set; }

        public string Guild_World { get; set; }

        public IList<Author> Author { get; set; }

        private string _hp_Content;
        public string Hp_Content
        {
            get
            {
                return new StringBuilder(_hp_Content).Replace("<br>", "").ToString();
            }
            set { _hp_Content = value; }
        } 
    }
}
