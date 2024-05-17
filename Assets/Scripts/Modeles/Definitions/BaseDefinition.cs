using Scripts.Interfeices;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Modeles.Definitions
{
    public class BaseDefinition<T> : ScriptableObject where T : IWare<string>
    {

        [SerializeField] private T[] _elements;
        [SerializeField] protected string _nameBaseElement;

        public T[] Elements => _elements;

        internal object GetElements(object list, Func<Skin, bool> p)
        {
            throw new NotImplementedException();
        }

        public T GetBaseElement()
        {
            return GetElement(_nameBaseElement);
        }

        public T GetElement(string nameElement)
        {
            foreach (var element in _elements)
            {
                if (element.ID == nameElement)
                {
                    return element;
                }
            }
            throw new Exception($"нет скина с именем {nameElement}");
        }

        public int GetElements(in List<T> list, Func<T, bool> func)
        {
            int i = 0;

            foreach (var element in _elements)
            {
                if (func.Invoke(element))
                {
                    if (i < list.Count)
                    {
                        list[i] = element;
                    }
                    else
                    {
                        list.Add(element);
                    }
                    i++;
                }
            }

            return i;
        }
    }
}