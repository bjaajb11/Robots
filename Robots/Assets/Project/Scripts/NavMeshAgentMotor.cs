using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshAgentMotor : MonoBehaviour
    {
        private INavMeshAgent _agent;

        public void MoveToPoint(Vector3 point)
        {
            _agent.SetDestination(point);
        }

        public void Init(INavMeshAgent agent)
        {
            _agent = agent;
        }

        private void Start()
        {
            _agent = Wrap(GetComponent<NavMeshAgent>());
        }

        private static INavMeshAgent Wrap(NavMeshAgent agent)
        {
            return new NavMeshAgentAdapter(agent);
        }
    }
}