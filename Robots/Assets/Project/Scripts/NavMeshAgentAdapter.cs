using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts
{
    internal class NavMeshAgentAdapter : INavMeshAgent
    {
        private readonly NavMeshAgent _agent;

        public NavMeshAgentAdapter(NavMeshAgent agent)
        {
            _agent = agent;
        }

        public void SetDestination(Vector3 point)
        {
            _agent.SetDestination(point);
        }
    }
}