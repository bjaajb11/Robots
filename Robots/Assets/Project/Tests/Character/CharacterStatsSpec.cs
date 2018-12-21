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
}