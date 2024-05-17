using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Interactions.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private float _multiplier = 1;
        [SerializeField] private UnityEvent _onTake;

        public float Multiplier
        {
            get
            {
                _onTake?.Invoke();
                return _multiplier;
            }
        }
    }
}