using Many.ThirdParty.Core.Models.CommonModels;

namespace Many.ThirdParty.Core.Models.MovieModels
{
    public class MovieStoryModel
    {
        public string Id { get; set; }

        public string Movie_Id { get; set; }

        public string Title { get; set; }

        public string  Content { get; set; }

        public string User_Id { get; set; }

        public string Sort { get; set; }

        public string PraiseNum { get; set; }
         

        public string Input_Date { get; set; }

        public string Story_Type { get; set; }

        public User User { get; set; }
    }
}
