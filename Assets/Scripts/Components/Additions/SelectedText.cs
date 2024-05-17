using Scripts.Components.UI.Widgets;
using Scripts.Helpers;
using Scripts.Modeles;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components.Additions
{
    [RequireComponent(typeof(Text))]
    public class SelectedText : MonoBehaviour
    {
        [SerializeField] private string _newText;
        [SerializeField] private TagItem _tag;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            var currentValue = FindObjectOfType<GameSession>().GetValueItem(_tag).Value;
            var oldValue = PlayerPrefs.GetInt(_tag.ToString());
            if (currentValue > oldValue) _text.UpdateSize(_newText);
        }
    }
}
