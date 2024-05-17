using Scripts.Components.UI.Widgets;
using Scripts.Modeles.Property;
using UnityEngine;

namespace Scripts.Modeles
{
    public class ScorePoints : MonoBehaviour
    {
        [SerializeField] private int _multiplerPoints = 2;
        private Transform _transform;
        private GameSession _session;
        private ObservableProperty<int> _points;

        private float _firstPosition;
        private float _oldPosition;

        private float CurrentPosition => _transform.position.y;

        private void Awake()
        {
            _transform = transform;
            _firstPosition = CurrentPosition;
            _session = FindObjectOfType<GameSession>();
            _points = _session.GetValueItem(TagItem.Point);
        }

        private void Update()
        {
            if (CurrentPosition > _oldPosition)
            {
                _oldPosition = CurrentPosition;
                _points.Value = (int)((_oldPosition - _firstPosition)* _multiplerPoints);
            }
        }
    }
}