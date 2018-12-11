using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MoverSpec
{
    public class MoveTests
    {

        [Test]
        public void SpeedIsZero_DoesNotMove()
        {
            var mover = new GameObject().AddComponent<Mover>();
            Vector3 position = mover.Move(0, 0, 0);
            Assert.That(position, Is.EqualTo(Vector3.zero));
        }


    }
}

