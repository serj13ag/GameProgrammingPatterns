using System;
using PatternsExamples.Behavioral.State.Scripts.PlayerStates;
using UnityEngine;

namespace PatternsExamples.Behavioral.State.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _runningSpeed;
        [SerializeField] private float _timeTillGoRunning;

        private IPlayerState _currentPlayerState;

        public float MovingSpeed => _movingSpeed;
        public float RunningSpeed => _runningSpeed;

        public Vector3 MoveTarget { get; private set; }

        private void Start()
        {
            SetState(PlayerState.Standing);
        }

        private void Update()
        {
            _currentPlayerState.Update(Time.deltaTime);
        }

        public void MoveTo(Vector3 position)
        {
            MoveTarget = position;

            if (_currentPlayerState.Type == PlayerState.Standing)
            {
                SetState(PlayerState.Walking);
            }
        }

        public void SetState(PlayerState newPlayerStateType)
        {
            if (_currentPlayerState?.Type == newPlayerStateType)
            {
                return;
            }

            IPlayerState newPlayerState = newPlayerStateType switch
            {
                PlayerState.Standing => new StandingState(this),
                PlayerState.Walking => new WalkMovingPlayerState(this, _timeTillGoRunning),
                PlayerState.Running => new RunMovingPlayerState(this),
                _ => throw new ArgumentOutOfRangeException(nameof(newPlayerStateType), newPlayerStateType, null),
            };

            _currentPlayerState = newPlayerState;
        }
    }
}