namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public abstract class IReadingContent
    {
        public virtual string ImageTypeSource { get; set; }

        public virtual string Title { get; set; }

        public virtual string AuthorContent { get; set; }

        public virtual string ContentSummary { get; set; }
    }
}
