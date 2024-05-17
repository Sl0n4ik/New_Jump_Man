using Scripts.Components.Input;
using UnityEngine;

namespace Scripts.Components.Movements
{
    public abstract class Move : MonoBehaviour
    {
        [SerializeField] private float Speed;

        protected int Direction;
        protected Transform TargetForMove;
        private InputReader _input;

        protected float Velocity => Speed * Direction;

        protected virtual void Awake()
        {
            _input = FindObjectOfType<InputReader>();
            _input.OnPauseKey += OnPause;
        }

        private void OnDestroy()
        {
            _input.OnPauseKey -= OnPause;
        }

        protected virtual void OnPause(bool isPause)
        {
            enabled = !isPause;
        }

        protected void RandomDirection()
        {
            while (Direction == 0)
            {
                Direction = Random.Range(-1, 2);
            }
        }

        private void FixedUpdate()
        {
            Movement();
        }

        public void SwitchDirection()
        {
            Direction *= -1;
        }

        protected abstract void Movement();

        protected float MultipliDeltaTime(float value)
        {
            return value * Time.fixedDeltaTime;
        }
    }
}