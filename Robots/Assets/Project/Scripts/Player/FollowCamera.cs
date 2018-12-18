using UnityEngine;

namespace Project.Scripts
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform _cameraPosition;
        [SerializeField] private Vector3 _offset;

        public void SetPosition()
        {
            _cameraPosition.position = transform.position + _offset;
        }

        public void Init(Transform cameraPosition, Vector3 offset)
        {
            _cameraPosition = cameraPosition;
            _offset = offset;
        }

        private void LateUpdate()
        {
            SetPosition();
        }
    }
}