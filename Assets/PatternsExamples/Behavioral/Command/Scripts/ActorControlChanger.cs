using UnityEngine;

namespace PatternsExamples.Behavioral.Command.Scripts
{
    public class ActorControlChanger : MonoBehaviour
    {
        [SerializeField] private CommandExecutor _commandExecutor;
        [SerializeField] private MovableActor[] _movableActors;

        private int _controlledActorIndex;
        private IMovableActor _controlledActor;

        public IMovableActor ControlledActor => _controlledActor;

        private void Awake()
        {
            SetControlledActor(_movableActors[0]);
        }

        private void Update()
        {
            if (InputHandler.HasChangeControlledActorInput(this, out var command))
            {
                _commandExecutor.Execute(command);
            }
        }

        public void SetControlledActor(IMovableActor movableActor)
        {
            _controlledActor = movableActor;
        }

        public IMovableActor GetNextControlledActor()
        {
            for (var i = 0; i < _movableActors.Length; i++)
            {
                if (ReferenceEquals(_movableActors[i], _controlledActor))
                {
                    return i == _movableActors.Length - 1 ? _movableActors[0] : _movableActors[i + 1];
                }
            }

            return null;
        }
    }
}