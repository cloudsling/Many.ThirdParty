using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Commands;
using Newtonsoft.Json;
using System.Collections.Generic;
using Windows.Data.Json;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class EssayModel : ReadingModelBase
    {
        public EssayModel(int type, JsonObject json) : this(type)
        {
            CreateContent(json);
        }

        public EssayModel(int type)
        {
            Type = type;
        }

        public EssayModel()
        {
            Type = 1;
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
            Content = JsonConvert.DeserializeObject<EssayContent>(json.Stringify());
        }
    }

    public class EssayContent : ReadingContent
    {
        public string Content_Id { get; set; }

        public string Hp_Title { get; set; }

        public string Hp_MaketTime { get; set; }

        public string Guide_Word { get; set; }

        public List<Author> Author { get; set; } = new List<Author>();

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
                return Author[0].User_Name;
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

        public override string Id
        {
            get
            {
                return Content_Id;
            }

            set
            {
                Content_Id = value;
            }
        }
    }
}
