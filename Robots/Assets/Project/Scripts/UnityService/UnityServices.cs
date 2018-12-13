using UnityEngine;

namespace Project.Scripts
{
    internal class UnityServices
    {
        internal static ICamera MainCamera => new CameraFacade(Camera.main);
        internal static IPhysics Physics => new PhysicsFacade();
    }
}