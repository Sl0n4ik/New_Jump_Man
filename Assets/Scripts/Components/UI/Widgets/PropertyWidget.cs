using Scripts.Helpers;
using Scripts.Modeles;
using Scripts.Modeles.Property;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components.UI.Widgets
{
    [RequireComponent(typeof(Text))]
    public class PropertyWidget : MonoBehaviour
    {
        [SerializeField] private TagItem _tag;
        [SerializeField] private string _addText;

        private GameSession _session;
        private ObservableProperty<int> _value;
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _session = FindObjectOfType<GameSession>();
            _value = _session.GetValueItem(_tag);
            _value.OnChange += OnChanged;
            OnChanged(_value.Value);
        }

        private void OnDestroy()
        {
            _value.OnChange -= OnChanged;
        }

        private void OnChanged(int value)
        {
            _text.UpdateSize(value.ToString() + _addText);
        }
    }

    public enum TagItem
    {
        Coin,
        Point
    }
}