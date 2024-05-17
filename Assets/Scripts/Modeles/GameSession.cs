using Scripts.Components.UI.Widgets;
using Scripts.Modeles.Property;
using System;
using UnityEngine;

namespace Scripts.Modeles
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private Item[] _items;

        public ObservableProperty<int> GetValueItem(TagItem tag)
        {
            foreach (var item in _items)
            {
                if (item.Tag == tag) return item.Value;
            }
            throw new Exception($"предмета с тегом {tag} нет");
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                var tagString = item.Tag.ToString();
                switch (item.Tag)
                {
                    case TagItem.Coin:
                        var currentCoin = PlayerPrefs.GetInt(tagString);
                        PlayerPrefs.SetInt(tagString, currentCoin + item.Value.Value);
                        break;
                    case TagItem.Point:
                        var currentRecord = PlayerPrefs.GetInt(tagString);
                        if (item.Value.Value > currentRecord)
                            PlayerPrefs.SetInt(tagString, item.Value.Value);
                        break;
                }
            }
            PlayerPrefs.Save();
        }
    }

    [Serializable]
    public class Item
    {
        [SerializeField] private TagItem _tag;
        public ObservableProperty<int> Value;

        public TagItem Tag => _tag;
    }
}