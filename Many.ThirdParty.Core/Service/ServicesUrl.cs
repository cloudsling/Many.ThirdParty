using System;
using Many.ThirdParty.Core.Enum;

namespace Many.ThirdParty.Core.Service
{
    internal static class ServicesUrl
    {
        private const string Baseuri = "http://v3.wufazhuce.com:8000/api/";

        public static string UnknowGeneral => Baseuri + "adposlist/android?";

        public static string MusicId => Baseuri + "music/idlist/{0}?";

        public static string MainId => Baseuri + "hp/idlist/{0}?";

        public static string MainContent => Baseuri + "hp/detail/{0}?";

        public static string ReadingCarousel => Baseuri + "reading/carousel/{0}?";

        public static string ReadingContent => Baseuri + "reading/index/{0}?";

        public static string UnknowReading => Baseuri + "reading/carousel/pv/68?";

        public static string MusicContent => Baseuri + "music/detail/{0}?";
         
        public static string MusicComment => Baseuri + "comment/praiseandtime/music/{0}/0?";
         
        public static string MovieList => Baseuri + "movie/list/{0}?";

        public static string SearchMain => Baseuri + "search/hp/{0}?";

        public static string SearchAuthor => Baseuri + "search/author/{0}?";

        public static string SearchMovie => Baseuri + "search/movie/{0}?";

        public static string SearchMusic => Baseuri + "search/music/{0}?";

        public static string QuestionContent => Baseuri + "question/update/{0}/{1}?";

        public static string QuestionComment => Baseuri + "comment/praiseandtime/question/{0}/{1}?";

        public static string SerialContent => Baseuri + "serialcontent/{0}?";

        public static string SerialInfo => Baseuri + "related/serial/{0}?";

        public static string SerialComment => Baseuri + "comment/praiseandtime/serial/{0}/{1}?";

        public static string EssayContent => Baseuri + "essay/{0}?";

        public static string EssayUpdate => Baseuri + "essay/update/{0}/{1}?";

        public static string EssayComment => Baseuri + "comment/praiseandtime/essay/{0}/{1}?";

        public static string SearchReading => Baseuri + "search/reading/{0}?";

        public static string GetRelatedContent(RelatedContentOption option)
        {
            switch (option)
            {
                case RelatedContentOption.Question:
                    return Baseuri + "related/question/{0}?";
                case RelatedContentOption.Essay:
                    return Baseuri + "related/essay/{0}?";
                case RelatedContentOption.Serial:
                    return Baseuri + "related/serial/{0}?";
                case RelatedContentOption.Music:
                    return Baseuri + "related/music/{0}?";
                case RelatedContentOption.Movie:
                    return Baseuri + "related/movie/{0}?";
                default:
                    throw new ArgumentOutOfRangeException(nameof(option), option, null);
            }
        }
    }
}
