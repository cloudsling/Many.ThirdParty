using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.HomeModels;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.Notifications;
using Many.ThirdParty.Core.Enum;

namespace Many.ThirdParty.Core.Tasks
{
    public static class LiveTileTask
    {
        public static async Task<string> RequestUpdate()
        {
            try
            {
                var response = (await CommonDataLoader.GetGeneralList("0", ListType.HomeList)).Take(5);

                if (response != null)
                {
                    await UpdatePrimaryTile((await CommonDataLoader.LoadHomeModelsAsync(response)).ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        private static async Task UpdatePrimaryTile(List<HomeModel> list)
        {
            try
            {
                var updater = TileUpdateManager.CreateTileUpdaterForApplication();

                updater.EnableNotificationQueueForWide310x150(true);
                updater.EnableNotificationQueueForSquare150x150(true);
                updater.EnableNotificationQueue(true);
                updater.Clear();

                for (int i = 0; i < list.Count; i++)
                {
                    var xml = new StringBuilder(await TileTemplete());

                    var index = i + 1 <= list.Count - 1 ? i + 1 : 0;

                    xml.Replace("{Hp_TitleT}", list[index].Hp_Title)
                       .Replace("{Hp_MaketTimeT}", list[index].Hp_MaketTime)
                       .Replace("{Day}", list[index].Day)
                       .Replace("{Hp_ContentT}", list[index].Hp_Content);

                    xml.Replace("{Hp_Title}", list[i].Hp_Title)
                       .Replace("{Hp_MaketTime}", list[i].Hp_MaketTime)
                       .Replace("{Hp_Content}", list[i].Hp_Content);

                    var doc = new XmlDocument();

                    doc.LoadXml(xml.ToString(), new XmlLoadSettings
                    {
                        ProhibitDtd = false,
                        ValidateOnParse = false,
                        ElementContentWhiteSpace = false,
                        ResolveExternals = false
                    });

                    updater.Update(new TileNotification(doc));
                }
            }
            catch (Exception) { }
        }

        private static Func<Task<string>> TileTemplete = async () =>
          await FileIO.ReadTextAsync(await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Many.ThirdParty.Core/TempleteFiles/LiveTileTemplete.xml")));

    }
}
