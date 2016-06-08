using Windows.ApplicationModel.DataTransfer;

namespace Many.ThirdParty.Core.Data
{
    public static class Replicators
    {
        public static void CopyString(object content)
        {
            DataPackage dataPackage = new DataPackage();

            dataPackage.SetText(content as string ?? string.Empty);
            Clipboard.SetContent(dataPackage);
        }
    }
}
