using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

namespace Scripts.Helpers.Editor
{
    public static class SearcherInResorces
    {
        public static List<string> FindPathesAll<T>() where T : Object
        {
            var objects = Resources.LoadAll<T>("");
            var pathes = new List<string>();
            foreach (var obj in objects)
            {
                string possiblePath = EditorResources.GetAssetPath(obj);
                if (possiblePath.Contains("Assets/Resources/"))
                {
                    pathes.Add(possiblePath.Split("Resources/")[^1].Split('.')[0]);
                }
            }
            return pathes;
        }
    }
}