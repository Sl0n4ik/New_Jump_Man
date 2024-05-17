using Scripts.Attributes;
using Scripts.Components.UI.Widgets;
using Scripts.Interfeices;
using Scripts.Modeles.Definitions;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Controllers
{
    public abstract class BaseDataGroup<T, TDef, TItem> : MonoBehaviour 
        where T : class, IWare<string> 
        where TDef : BaseDefinition<T>
        where TItem : DefinitionItemWidget<T>
    {
        [SerializeField] [PathesInResources] private string _path;
        [SerializeField] private Transform _container;
        [SerializeField] private TItem _item;
        [SerializeField] private NameFileSave _nameFileSave;
        [SerializeField] private UnityEvent<T> _onSelect;

        protected TDef Definition;
        protected List<TItem> _currentItems = new List<TItem>();
        private List<T> _currentValues = new List<T>();
        protected T SelectValue;
        protected string NameFileForSave;

        private GameObject Prefab => _item.gameObject;

        public void Start()
        {
            NameFileForSave = _nameFileSave.ToString();
            Definition = Resources.Load<TDef>(_path);
            if (PlayerPrefs.HasKey(NameFileForSave))
            {
                var nameSelectSkin = PlayerPrefs.GetString(NameFileForSave);
                SelectValue = Definition.GetElement(nameSelectSkin);
            }
            else
            {
                SelectValue = Definition.GetBaseElement();
            }
            OnUpdateGroup();
        }

        protected abstract void OnUpdateGroup();

        public void Updater()
        {
            int index = Definition.GetElements(_currentValues, Condition);
            for (var i = 0; i < index; i++)
            {
                var value = _currentValues[i];
                if (i < _currentItems.Count)
                {
                    var item = _currentItems[i];
                    SetSkinInItem(item, value);
                    item.IsSelect = false;
                }
                else
                {
                    var newClone = Instantiate(Prefab, _container);
                    var newItem = newClone.GetComponent<TItem>();
                    SetSkinInItem(newItem, value);
                    _currentItems.Add(newItem);
                }
            }

            for (; index < _currentItems.Count; index++)
            {
                _currentItems[index].gameObject.SetActive(false);
            }
            OnCompleteUpdate();
        }

        protected abstract void OnCompleteUpdate();

        protected abstract bool Condition(T value);

        protected TItem GetSkinItem(T skin)
        {
            foreach (var item in _currentItems)
            {
                if (item.ValueItem == skin)
                {
                    return item;
                }
            }
            throw new Exception($"нет окна со скином {skin.ID}");
        }

        public virtual void SetSelect(TItem item)
        {
            _onSelect?.Invoke(item.ValueItem);
            if (!item.ValueItem.IsPurchased) return;
            foreach (var valueItem in _currentItems)
            {
                valueItem.IsSelect = valueItem == item;
                if (valueItem.IsSelect)
                {
                    SelectValue = valueItem.ValueItem;
                }
            }
        }

        protected virtual void SetSkinInItem(DefinitionItemWidget<T> item, T value)
        {
            item.ValueItem = value;
            item.gameObject.SetActive(true);
        }
    }
}