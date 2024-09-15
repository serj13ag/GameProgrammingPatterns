using UnityEngine;

namespace PatternsExamples.Behavioral.Observer.Scripts
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private SubjectTower[] _observableTowers;

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
            SpawnProjectile(e.Position, e.Direction, e.ProjectileSpeed);
        }

        private void SpawnProjectile(Vector3 position, Vector3 direction, float speed)
        {
            var projectile = Instantiate(_projectilePrefab, position, Quaternion.identity);
            projectile.Init(direction, speed);
        }
    }
}