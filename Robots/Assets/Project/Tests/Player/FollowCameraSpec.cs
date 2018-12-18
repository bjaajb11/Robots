using System.Collections.Generic;
using NUnit.Framework;
using Project.Scripts;
using UnityEngine;

public class FollowCameraSpec
{
    public class SetPosition
    {
        public static IEnumerable<PositionOffsetItem> GetPositionOffsetItems()
        {
            yield return new PositionOffsetItem
            {
                Position = Vector3.forward * 20,
                Offset = new Vector3(10, 2.1f, 94)
            };
            yield return new PositionOffsetItem
            {
                Position = Vector3.right * 2.43f,
                Offset = new Vector3(10, 2.1f, 94)
            };
        }

        [Test]
        public void Always_SetsPositionAtPlayerPositionPlusOffset(
            [ValueSource(nameof(GetPositionOffsetItems))] PositionOffsetItem positionOffset)
        {
            var cameraPosition = new GameObject().transform;
            var gameObject = new GameObject();
            var followCamera = gameObject.AddComponent<FollowCamera>();
            gameObject.transform.position = positionOffset.Position;
            var offset = positionOffset.Offset;
            followCamera.Init(cameraPosition, offset);
            var calculatedPosition = gameObject.transform.position + offset;

            followCamera.SetPosition();
            Assert.That(cameraPosition.position, Is.EqualTo(calculatedPosition));
        }
    }

    public class PositionOffsetItem
    {
        public Vector3 Position { get; set; }
        public Vector3 Offset { get; set; }
    }
}