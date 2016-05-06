namespace Many.ThirdParty.Core.Models.CommonModels
{
    public class CommentModel
    {
        public string Id { get; set; }

        public string Quote { get; set; }

        public string Content { get; set; }

        public string PariseNum { get; set; }

        public User User { get; set; }
    }
}
