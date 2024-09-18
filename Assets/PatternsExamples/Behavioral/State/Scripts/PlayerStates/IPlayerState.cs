namespace PatternsExamples.Behavioral.State.Scripts.PlayerStates
{
    public interface IPlayerState
    {
        PlayerState Type { get; }

        void Update(float deltaTime);
    }
}