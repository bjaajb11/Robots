using NSubstitute;
using NUnit.Framework;
using Project.Scripts;
using Project.Tests.Helpers;

public class AttackSkillSpec

{
    public class AttackTests
    {
        private IDamagable _target;

        [SetUp]
        public void CreateTarget()
        {
            _target = Substitute.For<IDamagable>();
        }

        [Test]
        public void OffCooldown_AppliesDamageToDamagable([Values(10, 0)] int damage)
        {
            AttackSkill attack = Data.AttackSkill.SetDamage(damage);
            attack.Attack(_target);
            _target.Received().TakeDamage(damage);
        }

        [Test]
        public void TargetIsNull_DoesNoDamage()
        {
            AttackSkill attack = Data.AttackSkill.SetDamage(100);
            attack.Attack(null);
            _target.DidNotReceive().TakeDamage(Arg.Any<int>());
        }

        [Test]
        public void AttackWithinCooldown_DoesNotApplyDamage()
        {
            var attack = Data.AttackSkill.SetDamage(10).SetCooldown(1).SetCurrentCooldown(0.5f);
            attack.Attack(_target);
            _target.DidNotReceive().TakeDamage(Arg.Any<int>());
        }

        [Test]
        public void AttackAfterCooldown_AppliesDamage()
        {
            var attack = Data.AttackSkill.SetDamage(10).SetCooldown(1).SetCurrentCooldown(0.5f);
            attack.ReduceCooldown(0.5f);
            attack.Attack(_target);
            _target.Received().TakeDamage(10);
        }

        [Test]
        public void TwoAttacksWithinCooldown_AppliesDamageOnce()
        {
            AttackSkill attack = Data.AttackSkill.SetDamage(10).SetCooldown(1);
            attack.Attack(_target);
            attack.ReduceCooldown(0.75f);
            attack.Attack(_target);
            _target.Received(1).TakeDamage(10);
        }
    }
}