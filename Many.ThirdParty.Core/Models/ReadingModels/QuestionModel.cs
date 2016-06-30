using Newtonsoft.Json;
using Windows.Data.Json;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class QuestionModel : ReadingModelBase
    {
        public QuestionModel()
        {
        }

        public QuestionModel(int type)
        {
            Type = type;
        }

        public QuestionModel(int type, JsonObject json) : this(type)
        {
            CreateContent(json);
        }

        public override ReadingContent Content { get; set; }

        public override string Id
        {
            get
            {
                return Content.Id;
            }

            set
            {
            }
        }

        public sealed override void CreateContent(JsonObject json)
        {
            Content = JsonConvert.DeserializeObject<QuestionContent>(json.Stringify());
        }
    }

    public class QuestionContent : ReadingContent
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

        public override string Id
        {
            get
            {
                return Question_Id;
            }

            set
            {
                Question_Id = value;
            }
        }
    }
}
