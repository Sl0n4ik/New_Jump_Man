using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.Components.UI
{
    [RequireComponent(typeof(Button))]
    public class SwitchImageForButton : MonoBehaviour
    {
        [SerializeField] private ElementForSwitching[] _elements;

        private Button _button;
        private int _currentIndex;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void OnSwitch()
        {
            _currentIndex = (int)Mathf.Repeat(++_currentIndex, _elements.Length);
            _button.image = _elements[_currentIndex].Image;
            for (int i = 0; i < _elements.Length; i++)
            {
                _elements[i].IsActive = i == _currentIndex;
            }
        }

        [Serializable]
        private class ElementForSwitching
        {
            [SerializeField] private Image _image;
            [SerializeField] private UnityEvent<bool> _onActive;

            public Image Image => _image;
            public UnityEvent<bool> OnActive => _onActive;

            public bool IsActive
            {
                set
                {
                    _image.enabled = value;
                    _onActive?.Invoke(value);
                }
            }
        }
    }
}