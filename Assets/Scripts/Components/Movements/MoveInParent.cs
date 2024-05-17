using UnityEngine;

namespace Scripts.Components.Movements
{
    public class MoveInParent : Move
    {
        [SerializeField] private Transform _parent;

        protected override void Awake()
        {
            base.Awake();
            RandomDirection();
            TargetForMove = transform;
        }

        protected override void Movement()
        {
            TargetForMove.position += new Vector3(MultipliDeltaTime(Velocity), 0, 0);
        }

        public void MoveInZeroPosition()
        {
            if(TargetForMove!= null) TargetForMove.position = _parent.position;
        }
    }
}