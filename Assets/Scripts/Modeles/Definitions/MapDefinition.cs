using Scripts.Interfeices;
using System;
using UnityEngine;

namespace Scripts.Modeles.Definitions
{
    [CreateAssetMenu(fileName = "MapDef", menuName = "Def/MapDef")]
    public class MapDefinition : BaseDefinition<Map> { }

    [Serializable]
    public class Map : IWare<string>
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _spriteForUI;
        [SerializeField] private SettingPrefab[] _settings;
        [SerializeField] private bool _isPurchased;
        [SerializeField] private int _price;

        public string ID => _name;
        public Sprite SpriteForUI => _spriteForUI;
        public SettingPrefab[] Settings => _settings;
        public int Price => _price;


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

        public GameObject GetPrefab(TagPrefab tag)
        {
            foreach(var setting in _settings)
            {
                if(setting.Tag == tag)
                {
                    return setting.Prafab;
                }
            }
            throw new Exception($"для карты: {_name} не настроен префаб {tag}");
        }
    }
}

public enum TagPrefab
{
    Platform,
    RightWall,
    LeftWall,
    Background,
    Floore,
    Abyss
}

[Serializable]
public class SettingPrefab
{
    [SerializeField] private TagPrefab _tag;
    [SerializeField] private GameObject _prefab;

    public TagPrefab Tag => _tag;
    public GameObject Prafab => _prefab;
}