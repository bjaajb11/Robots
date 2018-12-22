using NSubstitute;
using NUnit.Framework;
using Project.Scripts;
using Project.Scripts.Character;
using Project.Tests.Helpers;
using UnityEngine;

public class LookRadiusMoverSpec
{
    public class MoveTests
    {
        [Test]
        [TestCase(0, -1, 0)]
        [TestCase(20, 95.4f, 11.1f)]
        public void SourceInLookRange_MovesToTarget(float x, float y, float z)
        {
            var targetPosition = new Vector3(x, y, z);

            (LookRadiusMover mover, INavMeshAgentMotor motor) = Data.LookRadiusMover.SetLookRadius(100);
            mover.Move(targetPosition);
            motor.Received().MoveToPoint(targetPosition);
        }

        [Test]
        public void SourceNotInLookRange_DoesNotMove()
        {
            (LookRadiusMover mover, INavMeshAgentMotor motor) = Data.LookRadiusMover.SetLookRadius(3)
                .SetPosition(Vector3.left * 5);

            mover.Move(Vector3.left);
            motor.Received(0).MoveToPoint(Vector3.left);
        }

        [Test]
        public void SourceInStopRange_DoesNotMove()
        {
            (LookRadiusMover mover, INavMeshAgentMotor motor) = Data.LookRadiusMover.SetLookRadius(3)
                .SetStopRange(0.5f);
            mover.Move(Vector3.left * 0.2f);
            motor.Received(0).MoveToPoint(Vector3.left * 0.2f);
        }
    }

    internal class LookRadiusMoverBuilder
    {
        private float _lookRadius;
        private INavMeshAgentMotor _motor;
        private LookRadiusMover _mover;
        private Vector3 _position;
        private float _stopRange;

        public void Deconstruct(out LookRadiusMover action, out INavMeshAgentMotor motor)
        {
            Build();
            action = _mover;
            motor = _motor;
        }

        public LookRadiusMoverBuilder SetStopRange(float stopRange)
        {
            _stopRange = stopRange;
            return this;
        }

        internal LookRadiusMoverBuilder SetPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        internal LookRadiusMoverBuilder SetLookRadius(float lookRadius)
        {
            _lookRadius = lookRadius;
            return this;
        }

        private void Build()
        {
            var source = new GameObject();
            _mover = source.AddComponent<LookRadiusMover>();
            _motor = Substitute.For<INavMeshAgentMotor>();
            source.transform.position = _position;
            _mover.Init(_motor);
            _mover.SetInternals(_lookRadius, _stopRange);
        }
    }
}