using Scripts.Helpers.Editor;
using UnityEditor;
using UnityEngine;

namespace Scripts.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(PathesInResourcesAttribute))]
    public class PathInResuorcesAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var validPath = SearcherInResorces.FindPathesAll<UnityEngine.Object>();

            var index = Mathf.Max(validPath.IndexOf(property.stringValue), 0);
            index = EditorGUI.Popup(position, property.displayName, index, validPath.ToArray());
            property.stringValue = validPath[index];
        }
    }
}