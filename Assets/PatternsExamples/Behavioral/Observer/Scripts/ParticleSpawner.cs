using UnityEngine;

namespace PatternsExamples.Behavioral.Observer.Scripts
{
    public class ParticleSpawner : MonoBehaviour
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
            Instantiate(_shootParticles, e.Position, Quaternion.identity);
        }
    }
}