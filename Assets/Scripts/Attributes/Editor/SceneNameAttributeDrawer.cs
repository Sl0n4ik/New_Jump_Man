using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Scripts.Attributes.Editor
{
    [CustomPropertyDrawer(typeof(SceneNameAttribute))]
    public class SceneNameAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var pathes = EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes);
            var names = new List<string>();

            foreach (string path in pathes)
            {
                var prs = path.Split('/','.');
                names.Add(prs[^2]);
            }

            var index = Mathf.Max(names.IndexOf(property.stringValue), 0);
            index = EditorGUI.Popup(position, property.displayName, index, names.ToArray());
            property.stringValue = names[index];
        }
    }
}