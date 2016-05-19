namespace Many.ThirdParty.Core.Models.ReadingModels
{
    public class CarouselModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Cover { get; set; }

        public string Bottom_Text { get; set; }

        public string BgColor { get; set; }

        public string Pv_Url { get; set; }
    }

    public class CarouselDetailModel
    {
        public CarouselModel GeneralModel { get; set; }

        public string Item_Id { get; set; }

        public string Title { get; set; }

        public string Introduction { get; set; }

        public string Author { get; set; }

        public string Type { get; set; }

        public string Web_Url { get; set; }

        public string Number { get; set; }
    }
}
