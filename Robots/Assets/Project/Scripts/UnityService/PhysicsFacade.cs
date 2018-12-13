using UnityEngine;

namespace Project.Scripts
{
    internal class PhysicsFacade : IPhysics
    {
        public bool RayCast(Ray ray, out RaycastHit hit, int distance, LayerMask movementMask)
        {
            return Physics.Raycast(ray, out hit, distance, movementMask);
        }
    }
}