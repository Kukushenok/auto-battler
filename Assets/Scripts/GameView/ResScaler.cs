using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Game.View
{
    public class KCameraResolutionScaler : MonoBehaviour
    {
        public new Camera camera;
        [SerializeField] private FilterMode filterMode = FilterMode.Bilinear;

        private Rect originalRect;
        private RenderTexture rtx;
        void OnDestroy()
        {
            camera.rect = originalRect;
        }

        void OnPreRender()
        {
            rtx = RenderTexture.GetTemporary(Screen.height / 4, Screen.width / 4, 16);
        }

        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            camera.rect = originalRect;
            src.filterMode = filterMode;
            rtx.filterMode = filterMode;
            Graphics.Blit(src, rtx);
            Graphics.Blit(rtx, dest);
            RenderTexture.ReleaseTemporary(rtx);
        }
    }
}
