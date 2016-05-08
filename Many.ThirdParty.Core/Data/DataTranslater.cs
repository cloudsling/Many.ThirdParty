using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Many.ThirdParty.Core.Data
{
    public static class DataTranslater
    {
        private static StorageFolder target = ApplicationData.Current.LocalCacheFolder;

        internal static async Task<StorageFile> TryGetCacheFile(string fileName)
        {
            if (await CheckIfFileExist(fileName))
                return await target.GetFileAsync(fileName);

            return null;
        }

        private static async Task<bool> CheckIfFileExist(string fileName)
        {
            return await target.TryGetItemAsync(fileName) != null;
        }

        internal static async void TranslateSource(string uri, string fileName)
        {
            await SaveFile(await TryGetCacheFile(fileName), await HttpHelper.GetBufferAsync(uri));
        }

        internal static async Task SaveFile(StorageFile file, IBuffer buff)
        {
            if (file != null)
                await FileIO.WriteBufferAsync(file, buff);
        }
    }
}
