using Many.ThirdParty.Core.Models.CommonModels;

namespace Many.ThirdParty.Core.Models.MusicModels
{
    public class MusicModel
    {
        public string Id { get; set; }

        public string Cover { get; set; }

        public string Title { get; set; }

        public string Platform { get; set; }

        public string Music_Id { get; set; }

        public Author Author { get; set; }
    }
}
