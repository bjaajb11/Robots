using Project.Scripts.Character;
using Project.Scripts.Skills;
using UnityEngine;

namespace Project.Scripts
{
    [CreateAssetMenu(fileName = "AttackSkill", menuName = "Skills/AttackSkill", order = 1)]
    public class AttackSkill : ScriptableObject, IAttackSkill
    {
        private Animator _animator;
        [SerializeField] private float _cooldown;
        [SerializeField] private int _damage;
        [SerializeField] private string _name = "Attack Skill";
        private float _remainingCooldown;
        [SerializeField] private GameObject _source;

        public string Name => _name;

        public void Attack(ICharacterStats target)
        {
            if (target == null)
            {
                Debug.LogWarning("Attack called without target");
                return;
            }
            if (_remainingCooldown > 0) return;
            Debug.Log($"{_source?.name ?? "Unknown"} attacks {target.GameObject?.name} with {_name} for {_damage}");

            Animate();
            target.TakeDamage(_damage);
            _remainingCooldown = _cooldown;
        }

        public void ReduceCooldown(float elaspedCooldown)
        {
            _remainingCooldown -= elaspedCooldown;
        }

        public void Init(int damage, float cooldwon)
        {
            _damage = damage;
            _cooldown = cooldwon;
        }

        public void SetInternals(float currentCooldown)
        {
            _remainingCooldown = currentCooldown;
        }

        private void Animate()
        {
            if (_animator == null) return;
            _animator.SetTrigger(_name);
        }

        public void SetAnimator(Animator animator)
        {
            _animator = animator;
        }
    }
}