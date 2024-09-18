using UnityEngine;

namespace PatternsExamples.Behavioral.State.Scripts.PlayerStates
{
    public class MovingPlayerState : IPlayerState
    {
        private const float MinimumDistanceToReachTarget = 0.1f;

        private readonly Player _player;

        private float _timeTillGoRunning;

        public PlayerState Type => PlayerState.Moving;

        public MovingPlayerState(Player player, float timeTillGoRunning)
        {
            _player = player;
            _timeTillGoRunning = timeTillGoRunning;
        }

        public void Update(float deltaTime)
        {
            var playerPosition = _player.transform.position;

            if (FarFromTarget(playerPosition))
            {
                MoveTowardsTarget(deltaTime, playerPosition);
            }
            else
            {
                _player.SetState(PlayerState.Standing);
            }

            if (_timeTillGoRunning > 0f)
            {
                _timeTillGoRunning -= deltaTime;
            }
            else
            {
                _player.SetState(PlayerState.Running);
            }
        }

        private void MoveTowardsTarget(float deltaTime, Vector3 playerPosition)
        {
            _player.transform.position = Vector3.MoveTowards(playerPosition, _player.MoveTarget, _player.MovingSpeed * deltaTime);
        }

        private bool FarFromTarget(Vector3 playerPosition)
        {
            return Vector3.Distance(playerPosition, _player.MoveTarget) > MinimumDistanceToReachTarget;
        }
    }
}