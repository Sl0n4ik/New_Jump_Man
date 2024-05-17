using System;
using UnityEngine;

namespace Scripts.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TagAttribute : PropertyAttribute { }
}