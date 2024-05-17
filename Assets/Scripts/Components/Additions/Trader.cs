using Scripts.Components.UI.Widgets;
using Scripts.Helpers;
using Scripts.Interfeices;
using Scripts.Modeles.Definitions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.Components.Additions
{
    public abstract class Trader<T> : MonoBehaviour where T:IWare<string>
    {
        [SerializeField] private UnityEvent _event;
        [SerializeField] protected BaseDefinition<T> Definition;
        [SerializeField] protected Text Price;

        protected T Ware;
        private GameObject go;

        private void Awake()
        {
            go = gameObject;
        }

        protected void Buy(T ware)
        {
            var coin = TagItem.Coin.ToString();
            var many = PlayerPrefs.GetInt(coin);
            if (many >= ware.Price)
            {
                PlayerPrefs.SetInt(coin, many - ware.Price);
                ware.IsPurchased = true;
                PlayerPrefs.Save();
                _event?.Invoke();
            }
        }

        public void SetWare(T ware)
        {
            go.SetActive(!ware.IsPurchased);
            Price.UpdateSize(ware.Price.ToString());
            Ware = ware;
        }

        public abstract void OnBuy();
    }
}
