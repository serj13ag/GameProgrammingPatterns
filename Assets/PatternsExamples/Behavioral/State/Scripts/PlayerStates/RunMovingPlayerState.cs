using UnityEngine;

namespace PatternsExamples.Behavioral.State.Scripts.PlayerStates
{
    public class RunMovingPlayerState : BaseMovingPlayerState
    {
        private readonly Player _player;

        public override PlayerState Type => PlayerState.Running;

        public RunMovingPlayerState(Player player) : base(player)
        {
            _player = player;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.SetState(PlayerState.Walking);
            }
        }

        protected override float GetMotionSpeed()
        {
            return _player.RunningSpeed;
        }
    }
}