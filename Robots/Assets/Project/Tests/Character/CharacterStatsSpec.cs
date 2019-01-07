using NUnit.Framework;
using Project.Scripts.Character;
using UnityEngine;

public class CharacterStatsSpec
{
    public class HealthTests
    {
        [Test]
        public void HealthGoesFrom10To0_CallsDieAction()
        {
            var called = false;
            var stats = new GameObject().AddComponent<CharacterStats>();
            stats.DieAction += () => called = true;
            stats.SetInternals(10);

            stats.TakeDamage(10);
            Assert.That(called, Is.True, "Did not call die action");
        }

        [Test]
        public void HealthGoesFrom10To1_DoesNotCallDieAction()
        {
            var called = false;
            var stats = new GameObject().AddComponent<CharacterStats>();
            stats.DieAction += () => called = true;
            stats.SetInternals(10);
            stats.TakeDamage(9);
            Assert.That(called, Is.False, "Should not have called die action");
        }
    }

    public class IsDeadTests
    {
        [Test]
        [TestCase(10, false, TestName = "Health 10, not dead")]
        [TestCase(1, false, TestName = "Health 1, not dead")]
        [TestCase(0, true, TestName = "Health 0, is dead")]
        [TestCase(-4, true, TestName = "Health -4, is dead")]
        public void HealthIsValue_TrueIfHealthLessThanOne(int currentHealth, bool expectedIsDead)
        {
            var stats = new GameObject().AddComponent<CharacterStats>();
            stats.SetInternals(currentHealth);
            Assert.That(stats.IsDead, Is.EqualTo(expectedIsDead));
        }
    }

    public class TakeDamageTests
    {
        [Test]
        public void TakesExpectedDamage_CallsTakeDamgeAction([Values(9, 2, 3)] int expectedDamage)
        {
            var called = false;
            var actualDamage = 0;
            var stats = new GameObject().AddComponent<CharacterStats>();

            void OnStatsOnTakeDamageAction(int damage)
            {
                called = true;
                actualDamage = damage;
            }

            stats.TakeDamageAction += OnStatsOnTakeDamageAction;
            stats.SetInternals(10);
            stats.TakeDamage(expectedDamage);
            Assert.That(called, Is.True, "Should have called take damage action");
            Assert.That(actualDamage, Is.EqualTo(expectedDamage));
        }

        [Test]
        public void TakesNoDamage_DoesNotCallTakeDamgeAction([Values(0, -1, -130)] int expectedDamage)
        {
            var called = false;
            var stats = new GameObject().AddComponent<CharacterStats>();

            void OnStatsOnTakeDamageAction(int damage)
            {
                called = true;
            }

            stats.TakeDamageAction += OnStatsOnTakeDamageAction;
            stats.SetInternals(10);
            stats.TakeDamage(expectedDamage);
            Assert.That(called, Is.False, "Should not have called take damage action");
        }
    }
}