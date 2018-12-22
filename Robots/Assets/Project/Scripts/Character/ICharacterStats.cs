using System;
using UnityEngine;

namespace Project.Scripts.Character
{
    public interface ICharacterStats
    {
        void TakeDamage(int damage);
        event Action DieAction;
        GameObject GameObject { get; }
    }
}