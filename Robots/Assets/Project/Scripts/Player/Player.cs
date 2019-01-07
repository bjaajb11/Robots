using Project.Scripts;
using Project.Scripts.Character;
using UnityEngine;

[RequireComponent(typeof(MouseAction))]
[RequireComponent(typeof(CharacterStats))]
public class Player : MonoBehaviour
{
    private CharacterStats _characterStats;
    [Header("Skills")] [SerializeField] private AttackSkill _lmbSkill;

    private MouseAction _mouseAction;

    public bool IsDead => _characterStats?.IsDead ?? false;

    private void Start()
    {
        _mouseAction = GetComponent<MouseAction>();
        _characterStats = GetComponent<CharacterStats>();
        _characterStats.DieAction += Die;
        _lmbSkill.SetAnimator(GetComponent<Animator>());
    }

    private void Die()
    {
        Debug.Log("Player died!");
    }

    private void Update()
    {
        if (IsDead) return;
        if (Input.GetMouseButtonDown(0))
        {
            _mouseAction.DoMouseAction(Input.mousePosition, _lmbSkill);
         
        }
        _lmbSkill.ReduceCooldown(Time.deltaTime);
    }
}