using UnityEngine;

namespace PatternsExamples.Behavioral.Observer.Scripts
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _destroyCooldown;

        private Vector3 _direction;
        private float _speed;
        private float _timeTillDestroy;

        public void Init(Vector3 direction, float speed)
        {
            _speed = speed;
            _direction = direction;

            _timeTillDestroy = _destroyCooldown;
        }

        private void Update()
        {
            _timeTillDestroy -= Time.deltaTime;
            if (_timeTillDestroy <= 0f)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position += _direction * (_speed * Time.deltaTime);
            }
        }
    }
}