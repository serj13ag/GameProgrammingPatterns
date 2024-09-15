using UnityEngine;

namespace PatternsExamples.Behavioral.Command.Scripts
{
    public interface IMovableActor
    {
        void Move(Vector3 direction);
    }

    public class MovableActor : MonoBehaviour, IMovableActor
    {
        [SerializeField] private float _moveDistance;

        public void Move(Vector3 direction)
        {
            transform.position += direction * _moveDistance;
        }
    }
}