using Scripts.Components.UI.Widgets;
using Scripts.Helpers;
using Scripts.Modeles;
using Scripts.Modeles.Property;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Movements
{
    public class MoveUpDawn : Move
    {
        [SerializeField] private TargetPoint[] _targets;

        private float _timeSwitch;
        private int _currentIndex;
        private ObservableProperty<int> _valuePoints;
        private float _remaningTime;

        private float _currentTargetPosition => _targets[_currentIndex].Position.y;
        private float Distance => _currentTargetPosition - TargetForMove.position.y;

        protected override void Awake()
        {
            base.Awake();
            TargetForMove = transform;
            _valuePoints = FindObjectOfType<GameSession>().GetValueItem(TagItem.Point);
            Switch();
        }

        protected override void Movement()
        {
            if (Direction * Distance < 0)
            {
                Direction = 0;
            }
            if (Time.time > _timeSwitch) Switch();
            TargetForMove.position += new Vector3(0, MultipliDeltaTime(Velocity), 0);
        }

        private void Switch()
        {
            _currentIndex = (int)Mathf.Repeat(++_currentIndex, _targets.Length);
            Direction = Distance.InUnit();
            _timeSwitch = Time.time + _targets[_currentIndex].GetTimeByComplexcity(_valuePoints.Value);
        }

        protected override void OnPause(bool isPause)
        {
            base.OnPause(isPause);
            if (!isPause)
            {
                _targets[_currentIndex].GetTimeByComplexcity(_valuePoints.Value);
                _timeSwitch = Time.time + _remaningTime;
            }
            else
            {
                _remaningTime = _timeSwitch - Time.time;
            }
        }

        [Serializable]
        private class TargetPoint
        {
            [SerializeField] private Transform _point;
            [SerializeField] private float _minTime;
            [SerializeField] private float _maxTime;
            [SerializeField] private float _multiplierComplexcity;
            [SerializeField] private UnityEvent _onMove;

            public Vector3 Position => _point.position;

            public float Time
            {
                get
                {
                    _onMove?.Invoke();
                    return UnityEngine.Random.Range(_minTime, _maxTime);
                }
            }

            public float GetTimeByComplexcity(int points)
            {
                return Time + points * _multiplierComplexcity;
            }
        }
    }
}