using Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components.Animation
{
    [RequireComponent(typeof(Image))]
    public class ImageAnimation : BaseAnimation<Image>
    {
        [SerializeField] private SimilarityMode _mode;

        private RectTransform _transform;

        public SimilarityMode Mode => _mode;

        protected override void Awake()
        {
            base.Awake();
            _transform = TargetRenderer.rectTransform;
        }

        protected override void SetSprite()
        {
            TargetRenderer.SetSprite(CurrentClip.Sprites[CurrentFrame], _transform, _mode);
        }
    }
}