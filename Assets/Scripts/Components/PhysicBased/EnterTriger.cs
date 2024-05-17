using UnityEngine;

namespace Scripts.Components.PhysicBased
{
    [RequireComponent(typeof(Collider2D))]
    public class EnterTriger : PhysicCallEvent
    {
        private void OnTriggerEnter2D(Collider2D trigger)
        {
            CallEvent(trigger);
        }
    }
}