using NSubstitute;
using NUnit.Framework;
using Project.DataBuilders;
using UnityEngine;

public class MoverSpec
{
    public class MoveTests
    {
        [Test]
        public void SpeedIsZero_DoesNotMove()
        {
            Mover mover = Data.Mover().SetSpeed(0);
            mover.Move(0, 0, 0);
            Assert.That(mover.Position, Is.EqualTo(Vector3.zero));
        }

        [Test]
        [TestCase(1, 1, 1)]
        [TestCase(-0.4f, 1, -0.4f)]
        [TestCase(1, 0, 0)]
        public void HorizontalMovement_GameObjectXPositionUpdated(float horizontal, float deltaTime, float expectedX)
        {
            Mover mover = Data.Mover().SetSpeed(1);
            mover.Move(horizontal, 0, deltaTime);
            Assert.That(mover.Position, Is.EqualTo(new Vector3(expectedX, 0, 0)));       
        }

        [Test]
        public void VerticalMovement_GameObjectZPositionUpdated()
        {
            Mover mover = Data.Mover().SetSpeed(3);
            mover.Move(0, 3, 1);
            Assert.That(mover.Position, Is.EqualTo(new Vector3(0, 0, 9)));
        }

        [Test]
        public void PositionIsOffsetFromZero_UpdatesPosition()
        {
            Mover mover = Data.Mover().SetSpeed(2).Position(new Vector3(10, 0, 8));
            mover.Move(0.9f, -2f, 1.1f);
            Assert.That(mover.Position, Is.EqualTo(new Vector3(11.98f, 0, 3.6f)));
        }
    }
}