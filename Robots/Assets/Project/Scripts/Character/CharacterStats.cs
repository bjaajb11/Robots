using System;
using UnityEngine;

namespace Project.Scripts.Character
{
    public class CharacterStats : MonoBehaviour, ICharacterStats
    {
        private int _currentHealth;
        [SerializeField] private Stat _maxHealth;

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
                DieAction?.Invoke();
        }

        public void SetInternals(int currentHealth)
        {
            _currentHealth = currentHealth;
        }

        public event Action DieAction;
        public GameObject GameObject => gameObject;

        private void Start()
        {
            _currentHealth = _maxHealth.Value;
        }
    }
}