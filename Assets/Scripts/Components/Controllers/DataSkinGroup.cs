using Scripts.Components.UI.Widgets;
using Scripts.Modeles.Definitions;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Controllers
{
    public class DataSkinGroup : BaseDataGroup<Skin, SkinDifenition, SkinItem>
    {
        [SerializeField] private UnityEvent<RareSetting> _onUpdate;
        private RareSetting _currentSettingRare;

        public void UpdateGroup(Rare rare)
        {
            _currentSettingRare = Definition.GetRareSetting(rare);
            Updater();
        }

        protected override void SetSkinInItem(DefinitionItemWidget<Skin> item, Skin skin)
        {
            base.SetSkinInItem(item, skin);
            item.ColorBox = _currentSettingRare.Color;
        }

        protected override void OnUpdateGroup()
        {
            UpdateGroup(SelectValue.Rare);
        }

        protected override void OnCompleteUpdate()
        {
            if (SelectValue?.Rare == _currentSettingRare.Rare)
            {
                SetSelect(GetSkinItem(SelectValue));
            }

            _onUpdate?.Invoke(_currentSettingRare);
        }

        protected override bool Condition(Skin value)
        {
            return value.Rare == _currentSettingRare.Rare;
        }
    }
}