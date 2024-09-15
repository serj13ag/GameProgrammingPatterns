using UnityEngine;

namespace PatternsExamples.Behavioral.Command.Scripts
{
    public class ActorControlOrchestrator : MonoBehaviour
    {
        [SerializeField] private MovableActor[] _movableActors;

        private int _controlledActorIndex;
        private IMovableActor _controlledActor;

        public IMovableActor ControlledActor => _controlledActor;

        private void Awake()
        {
            SetControlledActor(0);
        }

        private void Update()
        {
            if (InputHandler.HasChangeActorInput())
            {
                ChangeControlledActor();
            }
        }

        private void ChangeControlledActor()
        {
            var nextActorIndex = _controlledActorIndex + 1;
            if (nextActorIndex > _movableActors.Length - 1)
            {
                nextActorIndex = 0;
            }

            SetControlledActor(nextActorIndex);
        }

        private void SetControlledActor(int actorIndex)
        {
            _controlledActorIndex = actorIndex;
            _controlledActor = _movableActors[actorIndex];
        }
    }
}