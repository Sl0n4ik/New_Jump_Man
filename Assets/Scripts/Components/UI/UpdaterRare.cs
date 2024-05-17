using Scripts.Modeles.Definitions;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.UI
{
    public class UpdaterRare : MonoBehaviour
    {
        [SerializeField] private Rare _rare;
        [SerializeField] private UnityEvent<Rare> _targetGroup;

        public void OnUpdate()
        {
            _targetGroup?.Invoke(_rare);
        }
    }
}