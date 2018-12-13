using UnityEngine;

namespace Project.Scripts
{
    public interface INavMeshAgent
    {
        void SetDestination(Vector3 point);
    }
}