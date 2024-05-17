using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Helpers
{
    public static class ImageEcstensions
    {
        public static void SetSprite(this Image image, Sprite sprite, RectTransform transform, SimilarityMode mode)
        {
            var size = transform.sizeDelta;
            size.RelativeSimilarity(sprite.textureRect.size, mode);
            transform.sizeDelta = size;
            image.sprite = sprite;
        }
    }
}