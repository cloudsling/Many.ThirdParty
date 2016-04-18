namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public abstract class IReadingModel
    {
        public double Type { get; set; }

        public string Time { get; set; }

        public bool Has_Audio { get; set; }

        public virtual IReadingContent Content { get; set; }
    }
}
