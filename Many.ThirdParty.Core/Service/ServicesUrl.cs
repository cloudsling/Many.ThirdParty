namespace Many.ThirdParty.Core.Service
{
    internal static class ServicesUrl
    {
        public static string UnknowGeneral { get; } = "http://v3.wufazhuce.com:8000/api/adposlist/android?";

        public static string MusicId { get; } = "http://v3.wufazhuce.com:8000/api/music/idlist/{0}?";

        public static string MainId { get; } = "http://v3.wufazhuce.com:8000/api/hp/idlist/{0}?";

        public static string MainContent { get; } = "http://v3.wufazhuce.com:8000/api/hp/detail/{0}?";

        public static string ReadingCarousel { get; } = "http://v3.wufazhuce.com:8000/api/reading/carousel/{0}?";

        public static string ReadingContent { get; } = "http://v3.wufazhuce.com:8000/api/reading/index/{0}?";

        public static string UnknowReading { get; } = "http://v3.wufazhuce.com:8000/api/reading/carousel/pv/68?";

        public static string MusicContent { get; } = "http://v3.wufazhuce.com:8000/api/music/detail/{0}?";

        public static string MusicRelatedContent { get; } = "http://v3.wufazhuce.com:8000/api/related/music/{0}";

        public static string MusicComment { get; } = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/music/{0}/0?";

        public static string Unknow { get; } = "http://v3.wufazhuce.com:8000/api/reading/carousel/pv/67?";

        public static string MovieList { get; } = "http://v3.wufazhuce.com:8000/api/movie/list/0?";

        public static string SearchMain { get; } = "http://v3.wufazhuce.com:8000/api/search/hp/{0}?";

        public static string SearchAuthor { get; } = "http://v3.wufazhuce.com:8000/api/search/author/{0}?";

        public static string SearchMovie { get; } = "http://v3.wufazhuce.com:8000/api/search/movie/{0}?";

        public static string SearchMusic { get; } = "http://v3.wufazhuce.com:8000/api/search/music/{0}?";
         
        public static string QuestionContent { get; } = "http://v3.wufazhuce.com:8000/api/question/update/{0}/{1}?";

        public static string QuestionRelatedContent { get; } = "http://v3.wufazhuce.com:8000/api/related/question/{0}?";

        public static string QuestionComment { get; } = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/question/{0}/{1}?";

        public static string SerialContent { get; } = "http://v3.wufazhuce.com:8000/api/serialcontent/{0}?";

        public static string SerialInfo { get; } = "http://v3.wufazhuce.com:8000/api/related/serial/{0}?";

        public static string SerialComment { get; } = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/serial/{0}/{1}?";

        public static string EssayContent { get; } = "http://v3.wufazhuce.com:8000/api/essay/{0}?";

        public static string EssayUpdate { get; } = "http://v3.wufazhuce.com:8000/api/essay/update/{0}/{1}?";

        public static string EssayComment { get; } = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/essay/{0}/{1}?";

        public static string SearchReading { get; } = "http://v3.wufazhuce.com:8000/api/search/reading/{0}?";
    }
}
