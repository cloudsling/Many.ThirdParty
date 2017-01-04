using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Many.ThirdParty.Core.Enum;
using Many.ThirdParty.Core.Models.HomeModels;

namespace Many.ThirdParty.Core.Data
{
    partial class TempleteCreator
    {
        private const string BaseUri = "ms-appx:///Many.ThirdParty.Core/TempleteFiles/";

        private const string Normal = "LiveTileTemplete.xml";
        private const string WithImage = "LiveTileTempleteWithImage.xml";

        public static string XmlTemplete { get; set; }

        private static string GetTempleteFileName(LiveTileType type)
        {
            switch (type)
            {
                case LiveTileType.Normal:
                    return BaseUri + Normal;
                case LiveTileType.WithImage:
                    return BaseUri + WithImage;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static async Task GetTemplete(Uri uri)
        {
            XmlTemplete = await FileIO.ReadTextAsync(await StorageFile.GetFileFromApplicationUriAsync(uri));
        }
    }
    partial class TempleteCreator
    {
        public Uri FileUri { get; set; }

        public TempleteCreator(LiveTileType type = LiveTileType.Normal)
        {
            FileUri = new Uri(GetTempleteFileName(type));
        }

        public async Task<string> CreatorTemplete(HomeModel modelPrev, HomeModel modelNext)
        {
            if (string.IsNullOrEmpty(XmlTemplete))
            {
                await GetTemplete(FileUri);
            }

            Debug.Assert(XmlTemplete != null, "Xml != null");


            StringBuilder xml = new StringBuilder(XmlTemplete);
            // 大磁贴替换
            xml.Replace("{Hp_TitleT}", modelNext.Hp_Title)
                    .Replace("{Hp_MaketTimeT}", modelNext.Hp_MaketTime)
                    .Replace("{Day}", modelNext.Day)
                    .Replace("{Hp_ContentT}", modelNext.Hp_Content);
            //普通替换
            xml.Replace("{Hp_Title}", modelPrev.Hp_Title)
               .Replace("{Hp_MaketTime}", modelPrev.Hp_MaketTime)
               .Replace("{Hp_Content}", modelPrev.Hp_Content)
               .Replace("{HP_Image_Url}", modelPrev.Hp_Img_Url);

            return xml.ToString();
        }

        public void Close()
        {
            XmlTemplete = string.Empty;
        }
    }
}
