using System;
using UnityEngine;

namespace PatternsExamples.Behavioral.Observer.Scripts
{
    public class SubjectTower : MonoBehaviour
    {
        [SerializeField] private Transform _projectileAnchor;
        [SerializeField] private float _shootCooldown;
        [SerializeField] private float _projectileSpeed;

        private float _timeTillShoot;

        public event EventHandler<TowerShootEventArgs> OnShoot;

        private void Start()
        {
            ResetShootTimer();
        }

        private void Update()
        {
            _timeTillShoot -= Time.deltaTime;
            if (_timeTillShoot <= 0f)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            ResetShootTimer();

            OnShoot?.Invoke(this, new TowerShootEventArgs(_projectileAnchor.transform.position, Vector3.up, _projectileSpeed));
        }

        private void ResetShootTimer()
        {
            _timeTillShoot = _shootCooldown;
        }
    }
}