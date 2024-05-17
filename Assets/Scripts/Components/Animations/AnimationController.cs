using Scripts.Components.Movements;
using UnityEngine;

namespace Scripts.Components.Animation
{
    [RequireComponent(typeof(SpriteAnimation), typeof(Movement), typeof(Collider2D))]
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private string _keyJump;

        private SpriteAnimation _animations;
        private Collider2D _collider;
        private Transform _transform;
        private Movement _move;

        private void Awake()
        {
            _transform = transform;
            _animations = GetComponent<SpriteAnimation>();
            _collider = GetComponent<Collider2D>();
            _move = GetComponent<Movement>();
            _move.OnJump += SetAnimation;
            _move.On—hangeDirection += SetRotate;
        }

        private void SetRotate(int direction)
        {
            if (direction != 0)
            {
                _transform.localScale = new Vector3(direction, _transform.localScale.y, _transform.localScale.z);
            }
        }

        private void OnDestroy()
        {
            _move.OnJump -= SetAnimation;
            _move.On—hangeDirection -= SetRotate;
        }

        private void SetAnimation(bool isJump)
        {
            _collider.enabled = !isJump;
            if (isJump)
            {
                _animations.SetClip(_keyJump);
            }
        }
    }
}