using Project.Scripts.Player;
using UnityEngine;

namespace Project.Scripts
{
    [RequireComponent(typeof(CameraRayCast))]
    public class RayCastInteractor : MonoBehaviour, IRayCastInteractor
    {
        private ICameraRayCast _rayCaster;

        public Interactable Target { get; private set; }

        public bool HasTarget()
        {
            return Target != null;
        }

        public void UpdateFocus(Vector3 testPoint)
        {
            Target = _rayCaster.GetHitObject<Interactable>(testPoint);
        }

        public void Init(ICameraRayCast rayCaster)
        {
            _rayCaster = rayCaster;
        }

        private void Start()
        {
            _rayCaster = GetComponent<CameraRayCast>();
        }
    }
}