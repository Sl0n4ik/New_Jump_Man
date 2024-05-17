using Scripts.Components.Animation;
using Scripts.Helpers;
using Scripts.Modeles.Definitions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components.UI.Widgets
{
    [RequireComponent(typeof(ImageAnimation))]
    public class LoaderChest : MonoBehaviour
    {
        [SerializeField] private SkinDifenition _skinDef;

        private ImageAnimation _animation;
        private Rare _currentRare;

        private List<Skin> _list = new List<Skin>();

        private void Awake()
        {
            _animation = GetComponent<ImageAnimation>();
        }

        public void Load(RareSetting rareSetting)
        {
            _currentRare = rareSetting.Rare;
            var count = _skinDef.GetElements(_list, x => !x.IsPurchased && x.Rare == _currentRare);
            _animation.gameObject.SetActive(count > 0);

            foreach (var animation in rareSetting.Animations)
            {
                foreach (var clip in _animation.Clips)
                {
                    if (animation.NameAnimation == clip.Name)
                    {
                        clip.Sprites = animation.Sprites;
                    }
                }
            }
            _animation.ResetAnimation();
        }
    }
}