using UnityEngine;

namespace PatternsExamples.Behavioral.State.Scripts.PlayerStates
{
    public abstract class BaseMovingPlayerState : IPlayerState
    {
        private const float MinimumDistanceToReachTarget = 0.1f;

        private readonly Player _player;

        public abstract PlayerState Type { get; }

        protected BaseMovingPlayerState(Player player)
        {
            _player = player;
        }

        public virtual void Update(float deltaTime)
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
        }

        protected abstract float GetMotionSpeed();

        private void MoveTowardsTarget(float deltaTime, Vector3 playerPosition)
        {
            _player.transform.position = Vector3.MoveTowards(playerPosition, _player.MoveTarget, GetMotionSpeed() * deltaTime);
        }

        private bool FarFromTarget(Vector3 playerPosition)
        {
            return Vector3.Distance(playerPosition, _player.MoveTarget) > MinimumDistanceToReachTarget;
        }
    }
}