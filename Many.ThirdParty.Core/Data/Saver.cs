using System;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Tools;
using Windows.Storage;
using Windows.UI.Popups;

namespace Many.ThirdParty.Core.Data
{
    public static class Saver
    {
        private static StorageFolder _systemPicturesLibrary;

        public static async Task TryGetPicturesLibrary()
        {
            try
            {
                _systemPicturesLibrary = await KnownFolders.PicturesLibrary.CreateFolderAsync("一个", CreationCollisionOption.OpenIfExists);
            }
            catch (UnauthorizedAccessException)
            {
                await new MessageDialog("访问图片库被拒绝！！！！！").ShowAsync();
                throw;
            }
        }

        internal static async Task<bool> SavePic(string name, string uri)
        {
            if (string.IsNullOrEmpty(uri)) return false;
            try
            {
                if (_systemPicturesLibrary == null)
                    await TryGetPicturesLibrary();

                await FileIO.WriteBufferAsync(
                    // ReSharper disable once PossibleNullReferenceException
                    await _systemPicturesLibrary.CreateFileAsync(name, CreationCollisionOption.OpenIfExists),
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