using System;
using UnityEngine;

namespace Scripts.Modeles.Property
{
    [Serializable]
    public class ObservableProperty<T>
    {
        [SerializeField] private T _value;

        public event Action<T> OnChange;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChange?.Invoke(_value);
            }
        }
    }
}