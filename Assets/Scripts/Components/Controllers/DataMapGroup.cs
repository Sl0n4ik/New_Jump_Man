using Scripts.Components.UI.Widgets;
using Scripts.Helpers;
using Scripts.Modeles.Definitions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.Components.Controllers
{
    public class DataMapGroup : BaseDataGroup<Map, MapDefinition, MapItem>
    {
        [SerializeField] private Image _image;
        private RectTransform _transform;

        private void Awake()
        {
            _transform = _image.GetComponent<RectTransform>();
        }

        protected override bool Condition(Map value)
        {
            return true;
        }

        protected override void OnCompleteUpdate()
        {
            SetSelect(GetSkinItem(SelectValue));
        }

        public override void SetSelect(MapItem item)
        {
            base.SetSelect(item);
            _image.SetSprite(item.ValueItem.SpriteForUI, _transform, SimilarityMode.Vertical);
        }

        protected override void OnUpdateGroup()
        {
            Updater();
        }
    }
}
