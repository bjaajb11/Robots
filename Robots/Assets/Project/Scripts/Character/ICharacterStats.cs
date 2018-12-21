using System;

namespace Project.Scripts.Character
{
    public interface ICharacterStats
    {
        void TakeDamage(int damage);
        event Action DieAction;
    }
}