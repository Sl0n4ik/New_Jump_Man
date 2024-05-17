using Scripts.Components.Input;
using Scripts.Components.Interactions.Platforms;
using Scripts.Components.UI.Widgets;
using Scripts.Helpers;
using Scripts.Modeles;
using Scripts.Modeles.Property;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Movements
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _accelerationOfGravity;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _speedJump;
        [SerializeField] private float _inaccuracy;
        [SerializeField] private float _speed;
        [SerializeField] private float _maxDistanceForLerp;
        [SerializeField] private int _maxCountJumpOnPlatform;
        [Header("äåëèòåëè äëÿ ðàñ÷¸òà ñëîæíîñòè")]
        [SerializeField] private float _dividerForDeltaGravity = 500;
        [SerializeField] private float _dividerForDeltaInaccuracy = 1000;
        [SerializeField] private float _dividerForDeltaSpeed = 500;
        [SerializeField] private UnityEvent _onSiteDelay;

        private int _direction;
        private float _currentSpeedFall;
        private float _targetPositionY;
        private bool _isJump;
        private float _deltaGravity;
        private float _deltaInaccuracy;
        private float _deltaSpeed;
        private int _currentCountOnPlatform;
        private GameSession _session;
        private ObservableProperty<int> _value;
        private Rigidbody2D _rigidbady;
        private InputReader _input;
        private GameObject _currentPlatform;

        public event Action<bool> OnJump;
        public event Action<int> OnÑhangeDirection;

        private float CurrentAccelerationOfGravity => _accelerationOfGravity + _deltaGravity;
        private float CurrentInaccuracy => _inaccuracy + _deltaInaccuracy;
        private float CurrentSpeed => _speed + _deltaSpeed;

        private bool IsJump
        {
            set
            {
                _isJump = value;
                OnJump?.Invoke(_isJump);
            }
        }

        private void Awake()
        {
            _rigidbady = GetComponent<Rigidbody2D>();

            _input = FindObjectOfType<InputReader>();
            _input.OnPauseKey += OnPause;

            _session = FindObjectOfType<GameSession>();
            _value = _session.GetValueItem(TagItem.Point);
            _value.OnChange += AddComplexityByPoints;
        }

        private void OnDestroy()
        {
            _input.OnPauseKey -= OnPause;
            _value.OnChange -= AddComplexityByPoints;
        }

        private void FixedUpdate()
        {
            float deltaY;
            if (_isJump)
            {
                deltaY = JumpÑalculat();

                if (_rigidbady.position.y >= _targetPositionY - CurrentInaccuracy)
                {
                    IsJump = false;
                }
            }
            else
            {
                _currentSpeedFall += MultipliDeltaTime(CurrentAccelerationOfGravity);
                deltaY = -MultipliDeltaTime(_currentSpeedFall);
            }
            _rigidbady.MovePosition(_rigidbady.position + new Vector2(0, deltaY));
        }

        public void StopJump()
        {
            IsJump = false;
        }

        public void JumpByPlatform(GameObject platform)
        {
            if (_currentPlatform == platform)
            {
                _currentCountOnPlatform++;
                if (_currentCountOnPlatform >= _maxCountJumpOnPlatform)
                {
                    _onSiteDelay?.Invoke();
                }
            }
            else
            {
                _currentPlatform = platform;
                _currentCountOnPlatform = 1;
            }
            Jump(platform.GetComponent<Platform>().Multiplier);
        }

        private void Jump(float multiplier = 1)
        {
            _currentSpeedFall = 0;
            _targetPositionY = _rigidbady.position.y + _jumpHeight * multiplier + _deltaInaccuracy;
            IsJump = true;
        }

        private void OnPause(bool isPause)
        {
            if (_input != null && !_input.IsStarted) return;
            enabled = !isPause;
        }

        private float JumpÑalculat()
        {
            var newPositionY = Mathf.Lerp(_rigidbady.position.y, _targetPositionY, MultipliDeltaTime(_speedJump));
            return newPositionY - _rigidbady.position.y;
        }

        public void SetTargetPosition(float target)
        {
            var distance = target - _rigidbady.position.x;
            _direction = distance.InUnit();
            if(Mathf.Abs(distance) > _maxDistanceForLerp)
            {
                target = _rigidbady.position.x +_maxDistanceForLerp * _direction;
            }
            var t = Mathf.Lerp(_rigidbady.position.x, target, Time.deltaTime * CurrentSpeed);
            _rigidbady.position = new Vector2(t, _rigidbady.position.y);

            OnÑhangeDirection?.Invoke(_direction);
        }

        private float MultipliDeltaTime(float value)
        {
            return value * Time.fixedDeltaTime;
        }

        private void AddComplexityByPoints(int points)
        {
            _deltaGravity = points / _dividerForDeltaGravity;
            _deltaInaccuracy = points / _dividerForDeltaInaccuracy;
            _deltaSpeed = points / _dividerForDeltaSpeed;
        }
    }
}