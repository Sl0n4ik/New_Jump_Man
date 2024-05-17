using UnityEngine;

namespace Scripts.Components.Additions
{
    public class AdabtiveCamera : MonoBehaviour
    {
        [SerializeField] private float _widthInUnit;
        [SerializeField] private float _heightInUnit;

        private Camera _camera;
        private float currentWidth => _camera.ViewportToWorldPoint(Vector2.right * Screen.safeArea.width / Screen.width).x - _camera.ViewportToWorldPoint(Vector2.zero).x;
        private float currentHeight => _camera.ViewportToWorldPoint(Vector2.up * Screen.safeArea.height / Screen.height).y - _camera.ViewportToWorldPoint(Vector2.zero).y;
        
        [ContextMenu("adaptive")]
        private void Awake()
        {
            _camera = GetComponent<Camera>();
            var rect = _camera.rect;
            var startPosition = _camera.ViewportToWorldPoint(Vector2.zero).y;
            if (Screen.safeArea.height > Screen.safeArea.width)
            {
                rect.position = Screen.safeArea.position / new Vector2(Screen.width, Screen.height);
                rect.height = Screen.safeArea.height / Screen.height;
                rect.width = Screen.safeArea.width / Screen.width;
                _camera.rect = rect;
                var multiplierSize = _widthInUnit / currentWidth;
                _camera.orthographicSize *= multiplierSize;
            }
            else
            {
                var multiplierSize = _heightInUnit / currentHeight;
                _camera.orthographicSize *= multiplierSize;
                rect.width = _widthInUnit / currentWidth;
                _camera.rect = rect;
                rect.position = new Vector2((Screen.width - _camera.ViewportToScreenPoint(Vector2.right).x) * 0.5f / Screen.width, 0);
                _camera.rect = rect;
            }
            transform.position += new Vector3(0, startPosition - _camera.ViewportToWorldPoint(Vector2.zero).y, 0);
        }
    }
}