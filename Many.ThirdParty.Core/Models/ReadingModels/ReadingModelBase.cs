using Windows.Data.Json;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public abstract class ReadingModelBase
    {
        public int Type { get; set; }

        public string Time { get; set; }

        public abstract string Id { get; set; }

        public abstract void CreateContent(JsonObject json);

        public virtual ReadingContent Content { get; set; }
    }
}
