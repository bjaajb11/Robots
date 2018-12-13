using UnityEngine;

namespace Project.Scripts
{
    public interface IPhysics
    {
        bool RayCast(Ray ray, out RaycastHit hit, int distance, LayerMask movementMask);
    }
}