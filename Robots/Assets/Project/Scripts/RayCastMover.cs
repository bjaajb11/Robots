using UnityEngine;

namespace Project.Scripts
{
    [RequireComponent(typeof(NavMeshAgentMotor), typeof(CameraRayCast))]
    public class RayCastMover : MonoBehaviour
    {
        private INavMeshAgentMotor _motor;
        [SerializeField] private LayerMask _movementMask;
        private ICameraRayCast _raycaster;

        public void Move(Vector3 rayCastPoint, Interactable target = null)
        {
            var point = _raycaster.GetMaskedHitPoint(rayCastPoint, _movementMask);
            if (point.HasValue)
                _motor.MoveToPoint(point.Value);
            _motor.StoppingDistance = (target?.Radius ?? 0f) * 0.8f;

        }

        public void Init(ICameraRayCast rayCaster, INavMeshAgentMotor motor, LayerMask movementMask)
        {
            _raycaster = rayCaster;
            _motor = motor;
            _movementMask = movementMask;
        }

        private void Start()
        {
            _raycaster = GetComponent<ICameraRayCast>();
            _motor = GetComponent<NavMeshAgentMotor>();
        }
    }
}