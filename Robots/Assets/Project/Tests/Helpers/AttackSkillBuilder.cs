using Project.Scripts;
using UnityEngine;

namespace Project.Tests.Helpers
{
    internal class AttackSkillBuilder
    {
        private float _cooldwon;
        private float _currentCooldown;
        private int _damage;

        public static implicit operator AttackSkill(AttackSkillBuilder builder)
        {
            return builder.Build();
        }

        internal AttackSkill Build()
        {
            var attack = ScriptableObject.CreateInstance<AttackSkill>();
            attack.Init(_damage, _cooldwon);
            attack.SetInternals(_currentCooldown);
            return attack;
        }

        internal AttackSkillBuilder SetDamage(int damage)
        {
            _damage = damage;
            return this;
        }

        internal AttackSkillBuilder SetCooldown(float cooldown)
        {
            _cooldwon = cooldown;
            return this;
        }

        internal AttackSkill SetCurrentCooldown(float elapsedCooldown)
        {
            _currentCooldown = elapsedCooldown;
            return this;
        }
    }
}