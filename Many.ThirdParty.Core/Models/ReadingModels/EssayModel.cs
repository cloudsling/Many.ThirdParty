using Many.ThirdParty.Core.Models.CommonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Many.ThirdParty.Core.Tools;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class EssayModel : ReadingModelBase
    {
        public EssayModel(int type, JsonObject json)
        {
            Type = type;
            CreateContent(json);
            NavigateToDetailCommand = new CommandBase(Test);
        }

        public EssayModel()
        {

        }

        private void Test(object obj)
        {

        }

        public override IReadingContent Content { get; set; }

        public override CommandBase NavigateToDetailCommand { get; set; }

        public override void CreateContent(JsonObject json)
        {
            Content = JsonConvert.DeserializeObject<EssayContent>(json.Stringify());
            
        }
    }

    public class EssayContent : IReadingContent
    {
        public string Content_Id { get; set; }

        public string Hp_Title { get; set; }

        public string Hp_MaketTime { get; set; }

        public string Guide_Word { get; set; }

        public List<AuthorModel> Author { get; set; } = new List<AuthorModel>();
         
        public override string Title
        {
            get
            {
               return Hp_Title;
            }

            set
            {
                Hp_Title = value;
            }
        }

        public override string AuthorContent
        {
            get
            {
               return  Author[0].User_Name;
            }

            set
            {
                //Author[0].User_Name = value;
            }
        }

        public override string ContentSummary
        {
            get
            {
                return Guide_Word;
            }

            set
            {
                Guide_Word = value;
            }
        }
    }
}
