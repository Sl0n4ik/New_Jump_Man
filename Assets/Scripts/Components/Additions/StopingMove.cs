using Scripts.Helpers;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Additions
{
    public class StopingMove : MonoBehaviour
    {
        [SerializeField] private Caldawn _timeStop;
        [SerializeField] private UnityEvent _onCompleteStop;

        private bool _isStopComplete;
        private Transform _transform;
        private float _stopPosition;

        private void Awake()
        {
            _transform = transform;
            _stopPosition = transform.position.x;
        }

        private void Update()
        {
            if (!_timeStop.Is—omplete)
            {
                _transform.position = new Vector3(_stopPosition, _transform.position.y, _transform.position.z);
            }
            else if (!_isStopComplete)
            {
                _isStopComplete = true;
                _onCompleteStop?.Invoke();
            }
        }

        public void Stop()
        {
            _isStopComplete = false;
            _stopPosition = _transform.position.x;
            _timeStop.StartCaldawn();
        }
    }
}