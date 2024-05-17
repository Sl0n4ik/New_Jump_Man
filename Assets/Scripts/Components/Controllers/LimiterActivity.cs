using Scripts.Components.UI.Widgets;
using Scripts.Modeles;
using Scripts.Modeles.Property;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Controllers
{
    public class LimiterActivity : MonoBehaviour
    {
        [SerializeField] private int _valueLimite;
        [SerializeField] private UnityEvent _onActivity;

        private ObservableProperty<int> _valuePoint;

        private void Awake()
        {
            _valuePoint = FindObjectOfType<GameSession>().GetValueItem(TagItem.Point);
            _valuePoint.OnChange += TryActive;
        }

        private void TryActive(int point)
        {
            if (point >= _valueLimite)
            {
                _onActivity?.Invoke();
            }
        }
    }
}