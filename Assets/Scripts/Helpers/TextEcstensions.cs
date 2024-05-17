using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Helpers
{
    public static class TextEcstensions
    {
        public static void UpdateSize(this Text text,string newText)
        {
            text.text = newText;
            var rectTransform = text.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(text.preferredWidth + text.lineSpacing, text.preferredHeight +text.lineSpacing);
        }
    }
}
