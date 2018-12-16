using UnityEngine;

namespace Project.Scripts
{
    public interface INavMeshAgent
    {
        void SetDestination(Vector3 point);
        float StoppingDistance { get; set; }
    }
}