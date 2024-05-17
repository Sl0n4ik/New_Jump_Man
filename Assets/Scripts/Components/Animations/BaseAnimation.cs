using Scripts.Components.Input;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Animation
{
    public abstract class BaseAnimation<TRenderer> : MonoBehaviour where TRenderer : Component
    {
        [SerializeField] [Range(1, 30)] private int _frameRate = 10;
        [SerializeField] private AnimationClip[] _clips;

        protected TRenderer TargetRenderer;
        protected int CurrentFrame;

        private float _secondsPerFrame;
        private float _nextFrameTime;
        private int _indexCurrentClip;
        private InputReader _input;

        public AnimationClip[] Clips => _clips;
        public TRenderer Renderer => TargetRenderer;

        protected AnimationClip CurrentClip => _clips[_indexCurrentClip];

        protected abstract void SetSprite();

        protected virtual void Awake()
        {
            _input = FindObjectOfType<InputReader>();
            if(_input != null) _input.OnPauseKey += OnPause;

            TargetRenderer = GetComponent<TRenderer>();
            _secondsPerFrame = 1f / _frameRate;
            StartAnimation();
        }

        private void OnDestroy()
        {
            if (_input != null) _input.OnPauseKey -= OnPause;
        }

        private void OnPause(bool isPause)
        {
            enabled = !isPause;
        }

        private void OnEnable()
        {
            _nextFrameTime = Time.time;
        }

        private void Update()
        {
            if (_nextFrameTime > Time.time) return;

            if (CurrentFrame >= CurrentClip.Sprites.Length)
            {
                if (CurrentClip.IsLoop)
                {
                    CurrentFrame = 0;
                }
                CurrentClip.OnComplete?.Invoke();
                enabled = CurrentClip.IsLoop;
            }

            if (CurrentFrame < CurrentClip.Sprites.Length)
            {
                SetSprite();
                _nextFrameTime += _secondsPerFrame;
                CurrentFrame++;
            }
        }

        public void SetClip(string clipName)
        {
            for (var i = 0; i < _clips.Length; i++)
            {
                if (_clips[i].Name == clipName)
                {
                    _indexCurrentClip = i;
                    StartAnimation();
                    return;
                }
            }
            throw new Exception($"клипа с именем: {clipName} нет");
        }

        public void ResetAnimation()
        {
            _indexCurrentClip = 0;
            StartAnimation();
        }

        public void SetSpritesInClip(string nameClip, Sprite[] sprites)
        {
            foreach (var clip in _clips)
            {
                if (clip.Name == nameClip)
                {
                    clip.Sprites = sprites;
                }
            }
        }

        private void StartAnimation()
        {
            _nextFrameTime = Time.time;
            CurrentFrame = 0;
            enabled = true;
        }
    }

    [Serializable]
    public class AnimationClip
    {
        [SerializeField] private string _name;
        [SerializeField] private bool _isLoop;
        [SerializeField] private UnityEvent _onComplete;

        public Sprite[] Sprites;

        public string Name => _name;
        public UnityEvent OnComplete => _onComplete;
        public bool IsLoop => _isLoop;
    }
}