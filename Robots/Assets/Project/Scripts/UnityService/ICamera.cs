using UnityEngine;

namespace Project.Scripts
{
    public interface ICamera
    {
        Ray ScreenPointToRay(Vector3 rayCastPoint);
    }
}