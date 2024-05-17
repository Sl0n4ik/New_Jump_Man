using Scripts.Components.Movements;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scripts.Components.Input
{
    public class InputReader : MonoBehaviour, IDragHandler, IPointerMoveHandler, IEndDragHandler
    {
        [SerializeField] private Text _wigetTime;
        [SerializeField] private float _timeUnPause;
        [SerializeField] private UnityEvent _onStart;
        [SerializeField] private UnityEvent _onPause;

        public event Action<bool> OnPauseKey;

        private bool _isPause = false;
        private bool _isStarted;
        private float _position;
        private bool _isPress;
        private bool _lockPause;
        private Movement _move;

        public bool IsStarted => _isStarted;

        private void Awake()
        {
            _move = FindObjectOfType<Movement>();
        }

        private void Update()
        {
            if (_isPause || _lockPause) return;
            if (_isPress)
            {
                _move.SetTargetPosition(_position);
            }
        }

        public void OnPause()
        {
            if (_lockPause) return;
            _isPause = !_isPause;

            _onPause?.Invoke();
            if (_isPause)
            {
                CallPause();
            }
            else
            {
                StartCoroutine(TimeUnPause());
            }
        }

        private IEnumerator TimeUnPause()
        {
            _lockPause = true;
            float currentTime = 0;
            _wigetTime.gameObject.SetActive(true);
            while (currentTime < _timeUnPause)
            {
                yield return null;
                currentTime += Time.deltaTime;
                _wigetTime.text = ((int)(_timeUnPause - currentTime)).ToString();
            }
            _wigetTime.gameObject.SetActive(false);
            _lockPause = false;
            CallPause();
        }

        private void CallPause()
        {
            OnPauseKey?.Invoke(_isPause);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isPause || _lockPause) return;
            _isPress = true;
            if (!_isStarted)
            {
                _isStarted = !_isStarted;
                _onStart?.Invoke();
            }
            _position = eventData.pointerCurrentRaycast.worldPosition.x;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            _position = eventData.pointerCurrentRaycast.worldPosition.x;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isPress = false;
        }
    }
}