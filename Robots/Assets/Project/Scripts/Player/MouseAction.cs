using Project.Scripts;
using Project.Scripts.Character;
using Project.Scripts.Player;
using Project.Scripts.Skills;
using UnityEngine;

[RequireComponent(typeof(RayCastMover))]
[RequireComponent(typeof(RayCastInteractor))]
public class MouseAction : MonoBehaviour
{
    private IRayCastMover _mover;
    private IRayCastInteractor _rayCaster;

    public void DoMouseAction(Vector3 mousePosition, IAttackSkill skill)
    {
        _rayCaster.UpdateFocus(mousePosition);
        _mover.Move(mousePosition, _rayCaster.Target);

        if (!_rayCaster.HasTarget()) return;

        var target = _rayCaster.Target;
        if (target.IsInRange(transform.position))
            skill?.Attack(target.GetComponent<CharacterStats>());
    }

    public void Init(IRayCastMover mover, IRayCastInteractor interactor)
    {
        _mover = mover;
        _rayCaster = interactor;
    }

    private void Update()
    {
        if (!(_rayCaster?.HasTarget() ?? true)) return;
        PositionHelper.FaceTarget(transform, _rayCaster.Target.transform);
    }

    private void Start()
    {
        _mover = GetComponent<RayCastMover>();
        _rayCaster = GetComponent<RayCastInteractor>();
    }
}