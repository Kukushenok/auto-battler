using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.View
{
    [RequireComponent(typeof(RectTransform))]
    public class HoverRotationEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
    {
        private bool activated = false;
        [SerializeField] private Vector2 sensivity;
        [SerializeField] private float maxDelta = 30;
        [SerializeField] private float speed = 0.5f;
        private Quaternion rotation;
        private Quaternion originRotation;
        private RectTransform rectTransform;
        void Awake()
        {
            rectTransform = (RectTransform)transform;
            rotation = originRotation = rectTransform.rotation;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            Vector2 delta = rectTransform.position - eventData.pointerCurrentRaycast.worldPosition;
            if (delta.magnitude > maxDelta) delta = delta.normalized * maxDelta;
            rotation = Quaternion.Euler(-sensivity.y * delta.y, sensivity.x * delta.x, 0);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            rotation = originRotation;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            OnPointerEnter(eventData);
        }

        // Update is called once per frame
        void Update()
        {
            rectTransform.rotation = Quaternion.Slerp(rectTransform.rotation, rotation, 1 - Mathf.Exp(-Time.deltaTime * speed));
        }
    }
}
