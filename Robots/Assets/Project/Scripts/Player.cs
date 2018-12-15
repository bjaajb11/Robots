using Project.Scripts;
using UnityEngine;

[RequireComponent(typeof(RayCastMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private AttackSkill _lmbSkill;
    private RayCastMover _mover;
    [SerializeField] private Enemy _target;
    private RayCastInteractor _rayCaster;

    private void Start()
    {
        _mover = GetComponent<RayCastMover>();
        _rayCaster = GetComponent<RayCastInteractor>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            DoLeftMouseAction();
    }

    private void DoLeftMouseAction()
    {
        _mover.Move(Input.mousePosition);
    //    _lmbSkill.Attack(_target);
        _rayCaster.UpdateFocus(Input.mousePosition);
        if(_rayCaster.HasTarget())
            Debug.Log($"Hit interactable {_rayCaster.Target.name}");
    }

    private void FixedUpdate()
    {
        _lmbSkill.ReduceCooldown(Time.deltaTime);
    }
}