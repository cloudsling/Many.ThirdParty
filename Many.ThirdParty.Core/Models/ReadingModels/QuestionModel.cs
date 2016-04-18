using Newtonsoft.Json;
using System;
using Windows.Data.Json;
using Many.ThirdParty.Core.Tools;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class QuestionModel : ReadingModelBase
    {
        public QuestionModel()
        {
        }

        public QuestionModel(int type, JsonObject json)
        {
            Type = type;
            CreateContent(json);
            NavigateToDetailCommand = new CommandBase(Test);
        }


        private void Test(object obj)
        {

        }

        public override IReadingContent Content { get; set; }

        public override CommandBase NavigateToDetailCommand { get; set; }

        public override void CreateContent(JsonObject json)
        {
            Content = JsonConvert.DeserializeObject<QuestionContent>(json.Stringify());
        }
    }

    public class QuestionContent : IReadingContent
    {
        public string Question_Id { get; set; }

        public string Question_Title { get; set; }

        public string Answer_Title { get; set; }

        public string Answer_Content { get; set; }

        public string Question_MaketTime { get; set; }

        public override string Title
        {
            get
            {
                return Question_Title;
            }

            set
            {
                Question_Title = value;
            }
        }

        public override string AuthorContent
        {
            get
            {
                return Answer_Title;
            }

            set
            {
                Answer_Title = value;
            }
        }

        public override string ContentSummary
        {
            get
            {
                return Answer_Content;
            }

            set
            {
                Answer_Content = value;
            }
        }
    }
}
