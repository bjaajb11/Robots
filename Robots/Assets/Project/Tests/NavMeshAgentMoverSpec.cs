using NSubstitute;
using NUnit.Framework;
using Project.Scripts;
using UnityEngine;

public class NavMeshAgentMotorSpec
{
    public class MoveToPointTests
    {
        [Test]
        [TestCase(-1, 0, 0)]
        [TestCase(0, 0, 0)]
        public void Always_SetsAgentDestinationToPoint(float x, float y, float z)
        {
            var agent = Substitute.For<INavMeshAgent>();
            var motor = new GameObject().AddComponent<NavMeshAgentMotor>();
            motor.Init(agent);
            var point = new Vector3(x, y, z);

            motor.MoveToPoint(point);

            agent.Received().SetDestination(point);
        }
    }
}