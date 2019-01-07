using UnityEngine;

public class DestoryAfterCreate : MonoBehaviour
{
    [SerializeField] private float _delayUntilDestroy;

    private void Awake()
    {
        Destroy(gameObject, _delayUntilDestroy);
    }
}