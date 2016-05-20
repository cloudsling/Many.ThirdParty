using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Themes;
using System;

namespace Many.ThirdParty.Core.Models.HomeModels
{
    public class HomeModel : BindableBase, IThemeMode
    {
        public string Hpcontent_Id { get; set; }

        public string Hp_Title { get; set; }

        public string Author_Id { get; set; }

        public string Hp_Img_Url { get; set; }

        public string Hp_Author { get; set; }

        public string Hp_Content { get; set; }

        public string Hp_MaketTime { get; set; }

        public string Day { get { return DateTime.Now.Day.ToString(); } }

        public string Month { get { return $"{ DateTime.Now.Year}-{DateTime.Now.Month }"; } }

        public string PraiseNum { get; set; }

        public string ShareNum { get; set; }

        public string CommentNum { get; set; }

        private static IColorsCollection _colorsCollection;

        public IColorsCollection ColorsCollection
        {
            get { return _colorsCollection; }
            set
            {
                SetProperty(ref _colorsCollection, value);
            }
        }
    }
}
