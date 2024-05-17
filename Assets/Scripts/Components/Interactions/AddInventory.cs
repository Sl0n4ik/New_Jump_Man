using Scripts.Components.UI.Widgets;
using Scripts.Modeles;
using Scripts.Modeles.Property;
using UnityEngine;

namespace Scripts.Components.Interactions
{
    public class AddInventory : MonoBehaviour
    {
        [SerializeField] private int _count;
        [SerializeField] private TagItem _tag;

        private GameSession _session;
        private ObservableProperty<int> _value;

        private void Awake()
        {
            _session = FindObjectOfType<GameSession>();
            _value = _session.GetValueItem(_tag);
        }

        public void Add()
        {
            _value.Value += _count;
        }
    }
}