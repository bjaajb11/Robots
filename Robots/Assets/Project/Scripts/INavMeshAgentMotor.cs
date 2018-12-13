using UnityEngine;

namespace Project.Scripts
{
    public interface INavMeshAgentMotor
    {
        void MoveToPoint(Vector3 point);
    }
}