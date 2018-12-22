using UnityEngine;

namespace Project.Scripts
{
    public interface ICameraRayCast
    {
        Vector3? GetMaskedHitPoint(Vector3 point, LayerMask mask);
        T GetHitObject<T>(Vector3 point) where T: class;
    }
}