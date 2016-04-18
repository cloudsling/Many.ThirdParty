namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class QuestionModel : IReadingModel
    {
        public override IReadingContent Content { get; set; }
    }

    public class QuestionContent : IReadingContent
    {
        public string Question_Id { get; set; }

        public string Question_Title { get; set; }

        public string Answer_Title { get; set; }

        public string Answer_Content { get; set; }

        public string Question_MaketTime { get; set; }
    }
}
