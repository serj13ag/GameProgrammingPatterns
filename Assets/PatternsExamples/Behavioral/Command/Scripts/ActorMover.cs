using UnityEngine;

namespace PatternsExamples.Behavioral.Command.Scripts
{
    public class ActorMover : MonoBehaviour
    {
        [SerializeField] private CommandExecutor _commandExecutor;
        [SerializeField] private ActorControlChanger _actorControlChanger;

        private void Update()
        {
            var controlledActor = _actorControlChanger.ControlledActor;
            if (InputHandler.HasMoveActorInput(controlledActor, out var command))
            {
                _commandExecutor.Execute(command);
            }
        }
    }
}