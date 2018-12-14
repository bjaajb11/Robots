using Project.Scripts;
using UnityEngine;

[RequireComponent(typeof(RayCastMover))]
public class Player : MonoBehaviour
{
    private RayCastMover _mover;

    [SerializeField] private AttackSkill _lmbSkill;

    private void Start()
    {
        _mover = GetComponent<RayCastMover>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _mover.Move(Input.mousePosition);
    }
}