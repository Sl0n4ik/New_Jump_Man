using Scripts.Components.UI.Widgets;
using Scripts.Modeles;
using Scripts.Modeles.Property;
using UnityEngine;

namespace Scripts.Components.Movements
{
    public class MoveInPosition : Move
    {
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private int _valueForBackMove;
        [SerializeField] private TagItem _tag = TagItem.Point;

        private ObservableProperty<int> _valuePoint;
        private float _deltaPosition;
        private int _carrentPoint;
        private bool _isUp;

        protected override void Awake()
        {
            base.Awake();
            TargetForMove = transform;
            _valuePoint = FindObjectOfType<GameSession>().GetValueItem(_tag);
            _valuePoint.OnChange += BackMove;
            _deltaPosition = _targetPosition.position.y - TargetForMove.position.y;
        }

        protected override void Movement()
        {
            if (TargetForMove.position.y > _targetPosition.position.y && Direction > 0)
            {
                Direction = 0;
                TargetForMove.position = new Vector3(TargetForMove.position.x, _targetPosition.position.y, TargetForMove.position.z);
            }
            else if (Direction < 0 && TargetForMove.position.y <= _targetPosition.position.y - _deltaPosition)
            {
                Direction = 0;
                TargetForMove.position = new Vector3(TargetForMove.position.x, _targetPosition.position.y - _deltaPosition, TargetForMove.position.z);
            }
            TargetForMove.position += new Vector3(0, MultipliDeltaTime(Velocity), 0);
        }

        public void StartMove()
        {
            _carrentPoint = _valuePoint.Value;
            _isUp = true;
            Direction = 1;
        }

        private void BackMove(int point)
        {
            if (point >= _carrentPoint + _valueForBackMove && _isUp)
            {
                _isUp = false;
                Direction = -1;
            }
        }
    }
}