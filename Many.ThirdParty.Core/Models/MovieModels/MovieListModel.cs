namespace Many.ThirdParty.Core.Models.MovieModels
{
    public class MovieListModel
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _score;

        public string Score
        {
            get { return _score; }
            set { _score = value; }
        }
        private string _cover;

        public string Cover
        {
            get { return _cover; }
            set { _cover = value; }
        }
    }
}
