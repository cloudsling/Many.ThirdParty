using Many.ThirdParty.Core.Models.CommonModels;
using Windows.Data.Json;
using Newtonsoft.Json;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class SerialModel : ReadingModelBase
    {
        public SerialModel()
        {
            Type = 2;
        }
        public SerialModel(int type)
        {
            Type = type;
        }

        public SerialModel(int type, JsonObject json) : this(type)
        {
            CreateContent(json);
        }

        public override string Id
        {
            get
            {
                return Content.Id;
            }
            set { }
        }

        public override ReadingContent Content { get; set; }

        public sealed override void CreateContent(JsonObject json)
        {
            Content = JsonConvert.DeserializeObject<SerialContent>(json.Stringify());
        }
    }

    public class SerialContent : ReadingContent
    {
        // [JsonProperty("Serial_Id")]
        public string Serial_Id { get; set; }

        public string Number { get; set; }

        public override string Title { get; set; }

        public string Excerpt { get; set; }

        public string Read_Num { get; set; }

        public Author Author { get; set; }

        public override string AuthorContent
        {
            get
            {
                return Author.User_Name;
            }

            set
            {
                Author.User_Name = value;
            }
        }

        public override string ContentSummary
        {
            get
            {
                return Excerpt;
            }

            set
            {
                Excerpt = value;
            }
        }

        public override string Id { get; set; }
    }
}
