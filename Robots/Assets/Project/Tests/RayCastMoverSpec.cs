using NSubstitute;
using NUnit.Framework;
using Project.Scripts;
using UnityEngine;

public class RayCastMoverSpec
{
    public class MoveTests
    {
        [Test]
        [TestCase(0, -1, 0)]
        [TestCase(20, 95.4f, 11.1f)]
        public void RayCastHitsSomething_MovesToPoint(float x, float y, float z)
        {
            var rayCastHitPoint = new Vector3(x, y, z);
            var rayCastPoint = Vector3.left;

            var mover = new GameObject().AddComponent<RayCastMover>();
            var motor = Substitute.For<INavMeshAgentMotor>();
            InitMover(rayCastHitPoint, mover, motor);

            mover.Move(rayCastPoint);

            motor.Received().MoveToPoint(rayCastHitPoint);
        }

        [Test]
        public void TargetIsNotNull_SetsStoppingDistanceToTargetRadius()
        {
            var mover = new GameObject().AddComponent<RayCastMover>();
            var motor = Substitute.For<INavMeshAgentMotor>();
            InitMover(Vector3.back, mover, motor);
            var target = new GameObject().AddComponent<Interactable>();
            mover.Move(Vector3.back, target);
            Assert.That(motor.StoppingDistance, Is.EqualTo(target.Radius * 0.8f));
        }

        [Test]
        public void TargetIsNull_SetsStoppingDistanceTo0()
        {
            var mover = new GameObject().AddComponent<RayCastMover>();
            var motor = Substitute.For<INavMeshAgentMotor>();
            InitMover(Vector3.back, mover, motor);
            mover.Move(Vector3.back);
            Assert.That(motor.StoppingDistance, Is.EqualTo(0));
        }

        private static void InitMover(Vector3 rayCastHitPoint, RayCastMover mover,
            INavMeshAgentMotor motor)
        {
            var movementMask = new LayerMask();
            var rayCast = SetupRayCast(movementMask, rayCastHitPoint);

            mover.Init(rayCast, motor, movementMask);
        }

        private static ICameraRayCast SetupRayCast(LayerMask movementMask, Vector3 rayCastHitPoint)
        {
            var rayCast = Substitute.For<ICameraRayCast>();
            rayCast.GetMaskedHitPoint(Arg.Any<Vector3>(), movementMask).Returns(rayCastHitPoint);
            return rayCast;
        }
    }
}