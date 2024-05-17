using Scripts.Components.UI.Widgets;
using Scripts.Modeles.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components.Additions
{
    public class MapTrader : Trader<Map>
    {
        [SerializeField] private string _nameSave = NameFileSave.Map.ToString();

        public override void OnBuy()
        {
            Buy(Ware);
        }

        public void Save()
        {
            PlayerPrefs.SetString(_nameSave.ToString(), Ware.ID);
            PlayerPrefs.Save();
        }
    }
}
