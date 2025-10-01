using UnityEngine;

namespace Game.View.ColorScheme
{
    public class ColorScheme
    {
        public readonly Color MainColor;
        public readonly Color BackgroundColor;
        public readonly Color TintedColor;
        public ColorScheme(Color main, Color back, Color tinted)
        {
            MainColor = main;
            BackgroundColor = back;
            TintedColor = tinted;
        }
    }
}
