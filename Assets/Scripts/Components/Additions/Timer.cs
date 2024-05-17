using Scripts.Components.Input;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Additions
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _minTime;
        [SerializeField] private float _maxTime;
        [SerializeField] private UnityEvent _onCompleteTimer;

        private InputReader _input;
        private float _nextTime;
        private float _remaningTime;
        private bool _isActive;

        private float _randomValue => Random.Range(_minTime, _maxTime);

        private void Awake()
        {
            StartTimer();
            _input = FindObjectOfType<InputReader>();
            _input.OnPauseKey += OnPause;
        }

        private void Update()
        {
            if (Time.time > _nextTime && _isActive)
            {
                _isActive = false;
                _onCompleteTimer?.Invoke();
            }
        }

        public void StartTimer()
        {
            _nextTime = Time.time + _randomValue;
            _isActive = true;
        }

        public void OnPause(bool isPause)
        {
                enabled = !isPause;
            if (isPause)
            {
                _remaningTime = _nextTime - Time.time;
            }
            else
            {
                _nextTime = Time.time + _remaningTime;
            }
        }
    }
}
