using System;

namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class CarouselModel : ICarousel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Cover { get; set; }

        public string Bottom_Text { get; set; }

        public string BgColor { get; set; }

        public string Pv_Url { get; set; }
    }

    internal interface ICarousel
    {
        string Title { get; set; }

        string Cover { get; set; }

        string Bottom_Text { get; set; }

        string BgColor { get; set; }
    }

    public class CarouselDetailModel
    {
        public static int index = 1;

        public static void ResetIndex() => index = 1;

        public string Title { get; set; }

        public string Item_Id { get; set; }

        public string Introduction { get; set; }

        public string Author { get; set; }

        public string Type { get; set; }

        public string Web_Url { get; set; }

        public string Number { get; set; }

        public string Index { get { return index++.ToString(); } }
    }
}
