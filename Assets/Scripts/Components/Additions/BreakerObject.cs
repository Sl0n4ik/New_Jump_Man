using UnityEngine;

namespace Scripts.Components.Additions
{
    public class BreakerObject : MonoBehaviour
    {
        public void BreakObject(GameObject target)
        {
            target.SetActive(false);
        }
    }
}