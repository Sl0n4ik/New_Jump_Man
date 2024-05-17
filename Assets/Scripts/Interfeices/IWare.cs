using UnityEngine;

namespace Scripts.Interfeices
{
    public interface IWare<T_ID>
    {
        T_ID ID { get; }
        Sprite SpriteForUI { get; }
        int Price { get; }
        bool IsPurchased { get; set; }
    }
}