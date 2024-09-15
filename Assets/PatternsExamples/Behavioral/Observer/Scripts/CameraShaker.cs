using UnityEngine;

namespace PatternsExamples.Behavioral.Observer.Scripts
{
    public class CameraShaker : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _shakeAmount;
        [SerializeField] private SubjectTower[] _observableTowers;

        private Vector3 _initialPosition;

        private void Awake()
        {
            _initialPosition = _camera.transform.position;
        }

        private void OnEnable()
        {
            foreach (var observableTower in _observableTowers)
            {
                observableTower.OnShoot += TowerOnShoot;
            }
        }

        private void OnDisable()
        {
            foreach (var observableTower in _observableTowers)
            {
                observableTower.OnShoot -= TowerOnShoot;
            }
        }

        private void TowerOnShoot(object sender, TowerShootEventArgs e)
        {
            ShakeCamera();
        }

        private void ShakeCamera()
        {
            var shakeAmount = Random.Range(-_shakeAmount, _shakeAmount);

            _camera.transform.position = new Vector3(
                shakeAmount + _initialPosition.x,
                shakeAmount + _initialPosition.y,
                shakeAmount + _initialPosition.z);
        }
    }
}