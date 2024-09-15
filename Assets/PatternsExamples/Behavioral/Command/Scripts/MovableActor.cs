using UnityEngine;

namespace PatternsExamples.Behavioral.Command.Scripts
{
    public interface IMovableActor
    {
        void Move(Vector3 direction);
        void SetControl(bool isControlled);
    }

    public class MovableActor : MonoBehaviour, IMovableActor
    {
        [SerializeField] private GameObject _controlIndicator;
        [SerializeField] private float _moveDistance;

        public void Move(Vector3 direction)
        {
            transform.position += direction * _moveDistance;
        }

        public void SetControl(bool isControlled)
        {
            _controlIndicator.gameObject.SetActive(isControlled);
        }
    }
}