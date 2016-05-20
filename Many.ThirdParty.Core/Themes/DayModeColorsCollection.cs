using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Many.ThirdParty.Core.Themes
{
    public class DayModeColorsCollection : IColorsCollection
    {
        public override Brush FontColor { get { return new SolidColorBrush(Color.FromArgb(0xFF, 51, 51, 51)); } }

        public override Brush SmallLightFontColor { get { return new SolidColorBrush(ColorHelper.FromArgb(0xFF, 156, 156, 156)); } }

        public override Brush MainBackground { get { return new SolidColorBrush(Color.FromArgb(0xFF, 255, 255, 255)); } }

        public override Brush ReadingBorder { get { return new SolidColorBrush(Color.FromArgb(0xFF, 255, 255, 255)); } }

        public override Brush TitleBar { get { return new SolidColorBrush(Color.FromArgb(0xFF, 255, 255, 255)); } }

        public override Brush ListHeader { get { return new SolidColorBrush(Color.FromArgb(0xFF, 248, 248, 248)); } }
    }
}
