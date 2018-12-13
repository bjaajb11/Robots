using UnityEngine;

namespace Project.Scripts
{
    [RequireComponent(typeof(NavMeshAgentMotor))]
    public class RayCastMover : MonoBehaviour
    {
        private ICamera _camera;
        private INavMeshAgentMotor _motor;
        [SerializeField] private LayerMask _movementMask;
        private IPhysics _physics;

        public void Move(Vector3 rayCastPoint)
        {
            var ray = _camera.ScreenPointToRay(rayCastPoint);
            RaycastHit hit;
            if (_physics.RayCast(ray, out hit, 100, _movementMask))
                _motor.MoveToPoint(hit.point);
        }

        public void Init(IPhysics physics, ICamera camera, INavMeshAgentMotor motor, LayerMask movementMask)
        {
            _physics = physics;
            _camera = camera;
            _motor = motor;
            _movementMask = movementMask;
        }

        private void Start()
        {
            _camera = UnityServices.MainCamera;
            _motor = GetComponent<NavMeshAgentMotor>();
            _physics = UnityServices.Physics;
        }
    }
}