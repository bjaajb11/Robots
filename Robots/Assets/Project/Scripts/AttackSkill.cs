using UnityEngine;

namespace Project.Scripts
{
    [CreateAssetMenu(fileName = "AttackSkill", menuName = "Skills/AttackSkill", order = 1)]
    public class AttackSkill : ScriptableObject
    {
        [SerializeField] private int _damage;

        public void Attack(IDamagable target)
        {
            if (target == null)
            {
                Debug.LogWarning("Attack called without target");
                return;
            }
            target.TakeDamage(_damage);
        }

        public void Init(int damage)
        {
            _damage = damage;
        }
    }
}