using UnityEngine;

namespace Project.Scripts.Player
{
    public interface IRayCastInteractor
    {
        Interactable Target { get; }
        bool HasTarget();
        void UpdateFocus(Vector3 testPoint);
    }
}