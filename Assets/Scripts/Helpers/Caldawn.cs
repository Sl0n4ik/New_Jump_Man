using System;
using UnityEngine;

namespace Scripts.Helpers
{
    [Serializable]
    public class Caldawn
    {
        [SerializeField] private float _value;

        private float _nextTime;

        public bool Is�omplete => Time.time > _nextTime;

        public void StartCaldawn()
        {
            _nextTime = Time.time + _value;
        }
    }
}