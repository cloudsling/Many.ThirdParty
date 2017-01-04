using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.HomeModels;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;
using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Enum;

namespace Many.ThirdParty.Core.Tasks
{
    public static class LiveTileTask
    {
        public static async Task<string> RequestUpdate()
        {
            var response = (await CommonDataLoader.GetGeneralList("0", ListType.HomeList)).Take(5);

            if (response != null)
            {
                await UpdatePrimaryTile((await CommonDataLoader.LoadHomeModelsAsync(response)).ToList());
            }

            return null;
        }

        private static async Task UpdatePrimaryTile(IReadOnlyList<HomeModel> list)
        {
            try
            {
                var updater = TileUpdateManager.CreateTileUpdaterForApplication();

                updater.EnableNotificationQueueForWide310x150(true);
                updater.EnableNotificationQueueForSquare150x150(true);
                updater.EnableNotificationQueue(true);
                updater.Clear();

                TempleteCreator creator = new TempleteCreator(ViewModelBase.CurrentSettings.LiveTileWithImage ? LiveTileType.WithImage : LiveTileType.Normal);

                for (int i = 0; i < list.Count; i++)
                {
                    var index = i + 1 <= list.Count - 1 ? i + 1 : 0;

                    string xml = await creator.CreatorTemplete(list[i], list[index]);

                    var doc = new XmlDocument();

                    doc.LoadXml(xml, new XmlLoadSettings
                    {
                        ProhibitDtd = false,
                        ValidateOnParse = false,
                        ElementContentWhiteSpace = false,
                        ResolveExternals = false
                    });

                    updater.Update(new TileNotification(doc));
                }

                creator.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private static readonly Func<Task<string>> TileTemplete = async () =>
          await FileIO.ReadTextAsync(await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Many.ThirdParty.Core/TempleteFiles/LiveTileTemplete.xml")));

    }
}
