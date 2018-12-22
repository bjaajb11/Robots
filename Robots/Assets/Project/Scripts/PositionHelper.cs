using UnityEngine;

public static class PositionHelper
{
    public static void FaceTarget(Transform self, Transform target)
    {
        var direction = (target.position - self.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        self.rotation = Quaternion.Slerp(self.rotation, lookRotation, Time.deltaTime * 5f);
    }
}