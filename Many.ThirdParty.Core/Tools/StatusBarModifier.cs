using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace Many.ThirdParty.Core.Tools
{
    public static class StatusBarModifier
    {
        /// <summary>
        /// if we can modify StatusBar
        /// </summary>
        /// <returns></returns>
        private static readonly bool IfCanModifyStatusBar
             = Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar");

        private static StatusBar statusBar = IfCanModifyStatusBar ? StatusBar.GetForCurrentView() : null;

        private static readonly StatusBarProgressIndicator progressIndicator
                = IfCanModifyStatusBar ? StatusBar.GetForCurrentView().ProgressIndicator : null;

        private static Color DarkColor = Color.FromArgb(0xFF, 54, 54, 56);
        private static Color LightColor = Color.FromArgb(0xFF, 255, 255, 255);

        public async static Task HideStatusBar()
        {
            if (IfCanModifyStatusBar) await statusBar.HideAsync();
        }

        public async static Task ShowStatusBar()
        {
            if (IfCanModifyStatusBar) await statusBar.ShowAsync();
        }

        public static void SetStatusBar(Color foregroundColor, Color backgroundColor, double backgroundOpacity = 1)
        {
            if (!IfCanModifyStatusBar) return;
            statusBar.ForegroundColor = foregroundColor;
            statusBar.BackgroundColor = backgroundColor;
            statusBar.BackgroundOpacity = backgroundOpacity;
        }

        public static void SetDarkStatusBar()
        {
            SetStatusBar(LightColor, DarkColor);
        }

        public static void SetLightStatusBar()
        {
            SetStatusBar(DarkColor, LightColor);
        }

        public async static Task SetStatusBarProgressIndicator(double? progressValue, string text)
        {
            if (!IfCanModifyStatusBar) return;
            progressIndicator.ProgressValue = progressValue;
            progressIndicator.Text = text;
            await progressIndicator.ShowAsync();
        }
    }
}
