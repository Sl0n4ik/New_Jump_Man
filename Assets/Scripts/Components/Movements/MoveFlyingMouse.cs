using UnityEngine;

namespace Scripts.Components.Movements
{
    public class MoveFlyingMouse : Move
    {
        [SerializeField] private float _frequency;
        [SerializeField] [Range(0, 1f)] private float _amplitude;

        private float _currentDegree;

        protected override void Awake()
        {
            base.Awake();
            RandomDirection();
            TargetForMove = transform;
        }

        protected override void Movement()
        {
            var deltaX = MultipliDeltaTime(Velocity);
            var deltaY = Mathf.Sin(_currentDegree) * _amplitude;

            _currentDegree += MultipliDeltaTime(_frequency);
            if (_currentDegree >= Mathf.PI * 2)
            {
                _currentDegree -= Mathf.PI * 2;
            }

            TargetForMove.position += new Vector3(deltaX, deltaY, 0);
        }
    }
}