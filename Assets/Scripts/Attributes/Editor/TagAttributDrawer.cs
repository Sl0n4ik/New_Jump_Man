using UnityEditor;
using UnityEngine;

namespace Scripts.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(TagAttribute))]

    public class TagAttributDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }
    }
}