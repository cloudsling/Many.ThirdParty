namespace Many.ThirdParty.Core.Service
{
    internal static class ServicesUrl
    {
        private static readonly string unknowGeneral = "http://v3.wufazhuce.com:8000/api/adposlist/android?";

        private static readonly string mainId = "http://v3.wufazhuce.com:8000/api/hp/idlist/{0}?";

        private static readonly string mainContent = "http://v3.wufazhuce.com:8000/api/hp/detail/{0}?"; //ID

        private static readonly string readingCarousel = "http://v3.wufazhuce.com:8000/api/reading/carousel/?";

        private static readonly string readingContent = "http://v3.wufazhuce.com:8000/api/reading/index/{0}?";

        private static readonly string questionContent = "http://v3.wufazhuce.com:8000/api/question/update/{0}/{1}?";//0:id  1:DateTime.Now()

        private static readonly string questionRelatedContent = "http://v3.wufazhuce.com:8000/api/related/question/{0}?";

        private static readonly string questionComment = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/question/{0}/{1}?";

        private static readonly string serialContent = "http://v3.wufazhuce.com:8000/api/serialcontent/{0}?";

        private static readonly string serialInfo = "http://v3.wufazhuce.com:8000/api/related/serial/{0}?";

        private static readonly string serialComment = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/serial/106/{0}?";

        private static readonly string essayContent = "http://v3.wufazhuce.com:8000/api/essay/{0}?";

        private static readonly string essayUpdate = "http://v3.wufazhuce.com:8000/api/essay/update/{0}/{1}?";

        private static readonly string essayComment = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/essay/{0}/{1}?"; //0:id 1:index

        private static readonly string musicId = "http://v3.wufazhuce.com:8000/api/music/idlist/{0}?";

        private static readonly string unknowReading = "http://v3.wufazhuce.com:8000/api/reading/carousel/pv/68?";

        private static readonly string musicContent = "http://v3.wufazhuce.com:8000/api/music/update/430/{0}"; //DataTime

        private static readonly string musicRelatedContent = "http://v3.wufazhuce.com:8000/api/related/music/{0}"; //id

        private static readonly string musicComment = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/music/{0}/0?"; //id

        private static readonly string unknow = "http://v3.wufazhuce.com:8000/api/reading/carousel/pv/67?";

        private static readonly string movieList = "http://v3.wufazhuce.com:8000/api/movie/list/0?";

        
        private static string searchMain = "http://v3.wufazhuce.com:8000/api/search/hp/{0}?";
        private static string searchAuthor = "http://v3.wufazhuce.com:8000/api/search/author/{0}?";
        private static string searchMovie = "http://v3.wufazhuce.com:8000/api/search/movie/{0}?";
        private static string searchMusic = "http://v3.wufazhuce.com:8000/api/search/music/{0}?";
        private static string searchArticle = "http://v3.wufazhuce.com:8000/api/search/reading/{0}?";

        public static string UnknowGeneral
        {
            get
            {
                return unknowGeneral;
            }
        }

        public static string MusicId
        {
            get
            {
                return musicId;
            }
        }

        public static string MainId
        {
            get
            {
                return mainId;
            }
        }

        public static string MainContent
        {
            get
            {
                return mainContent;
            }
        }

        public static string ReadingCarousel
        {
            get
            {
                return readingCarousel;
            }
        }

        public static string ReadingContent
        {
            get
            {
                return readingContent;
            }
        }

        public static string UnknowReading
        {
            get
            {
                return unknowReading;
            }
        }

        public static string MusicContent
        {
            get
            {
                return musicContent;
            }
        }

        public static string MusicRelatedContent
        {
            get
            {
                return musicRelatedContent;
            }
        }

        public static string MusicComment
        {
            get
            {
                return musicComment;
            }
        }

        public static string Unknow
        {
            get
            {
                return unknow;
            }
        }

        public static string MovieList
        {
            get
            {
                return movieList;
            }
        }

        public static string SearchMain
        {
            get
            {
                return searchMain;
            }

            set
            {
                searchMain = value;
            }
        }

        public static string SearchAuthor
        {
            get
            {
                return searchAuthor;
            }

            set
            {
                searchAuthor = value;
            }
        }

        public static string SearchMovie
        {
            get
            {
                return searchMovie;
            }

            set
            {
                searchMovie = value;
            }
        }

        public static string SearchMusic
        {
            get
            {
                return searchMusic;
            }

            set
            {
                searchMusic = value;
            }
        }

        public static string SearchArticle
        {
            get
            {
                return searchArticle;
            }

            set
            {
                searchArticle = value;
            }
        }

        public static string QuestionContent
        {
            get
            {
                return questionContent;
            }
        }

        public static string QuestionRelatedContent
        {
            get
            {
                return questionRelatedContent;
            }
        }

        public static string QuestionComment
        {
            get
            {
                return questionComment;
            }
        }
    }
}
