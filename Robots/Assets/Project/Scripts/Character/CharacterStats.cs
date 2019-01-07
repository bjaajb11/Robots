using System;
using UnityEngine;

namespace Project.Scripts.Character
{
    public class CharacterStats : MonoBehaviour, ICharacterStats
    {
        private int _currentHealth;
        [SerializeField] private Stat _maxHealth;
        public bool IsDead => _currentHealth < 1;

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (damage > 0)
                TakeDamageAction?.Invoke(damage);
            if (_currentHealth <= 0)
                DieAction?.Invoke();
        }

        public event Action DieAction;
        public GameObject GameObject => gameObject;

        public void SetInternals(int currentHealth)
        {
            _currentHealth = currentHealth;
        }

        public event Action<int> TakeDamageAction;

        private void Start()
        {
            _currentHealth = _maxHealth.Value;
        }
    }
}