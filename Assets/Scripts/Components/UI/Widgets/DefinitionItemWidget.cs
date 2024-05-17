using Scripts.Helpers;
using Scripts.Interfeices;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components.UI.Widgets
{
    public class DefinitionItemWidget<T> : MonoBehaviour where T : IWare<string>
    {
        [SerializeField] private Image _imageItem;
        [SerializeField] private SimilarityMode _mode = SimilarityMode.Vertical;
        [SerializeField] private Image _lock;
        [SerializeField] private Image _unLock;
        [SerializeField] private Image _select;
        [SerializeField] private NameFileSave _nameFileSave;

        private RectTransform _transformSkin;
        private T _valueItem;

        private string NameFileForSave;

        private void Awake()
        {
            NameFileForSave = _nameFileSave.ToString();
        }

        public T ValueItem
        {
            get
            {
                return _valueItem;
            }
            set
            {
                if (_transformSkin == null) _transformSkin = _imageItem.GetComponent<RectTransform>();
                _valueItem = value;
                SetImageSkin();
                SetImageLock();
            }
        }

        public Color ColorBox
        {
            set
            {
                _lock.color = value;
                _unLock.color = value;
            }
        }

        public bool IsSelect
        {
            get
            {
                return _select.enabled;
            }
            set
            {
                _select.enabled = value && _valueItem.IsPurchased;
                if (_select.enabled)
                {
                    PlayerPrefs.SetString(NameFileForSave, _valueItem.ID);
                    PlayerPrefs.Save();
                }
            }
        }

        private void SetImageLock()
        {
            _lock.enabled = !_valueItem.IsPurchased;
        }

        private void SetImageSkin()
        {
            _imageItem.SetSprite(_valueItem.SpriteForUI, _transformSkin, _mode);
        }
    }

    public enum NameFileSave
    {
        Skin,
        Map,
    }
}