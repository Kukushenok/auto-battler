using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using VContainer;

namespace Game.View.ColorScheme
{
    public class ParticleSystemColorSchemeChanger : MonoBehaviour, IColorSchemeSubscriber
    {
        [SerializeField] private Renderer[] renderers;
        [SerializeField] private Material coreMaterial;
        [SerializeField] private float colorChangeTime;
        private Material instance;
        [Inject]
        private void Construct(IColorSchemeManager manager)
        {
            instance = Instantiate(coreMaterial);
            manager.BindSubscription(this).AddTo(destroyCancellationToken);
        }
        public void Awake()
        {
            foreach (var R in renderers) R.material = instance;
        }

        public void SetColorScheme(ColorScheme scheme, bool firstTime)
        {
            if (firstTime)
            {
                instance.SetColor("OtherColor", scheme.TintedColor);
            }
            else
            {
                Color currBackground = instance.GetColor("OtherColor");
                LMotion.Create(currBackground, scheme.TintedColor, colorChangeTime).BindToMaterialColor(instance, "OtherColor").AddTo(gameObject);
            }

        }
        public void OnDestroy()
        {
            Destroy(instance);
        }
    }
}
