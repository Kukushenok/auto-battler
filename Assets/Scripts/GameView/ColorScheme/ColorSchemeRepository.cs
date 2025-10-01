using AutoBattler.Utils;
using UnityEngine;

namespace Game.View.ColorScheme
{
    public class ColorSchemeRepository: IColorSchemeRepository
    {
        private ColorSchemeSO colorSchemeSO;
        private IRandom rnd;
        public ColorSchemeRepository(IRandom rnd, ColorSchemeSO so)
        {
            this.rnd = rnd;
            colorSchemeSO = so;
        }

        public ColorScheme GetColorScheme()
        {
            Vector3 A = ToHSVVector(colorSchemeSO.PrimaryColor);
            Vector3 B = ToHSVVector(colorSchemeSO.BackgroundColor);
            Vector3 C = ToHSVVector(colorSchemeSO.TemporaryColor);

            Vector3 dB = B - A;
            Vector3 dC = C - A;
            A.x = rnd.GetRange(0.0f, 1.0f);
            B = A + dB;
            C = A + dC;
            return new ColorScheme(
                FromHSVVector(A),
                FromHSVVector(B),
                FromHSVVector(C)
            );
        }
        private Vector3 ToHSVVector(Color x)
        {
            Vector3 d = new Vector3();
            Color.RGBToHSV(x, out d.x, out d.y, out d.z);
            return d;
        }
        private Color FromHSVVector(Vector3 vec)
        {
            return Color.HSVToRGB(Mathf.Repeat(vec.x, 1), vec.y, vec.z);
        }

    }
}
