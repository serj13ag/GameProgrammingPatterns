namespace PatternsExamples.Behavioral.State.Scripts.PlayerStates
{
    public class MovingPlayerState : BaseMotionPlayerState
    {
        private readonly Player _player;
        private float _timeTillGoRunning;

        public override PlayerState Type => PlayerState.Moving;

        public MovingPlayerState(Player player, float timeTillGoRunning) : base(player)
        {
            _player = player;
            _timeTillGoRunning = timeTillGoRunning;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (_timeTillGoRunning > 0f)
            {
                _timeTillGoRunning -= deltaTime;
            }
            else
            {
                _player.SetState(PlayerState.Running);
            }
        }

        protected override float GetMotionSpeed()
        {
            return _player.MovingSpeed;
        }
    }
}