using UnityEngine;

namespace Scripts.Components.PhysicBased
{
    public class EnterCollision : PhysicCallEvent
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            CallEvent(collision.collider);
        }
    }
}