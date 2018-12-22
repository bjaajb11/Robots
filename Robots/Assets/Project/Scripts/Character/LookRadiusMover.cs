using UnityEngine;

namespace Project.Scripts.Character
{
    [RequireComponent(typeof(NavMeshAgentMotor))]
    public class LookRadiusMover : MonoBehaviour
    {
        [SerializeField] private float _lookRadius;
        private INavMeshAgentMotor _motor;
        [SerializeField] private float _stopRange;

        public void Init(INavMeshAgentMotor motor)
        {
            _motor = motor;
        }

        public void SetInternals(float lookRaidus, float stopRange)
        {
            _lookRadius = lookRaidus;
            _stopRange = stopRange;
        }

        public void Move(Vector3 position)
        {
            var distance = Vector3.Distance(position, transform.position);

            if (distance <= _stopRange || distance > _lookRadius) return;
            _motor.MoveToPoint(position);
        }

        private void Start()
        {
            Init(GetComponent<NavMeshAgentMotor>());
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _lookRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _stopRange);
            
        }
    }
}