namespace PatternsExamples.Behavioral.State.Scripts.PlayerStates
{
    public class StandingState : IPlayerState
    {
        private readonly Player _player;

        public PlayerState Type => PlayerState.Standing;

        public StandingState(Player player)
        {
            _player = player;
        }

        public void Update(float deltaTime)
        {
        }
    }
}