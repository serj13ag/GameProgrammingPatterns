using UnityEngine;

namespace PatternsExamples.Behavioral.State.Scripts
{
    public class PlayerMover : MonoBehaviour
    {
        private const float RaycastDistance = 100f;

        [SerializeField] private Camera _camera;
        [SerializeField] private MeshCollider _walkPlaneCollider;
        [SerializeField] private Player _player;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (_walkPlaneCollider.Raycast(ray, out var hitInfo, RaycastDistance))
                {
                    _player.MoveTo(hitInfo.point);
                }
            }
        }
    }
}