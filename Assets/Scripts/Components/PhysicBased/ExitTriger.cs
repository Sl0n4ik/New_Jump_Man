using UnityEngine;

namespace Scripts.Components.PhysicBased
{
    public class ExitTriger : PhysicCallEvent
    {
        private void OnTriggerExit2D(Collider2D trigger)
        {
            CallEvent(trigger);
        }
    }
}