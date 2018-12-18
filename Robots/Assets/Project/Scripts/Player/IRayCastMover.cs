using UnityEngine;

namespace Project.Scripts.Player
{
    public interface IRayCastMover
    {
        void Move(Vector3 rayCastPoint, Interactable target = null);
    }
}