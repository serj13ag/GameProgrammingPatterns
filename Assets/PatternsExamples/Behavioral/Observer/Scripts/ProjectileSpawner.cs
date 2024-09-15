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
            var projectile = Instantiate(_projectilePrefab, e.Position, Quaternion.identity);
            projectile.Init(e.Direction, e.ProjectileSpeed);
        }
    }
}