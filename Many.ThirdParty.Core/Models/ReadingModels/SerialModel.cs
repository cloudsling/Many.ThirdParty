using Many.ThirdParty.Core.Models.CommonModels;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class SerialModel : IReadingModel
    {
        public override IReadingContent Content { get; set; }
    }

    public class SerialContent : IReadingContent
    {
        public string Id { get; set; }

        public string Serial_Id { get; set; }

        public string Number { get; set; }

        public string Excerpt { get; set; }

        public string Read_Num { get; set; }

        public AuthorModel Author { get; set; } = new AuthorModel();



        public override string Title { get; set; }

        public override string AuthorContent { get { return Author.User_Name; } set { Author.User_Name = value; } }

        public override string ContentSummary { get { return Excerpt; } set { Excerpt = value; } }
    }
}
