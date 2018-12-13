using UnityEngine;

namespace Project.Scripts
{
    internal class CameraFacade : ICamera
    {
        private readonly Camera _camera;

        public CameraFacade(Camera camera)
        {
            _camera = camera;
        }

        public Ray ScreenPointToRay(Vector3 rayCastPoint)
        {
            return _camera.ScreenPointToRay(rayCastPoint);
        }
    }
}