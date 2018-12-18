namespace Project.Scripts.Skills
{
    public interface IAttackSkill
    {
        string Name { get; }
        void Attack(IDamagable target);
        void ReduceCooldown(float elaspedCooldown);
    }
}