using NSubstitute;
using NUnit.Framework;
using Project.Scripts;
using UnityEngine;

public class AttackSkillSpecc

{
    public class AttackTests
    {
        [Test]
        public void OffCooldown_AppliesDamageToDamagable([Values(10, 0)] int damage)
        {
            var target = Substitute.For<IDamagable>();
            var attack =ScriptableObject.CreateInstance<AttackSkill>();
            attack.Init(damage);
            attack.Attack(target);
            target.Received().TakeDamage(damage);
        }

        [Test]
        public void TargetIsNull_DoesNoDamage()
        {

            var target = Substitute.For<IDamagable>();
            var attack = ScriptableObject.CreateInstance<AttackSkill>();
            attack.Init(100);
            attack.Attack(null);
            target.DidNotReceive().TakeDamage(Arg.Any<int>());
        }
    }
}