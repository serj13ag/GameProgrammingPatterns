using UnityEngine;

namespace PatternsExamples.Behavioral.Observer.Scripts
{
    public class ParticleSpawnerObserver : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _shootParticles;
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
            SpawnParticle(e.Position);
        }

        private void SpawnParticle(Vector3 position)
        {
            Instantiate(_shootParticles, position, Quaternion.identity);
        }
    }
}