using Scripts.Components.Animation;
using Scripts.Components.UI.Widgets;
using Scripts.Helpers;
using Scripts.Modeles.Definitions;
using UnityEngine;

namespace Scripts.Components.Controllers
{
    [RequireComponent(typeof(SpriteAnimation))]
    public class LoaderSkin : MonoBehaviour
    {
        [SerializeField] private SkinDifenition _skinDef;

        private SpriteAnimation _animation;

        private Skin Skin
        {
            set
            {
                foreach(var clip in _animation.Clips)
                {
                    foreach(var animation in value.Animations)
                    {
                        if(clip.Name == animation.NameAnimation)
                        {
                            clip.Sprites = animation.Sprites;
                        }
                    }
                }
                _animation.ResetAnimation();
            }
        }

        private void Awake()
        {
            _animation = GetComponent<SpriteAnimation>();

            if (PlayerPrefs.HasKey(NameFileSave.Skin.ToString()))
            {
                var nameSkin = PlayerPrefs.GetString(NameFileSave.Skin.ToString());
                Skin = _skinDef.GetElement(nameSkin);
            }
            else
            {
                Skin = _skinDef.GetBaseElement();
            }
        }
    }
}