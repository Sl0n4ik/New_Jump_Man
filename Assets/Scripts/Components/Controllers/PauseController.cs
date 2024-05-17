using Scripts.Components.Input;
using UnityEngine;

namespace Scripts.Components.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PauseController : MonoBehaviour
    {
        private InputReader _input;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
            _input.OnPauseKey += OnPause;

            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnDestroy()
        {
            _input.OnPauseKey -= OnPause;
        }

        private void OnPause(bool isPause)
        {
            _rigidbody.simulated = !isPause;
        }
    }
}