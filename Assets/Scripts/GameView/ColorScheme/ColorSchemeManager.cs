using System;
using System.Collections.Generic;

namespace Game.View.ColorScheme
{
    public class ColorSchemeManager: IColorSchemeManager
    {
        private class ColorSchemeSubscription : IDisposable, IColorSchemeSubscriber
        {
            private ColorSchemeManager mngr;
            private IColorSchemeSubscriber sub;
            public ColorSchemeSubscription(ColorSchemeManager mngr, IColorSchemeSubscriber sub)
            {
                this.mngr = mngr;
                this.sub = sub;
            }

            public void Dispose()
            {
                mngr.subs.Remove(this);
                mngr = null;
                sub = null;
            }

            public void SetColorScheme(ColorScheme scheme, bool firstTime = false)
            {
                sub.SetColorScheme(scheme, firstTime);
            }
        }
        private IColorSchemeRepository colorSchemeSO;
        private ColorScheme current;
        private List<ColorSchemeSubscription> subs = new List<ColorSchemeSubscription>();
        public ColorSchemeManager(IColorSchemeRepository colorSchemeSO)
        {
            this.colorSchemeSO = colorSchemeSO;
            current = colorSchemeSO.GetColorScheme();
        }
        public IDisposable BindSubscription(IColorSchemeSubscriber sub)
        {
            var t = new ColorSchemeSubscription(this, sub);
            t.SetColorScheme(current, true);
            subs.Add(t);
            return t;
        }
        private void Notify()
        {
            subs.ForEach(x => x.SetColorScheme(current));
        }
        public void ChangeColorScheme()
        {
            current = colorSchemeSO.GetColorScheme();
            Notify();
        }
    }
}
