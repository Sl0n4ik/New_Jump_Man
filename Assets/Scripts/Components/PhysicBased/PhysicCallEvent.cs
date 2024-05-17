using Scripts.Attributes;
using Scripts.Helpers;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.PhysicBased
{
    public abstract class PhysicCallEvent : MonoBehaviour
    {
        [SerializeField] [Tag] private string[] _tags;
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private UnityEvent<GameObject> _action;

        protected void CallEvent(Collider2D trigger)
        {
            if (trigger.gameObject.IsInLayer(_layer))
            {
                _action?.Invoke(trigger.gameObject);
                return;
            }

            foreach (var tag in _tags)
            {
                if (trigger.gameObject.CompareTag(tag))
                {
                    _action?.Invoke(trigger.gameObject);
                    return;
                }
            }
        }
    }
}