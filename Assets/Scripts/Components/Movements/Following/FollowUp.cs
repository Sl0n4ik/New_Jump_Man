using UnityEngine;

namespace Scripts.Components.Movements.Following
{
    public class FollowUp : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private Transform _transform;
        private float _distance;

        private void Awake()
        {
            _transform = transform;
            _distance = _target.position.y - _transform.position.y;
        }

        private void Update()
        {
            if (_target.position.y - _transform.position.y > _distance)
            {
                _transform.position = new Vector3(_transform.position.x, _target.position.y - _distance, _transform.position.z);
            }
        }
    }
}