namespace PatternsExamples.Behavioral.Command.Scripts.Commands
{
    public class ChangeControlledActorCommand : ICommand
    {
        private readonly ActorControlChanger _actorControlChanger;

        private IMovableActor _previousControlledActor;

        public ChangeControlledActorCommand(ActorControlChanger actorControlChanger)
        {
            _actorControlChanger = actorControlChanger;
        }

        public void Execute()
        {
            _previousControlledActor = _actorControlChanger.ControlledActor;

            var nextControlledActor = _actorControlChanger.GetNextControlledActor();
            _actorControlChanger.SetControlledActor(nextControlledActor);
        }

        public void Undo()
        {
            _actorControlChanger.SetControlledActor(_previousControlledActor);
        }
    }
}