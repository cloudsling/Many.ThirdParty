using Windows.UI.Xaml.Media;

namespace Many.ThirdParty.Core.Themes
{
    public abstract class IColorsCollection  
    {
        public abstract Brush TitleBar { get; }

        public abstract Brush ReadingBorder { get; }

        public abstract Brush MainBackground { get; }

        public abstract Brush FontColor { get; }

        public abstract Brush ListHeader { get; }

        public abstract Brush SmallLightFontColor { get; }
    }
}
