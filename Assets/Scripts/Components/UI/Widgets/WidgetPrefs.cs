using Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components.UI.Widgets
{
    [RequireComponent(typeof(Text))]
    public class WidgetPrefs : MonoBehaviour
    {
        [SerializeField] private TagItem _tag;

        [SerializeField] private int _t;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void OnEnable()
        {
            OnUpdate();
        }

        public void OnUpdate()
        {
            _text.UpdateSize(PlayerPrefs.GetInt(_tag.ToString()).ToString());
        }

        [ContextMenu("test")]
        private void Test()
        {
            _text.UpdateSize(_t.ToString());
        }
    }
}