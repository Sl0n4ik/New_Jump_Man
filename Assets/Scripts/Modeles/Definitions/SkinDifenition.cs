using Scripts.Components.UI.Widgets;
using Scripts.Interfeices;
using System;
using UnityEngine;

namespace Scripts.Modeles.Definitions
{
    [CreateAssetMenu(fileName = "HeroDef", menuName = "Def/HeroDef")]
    public class SkinDifenition : BaseDefinition<Skin>
    {
        [SerializeField] private RareSetting[] _rareSettings;

        public RareSetting GetRareSetting(Rare rare)
        {
            foreach (var setting in _rareSettings)
            {
                if (rare == setting.Rare) return setting;
            }
            throw new Exception($"для {rare} не настроен цвет");
        }

        [ContextMenu("NewGame")]
        private void NewGame()
        {
            foreach (var skin in Elements)
            {
                skin.IsPurchased = skin.ID == _nameBaseElement;
            }
            PlayerPrefs.DeleteAll();
        }

        [ContextMenu("AddMany")]
        private void AddMany()
        {
            var current = PlayerPrefs.GetInt(TagItem.Coin.ToString());
            PlayerPrefs.SetInt(TagItem.Coin.ToString(), current + 100000);
            PlayerPrefs.Save();
        }
    }

    [Serializable]
    public class RareSetting
    {
        [SerializeField] private Rare _rare;
        [SerializeField] private SpritesForAnimations[] _animations;
        [SerializeField] private Color _color;

        public Rare Rare => _rare;
        public SpritesForAnimations[] Animations => _animations;
        public Color Color => _color;
    }

    [Serializable]
    public class Skin : IWare<string>
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _spriteForUI;
        [SerializeField] private SpritesForAnimations[] _animations;
        [SerializeField] private Rare _rare;
        [SerializeField] private bool _isPurchased;

        public string ID => _name;
        public Sprite SpriteForUI => _spriteForUI;
        public SpritesForAnimations[] Animations => _animations;
        public Rare Rare => _rare;
        public int Price => (int)_rare;

        public bool IsPurchased
        {
            get
            {
                return _isPurchased || PlayerPrefs.HasKey(_name);
            }
            set
            {
                _isPurchased = value;
                if (value)
                {
                    PlayerPrefs.SetInt(_name, 0);
                }
            }
        }
    }

    [Serializable]
    public class SpritesForAnimations
    {
        [SerializeField] private string _nameAnimation;
        [SerializeField] private Sprite[] _sprites;

        public string NameAnimation => _nameAnimation;
        public Sprite[] Sprites => _sprites;
    }

    public enum Rare
    {
        Common = 150,
        Rare = 300,
        Epic = 500
    }
}