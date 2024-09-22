using UnityEngine;
using UnityEngine.UI;

namespace PatternsExamples.Behavioral.Bytecode.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private Image _progressBar;

        private int _currentHealth;

        public string Name => gameObject.name;
        public int CurrentHealth => _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void Start()
        {
            UpdateProgressBar();
        }

        public void SetCurrentHealth(int value)
        {
            value = Mathf.Clamp(value, 0, _maxHealth);
            _currentHealth = value;
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            _progressBar.fillAmount = (float)_currentHealth / _maxHealth;
        }
    }
}