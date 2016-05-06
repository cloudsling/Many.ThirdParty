namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public abstract class IReadingContent
    {
        public abstract string Title { get; set; }

        public abstract string AuthorContent { get; set; }

        public abstract string ContentSummary { get; set; }

        public abstract string Id { get; set; }

    }
}
