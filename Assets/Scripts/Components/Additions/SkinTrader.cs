using Scripts.Helpers;
using Scripts.Modeles.Definitions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components.Additions
{
    public class SkinTrader : Trader<Skin>
    {
        [SerializeField] private Image _image;

        private Rare _rare;
        private List<Skin> _list = new();

        public override void OnBuy()
        {
            var count = Definition.GetElements(_list, x => !x.IsPurchased && x.Rare == _rare);
            var randomIndex = Random.Range(0, count);
            var ware = _list[randomIndex];
            Buy(ware);
            _image.SetSprite(_list[randomIndex].SpriteForUI, _image.rectTransform, SimilarityMode.Vertical);
        }

        public void SetRare(RareSetting rareSetting)
        {
            _rare = rareSetting.Rare;
            Price.UpdateSize(((int)_rare).ToString());
        }
    }
}
