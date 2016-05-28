using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.HomeModels;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.UI.Notifications;

namespace Many.ThirdParty.Background
{
    public sealed class LiveTileTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();

            // TODO: TASK
            await GetLastHomeList();

            deferral.Complete();
        }

        private IAsyncOperation<string> GetLastHomeList()
        {
            try
            {
                return AsyncInfo.Run(token => RequestUpdate());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> RequestUpdate()
        {
            try
            {
                var response = (await CommonDataLoader.GetHomeList("0")).Take(5);

                if (response != null)
                {
                    UpdatePrimaryTile((await CommonDataLoader.LoadHomeModelsAsync(response)).ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        private void UpdatePrimaryTile(List<HomeModel> list)
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
                    var xml = new StringBuilder(TileTemplete);

                    var index = i + 1 <= list.Count - 1 ? i + 1 : 0;

                    xml.Replace("@{Hp_TitleT}", list[index].Hp_Title)
                       .Replace("@{Hp_MaketTimeT}", list[index].Hp_MaketTime)
                       .Replace("@Day", list[index].Day)
                       .Replace("@{Hp_ContentT}", list[index].Hp_Content);

                    xml.Replace("@Hp_Title", list[i].Hp_Title)
                       .Replace("@Hp_MaketTime", list[i].Hp_MaketTime)
                       .Replace("@Hp_Content", list[i].Hp_Content);

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

        private static readonly string TileTemplete = @"
<tile>
<visual version='2'>

    <binding template='TileMedium' branding='logo'> 
          <text hint-style='caption'>@Hp_Title</text> 
          <text hint-style='captionSubtle' hint-wrap='true'>@Hp_Content</text> 
    </binding>

    <binding template='TileWide' branding='nameAndLogo' displayName='@Hp_MaketTime'> 
          <text hint-style='caption'>@Hp_Title</text>
          <text hint-style='captionSubtle' hint-wrap='true'>@Hp_Content</text> 
    </binding> 

    <binding template='TileLarge' branding='nameAndLogo' displayName='@Day'>
      <group>
        <subgroup>
          <text hint-style='caption'>@Hp_Title</text>
          <text hint-style='captionSubtle'>@Hp_MaketTime</text>
          <text hint-style='captionSubtle' hint-wrap='true'>@Hp_Content</text> 
        </subgroup>
      </group>
      
      <text />

      <group>
        <subgroup>
          <text hint-style='caption'>@{Hp_TitleT}</text>
          <text hint-style='captionSubtle'>@{Hp_MaketTimeT}</text>
          <text hint-style='captionSubtle' hint-wrap='true'>@{Hp_ContentT}</text> 
        </subgroup>
      </group>
    </binding>

  </visual>
</tile>
";


    }
}
