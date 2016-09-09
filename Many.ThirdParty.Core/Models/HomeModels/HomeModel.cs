using Many.ThirdParty.Core.Commons;
using System;
using Many.ThirdParty.Core.ViewModels;
using Many.ThirdParty.Core.Commands;
using Many.ThirdParty.Core.Data;

namespace Many.ThirdParty.Core.Models.HomeModels
{
    public class HomeModel : BindableBase
    {
        private static readonly CommandBase StaticSavePicCommand = new AsyncCommand(HomePageViewModel.SavePic);
        private static readonly CommandBase StaticCopyCommand = new Command(Replicators.CopyString);

        public CommandBase CopyCommand => StaticCopyCommand;

        public CommandBase SavePicCommand => StaticSavePicCommand;

        public static Action EndOfMenuFlyoutCommand;

        public string Hpcontent_Id { get; set; }

        public string Hp_Title { get; set; }

        public string Author_Id { get; set; }

        public string Hp_Img_Url { get; set; }

        public string Hp_Author { get; set; }

        public string Hp_Content { get; set; }

        private string _hp_MaketTime;
        public string Hp_MaketTime
        {
            get { return _hp_MaketTime; }
            set { _hp_MaketTime = value.Split(' ')[0]; }
        }

        public string Day => DateTime.Now.Day.ToString();

        public string Month => $"{ DateTime.Now.Year}-{DateTime.Now.Month }";

        public string PraiseNum { get; set; }

        public string ShareNum { get; set; }

        public string CommentNum { get; set; }

    }
}
