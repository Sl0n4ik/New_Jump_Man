using UnityEngine;

namespace Scripts.Components.Movements.Following
{
    public class HardFollow : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        private Transform _targetTransform;
        private Transform _transform;

        private float DeltaY
        {
            get
            {
                var sprite = _renderer.sprite;
                return sprite.textureRect.height / sprite.pixelsPerUnit;
            }
        }

        private void Awake()
        {
            _targetTransform = _renderer.transform;
            _transform = transform;
        }

        private void Update()
        {
            _transform.position = new Vector3(_targetTransform.position.x, _targetTransform.position.y + DeltaY, _targetTransform.position.z);
        }
    }
}