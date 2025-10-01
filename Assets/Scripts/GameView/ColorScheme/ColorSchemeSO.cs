using UnityEngine;

namespace Game.View.ColorScheme
{
    [CreateAssetMenu(fileName = "ColorSchemeSO", menuName = "Scriptable Objects/View/ColorScheme")]
    public class ColorSchemeSO : ScriptableObject
    {
        [Header("Colors are declared relative to PrimaryColor. ")]
        [field: SerializeField] public Color PrimaryColor { get; private set; }
        [field: SerializeField] public Color BackgroundColor { get; private set; }
        [field: SerializeField] public Color TemporaryColor { get; private set; }
    }
}
