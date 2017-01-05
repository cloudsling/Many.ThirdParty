using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Many.ThirdParty.Core.Tools;
using Windows.Storage;
using Windows.UI.Popups;

namespace Many.ThirdParty.Core.Data
{
    public static class Saver
    {
        private const string SavedFolderName = "ONE-一个";

        private static StorageFolder SavedFolder { get; set; }

        public static async Task SetSavedFolder()
        {
            try
            {
                SavedFolder = await KnownFolders.PicturesLibrary.CreateFolderAsync(SavedFolderName,
                            CreationCollisionOption.OpenIfExists);
            }
            catch (UnauthorizedAccessException)
            {
                await new MessageDialog("访问图片库被拒绝！！！！！").ShowAsync();
                // ignored
            }
            catch (Exception)
            {
                // ignored
            }
        }

        internal static async Task<bool> SavePic(string name, string uri)
        {
            if (string.IsNullOrEmpty(uri)) return false;
            try
            {
                await SetSavedFolder();

                await FileIO.WriteBufferAsync(

                    await SavedFolder.CreateFileAsync(name, CreationCollisionOption.OpenIfExists),
                    await HttpHelper.GetBufferAsync(uri));

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (Exception)
            {
                await new MessageDialog("未知错误！！").ShowAsync();
                return false;
            }
        }
    }
}