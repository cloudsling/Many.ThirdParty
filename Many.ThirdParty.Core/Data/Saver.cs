using System;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Tools;
using Windows.Storage;
using Windows.UI.Popups;

namespace Many.ThirdParty.Core.Data
{
    public static class Saver
    {
        private static StorageFolder SystemPicturesLibrary;

        public static async Task TryGetPicturesLibrary()
        {
            try
            {
                SystemPicturesLibrary = await KnownFolders.PicturesLibrary.CreateFolderAsync("一个", CreationCollisionOption.OpenIfExists);
            }
            catch (UnauthorizedAccessException)
            {
                await new MessageDialog("访问图片库被拒绝！！！！！").ShowAsync();
                throw;
            }
        }

        internal static async Task SavePic(string name, string uri)
        {
            if (string.IsNullOrEmpty(uri)) return;
            try
            {
                if (SystemPicturesLibrary == null)
                    await TryGetPicturesLibrary();

                await FileIO.WriteBufferAsync(
                    await SystemPicturesLibrary.CreateFileAsync(name, CreationCollisionOption.OpenIfExists),
                    await HttpHelper.GetBufferAsync(uri));
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            catch (Exception)
            {
                await new MessageDialog("未知错误！！").ShowAsync();
            }
        }
    }
}
