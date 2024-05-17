using UnityEngine;

namespace Scripts.Components.Animation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : BaseAnimation<SpriteRenderer>
    {
        protected override void SetSprite()
        {
            TargetRenderer.sprite = CurrentClip.Sprites[CurrentFrame];
        }
    }
}
