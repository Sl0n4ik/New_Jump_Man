using UnityEngine;

namespace Scripts.Components.Spawners
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _target;

        private Transform _transform;


        private void Awake()
        {
            _transform = transform;
        }

        public void Spawn()
        {
            _target.transform.position = _transform.position;
            _target.gameObject.SetActive(true);
            _target.simulated = true;
            _target.velocity = Vector2.zero;

        }
    }
}