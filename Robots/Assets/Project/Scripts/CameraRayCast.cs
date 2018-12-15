using UnityEngine;

namespace Project.Scripts
{
    public class CameraRayCast : MonoBehaviour, ICameraRayCast
    {
        private Camera _camera;

        public Vector3? GetMaskedHitPoint(Vector3 point, LayerMask mask)
        {
            var ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, mask))
                return hit.point;
            return null;
        }

        public T GetHitObject<T>(Vector3 point)
        {
            var ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            return hit.collider.GetComponent<T>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }
    }
}