using UnityEngine;

namespace Project.Scripts
{
    public class Interactable : MonoBehaviour
    {
        [Header("Interactable")] [SerializeField] private float _radius = 3f;
        public float Radius => _radius;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}