using Project.Scripts.Character;

namespace Project.Scripts.Skills
{
    public interface IAttackSkill
    {
        string Name { get; }
        void Attack(ICharacterStats target);
        void ReduceCooldown(float elaspedCooldown);
    }
}