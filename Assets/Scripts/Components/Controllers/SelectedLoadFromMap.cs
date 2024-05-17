using Scripts.Components.UI.Widgets;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Controllers
{
    public class SelectedLoadFromMap : MonoBehaviour
    {
        [SerializeField] private NameFileSave _nameSave;
        [SerializeField] private string _nameBaseMap = "Main";
        [SerializeField] private string _nameSelectedMap;
        [SerializeField] private UnityEvent _onSelected;

        private void Awake()
        {
            var nameSave = _nameSave.ToString();
            var nameSaveMap = PlayerPrefs.HasKey(nameSave) ? PlayerPrefs.GetString(nameSave) : _nameBaseMap;
            if (nameSaveMap == _nameSelectedMap)
            {
                _onSelected?.Invoke();
            }
        }
    }
}