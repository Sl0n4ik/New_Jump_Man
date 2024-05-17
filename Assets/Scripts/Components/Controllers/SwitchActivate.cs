using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Controllers
{
    public class SwitchActivate : MonoBehaviour
    {
        [SerializeField] private ObjectForSwitch[] _states;
        [SerializeField] private UnityEvent _onRespawn;

        [SerializeField] private float _sumChance;
        private GameObject _currentPlatform;

        private void Awake()
        {
            Sum();
            Switch();
        }

        private void OnValidate()
        {
            Sum();
        }

        private void Sum()
        {
            float sumChance = 0;
            foreach (var platform in _states)
            {
                sumChance += platform.ChanceActivate;
            }
            _sumChance = sumChance;
        }

        public void Switch()
        {
            _onRespawn?.Invoke();
            var value = UnityEngine.Random.Range(0, _sumChance);
            float currentChance = 0;
            for (int i = 0; i < _states.Length; i++)
            {
                currentChance += _states[i].ChanceActivate;
                if (value <= currentChance)
                {
                    _currentPlatform = _states[i].Object;
                    _currentPlatform.SetActive(true);
                    break;
                }
            }

            foreach (var platform in _states)
            {
                if (platform.Object != _currentPlatform)
                {
                    platform.Object.SetActive(false);
                }
            }
        }

        [Serializable]
        private class ObjectForSwitch
        {
            [SerializeField] private GameObject _object;
            [SerializeField] private float _chanceActivate;

            public GameObject Object => _object;
            public float ChanceActivate => _chanceActivate;
        }
    }
}