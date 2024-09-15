using UnityEngine;

namespace PatternsExamples.Behavioral.Command.Scripts.Commands
{
    public class MoveActorCommand : ICommand
    {
        private readonly IMovableActor _movableActor;
        private readonly Vector3 _direction;

        public MoveActorCommand(IMovableActor movableActor, Vector3 direction)
        {
            _movableActor = movableActor;
            _direction = direction;
        }

        public void Execute()
        {
            _movableActor.Move(_direction);
        }

        public void Undo()
        {
            _movableActor.Move(-_direction);
        }
    }
}