namespace PatternsExamples.Behavioral.State.Scripts.PlayerStates
{
    public class RunningState : BaseMotionPlayerState
    {
        private readonly Player _player;

        public override PlayerState Type => PlayerState.Running;

        public RunningState(Player player) : base(player)
        {
            _player = player;
        }

        protected override float GetMotionSpeed()
        {
            return _player.RunningSpeed;
        }
    }
}