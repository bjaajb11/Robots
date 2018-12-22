using Project.Scripts;
using UnityEngine;

[RequireComponent(typeof(MouseAction))]
[RequireComponent(typeof(RayCastInteractor))]
[RequireComponent(typeof(NavMeshAgentMotor))]
public class Player : MonoBehaviour
{
    [Header("Skills")] [SerializeField] private AttackSkill _lmbSkill;

    private MouseAction _mouseAction;

    private void Start()
    {
        _mouseAction = GetComponent<MouseAction>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _mouseAction.DoMouseAction(Input.mousePosition, _lmbSkill);

        _lmbSkill.ReduceCooldown(Time.deltaTime);
    }
}