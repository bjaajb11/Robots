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
            InitMover(rayCastPoint, rayCastHitPoint, mover, motor);

            mover.Move(rayCastPoint);

            motor.Received().MoveToPoint(rayCastHitPoint);
        }

        private static void InitMover(Vector3 rayCastPoint, Vector3 rayCastHitPoint, RayCastMover mover,
            INavMeshAgentMotor motor)
        {
            var movementMask = new LayerMask();
            var ray = new Ray();
            var camera = SetupCamera(rayCastPoint, ray);
            var physics = SetupPhysics(ray, movementMask, rayCastHitPoint);

            mover.Init(physics, camera, motor, movementMask);
        }

        private static ICamera SetupCamera(Vector3 rayCastPoint, Ray ray)
        {
            var camera = Substitute.For<ICamera>();
            camera.ScreenPointToRay(rayCastPoint).Returns(ray);
            return camera;
        }

        private static IPhysics SetupPhysics(Ray ray, LayerMask movementMask, Vector3 rayCastHitPoint)
        {
            var physics = Substitute.For<IPhysics>();
            RaycastHit hit;

            physics.RayCast(ray, out hit, 100, movementMask).Returns(x =>
            {
                x[1] = new RaycastHit {point = rayCastHitPoint};

                return true;
            });
            return physics;
        }
    }
}