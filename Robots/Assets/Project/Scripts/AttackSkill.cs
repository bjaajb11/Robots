﻿using UnityEngine;

namespace Project.Scripts
{
    [CreateAssetMenu(fileName = "AttackSkill", menuName = "Skills/AttackSkill", order = 1)]
    public class AttackSkill : ScriptableObject
    {
        [SerializeField] private float _cooldown;
        [SerializeField] private int _damage;
        private float _remainingCooldown;

        public void Attack(IDamagable target)
        {
            if (target == null)
            {
                Debug.LogWarning("Attack called without target");
                return;
            }
            if (_remainingCooldown > 0) return;
            target.TakeDamage(_damage);
            _remainingCooldown = _cooldown;
        }

        public void Init(int damage, float cooldwon)
        {
            _damage = damage;
            _cooldown = cooldwon;
        }

        public void ReduceCooldown(float elaspedCooldown)
        {
            _remainingCooldown -= elaspedCooldown;
        }

        public void SetInternals(float currentCooldown)
        {
            _remainingCooldown = currentCooldown;
        }
    }
}