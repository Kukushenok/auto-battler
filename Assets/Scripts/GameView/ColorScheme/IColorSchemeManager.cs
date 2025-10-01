using System;

namespace Game.View.ColorScheme
{
    public interface IColorSchemeManager
    {
        public IDisposable BindSubscription(IColorSchemeSubscriber sub);
        public void ChangeColorScheme();
    }
}
