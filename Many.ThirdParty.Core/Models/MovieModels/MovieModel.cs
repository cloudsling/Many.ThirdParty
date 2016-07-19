using System.Collections.Generic;

namespace Many.ThirdParty.Core.Models.MovieModels
{
    public class MovieModel
    {
        public MovieModel()
        {
            Photo = new List<string>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string IndexCover { get; set; }

        public string DetailCover { get; set; }

        public string Video { get; set; }

        public string Verse { get; set; }

        public string Verse_En { get; set; }

        public string RevisedScore { get; set; }

        public string KeyWords { get; set; }

        public List<string> Photo { get; set; }

        public string Movie_Id { get; set; }

        public string Info { get; set; }

        public string OffcialStory { get; set; }

        public string Charge_Edt { get; set; }

        public string PraiseNum { get; set; }

        public string Sort { get; set; }

        public string Read_Num { get; set; }

        public string ShareNum { get; set; }

        public string CommentNum { get; set; }

        public string ServerTime { get; set; } 
    }
}
