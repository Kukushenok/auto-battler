using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using VContainer;

namespace Game.View.ColorScheme
{
    public class MaterialPropertyColorSchemeChanger : MonoBehaviour, IColorSchemeSubscriber
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
                instance.SetColor("NormalColor", scheme.MainColor);
                instance.SetColor("DerpthsColor", scheme.BackgroundColor);
            }
            else
            {
                Color currBackground = instance.GetColor("DerpthsColor");
                Color currBackgroundNormal = instance.GetColor("NormalColor");
                LMotion.Create(currBackground, scheme.BackgroundColor, colorChangeTime).BindToMaterialColor(instance, "DerpthsColor").AddTo(gameObject);
                LMotion.Create(currBackgroundNormal, scheme.MainColor, colorChangeTime).BindToMaterialColor(instance, "NormalColor").AddTo(gameObject);
            }

        }
        public void OnDestroy()
        {
            Destroy(instance);
        }
    }
}
