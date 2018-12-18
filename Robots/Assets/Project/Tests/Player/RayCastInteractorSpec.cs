using NSubstitute;
using NUnit.Framework;
using Project.Scripts;
using Project.Tests.Helpers;
using UnityEngine;

public class RayCastInteractorSpec
{
    public class HasTargetTests
    {
        [Test]
        public void RayCastHitsInteractable_ReturnsInteractable()
        {
            var interactable = new GameObject().AddComponent<Interactable>();
            RayCastInteractor interactor = Data.RayCastInteractor.SetHitTarget(interactable);
            interactor.UpdateFocus(Vector3.right);
            ;
            var hasTarget = interactor.HasTarget();
            Assert.That(hasTarget, Is.True);
        }

        [Test]
        public void RayCastDoesNotHitInteractable_ReturnsFalse()
        {
            RayCastInteractor interactor = Data.RayCastInteractor;
            interactor.UpdateFocus(Vector3.right);
            var hasTarget = interactor.HasTarget();
            Assert.That(hasTarget, Is.False);
        }
    }

    public class UpdateFocusTests
    {
        [Test]
        [TestCase(-1, 0, 0)]
        [TestCase(20, 33.245f, 99.21f)]
        public void Always_CallsGetHitObjectWithTestPoint(float x, float y, float z)
        {
            ICameraRayCast rayCaster = null;
            RayCastInteractor interactor = Data.RayCastInteractor.GetRayCaster(r => rayCaster = r);
            var testPoint = new Vector3(x, y, z);
            interactor.UpdateFocus(testPoint);
            rayCaster.Received().GetHitObject<Interactable>(testPoint);
        }
    }

    public class TargetProperty
    {
        [Test]
        public void UpdateFocusHitTarget_HasTarget()
        {
            var target = new GameObject().AddComponent<Interactable>();
            RayCastInteractor rayCaster = Data.RayCastInteractor.SetHitTarget(target);
            rayCaster.UpdateFocus(Vector3.back);
            Assert.That(rayCaster.Target, Is.EqualTo(target));
        }

        [Test]
        public void UpdateFocusDoesNotHitTarget_TargetIsNull()
        {            
            RayCastInteractor rayCaster = Data.RayCastInteractor.SetHitTarget(null);
            rayCaster.UpdateFocus(Vector3.back);
            Assert.That(rayCaster.Target, Is.Null);
        }
    }
}