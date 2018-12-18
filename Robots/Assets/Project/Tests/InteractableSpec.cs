using NUnit.Framework;
using Project.Scripts;
using UnityEngine;

public class InteractableSpec
{
    public class IsInRangeTests
    {
        [Test]
        public void PositionInRadius_ReturnsTrue([Values(1.1f, 1f)] float radius)
        {
            var position = Vector3.left;
            var interactable = new GameObject().AddComponent<Interactable>();
            interactable.SetInternals(radius);
            Assert.That(interactable.IsInRange(position), Is.True);
        }

        [Test]
        public void PositionOutsideOfRadius_ReturnsFalse()
        {
            var position = Vector3.left;
            var interactable = new GameObject().AddComponent<Interactable>();
            interactable.SetInternals(0.5f);
            Assert.That(interactable.IsInRange(position), Is.False);
        }
    }
}