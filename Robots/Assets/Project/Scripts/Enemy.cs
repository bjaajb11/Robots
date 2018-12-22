using Project.Scripts;
using Project.Scripts.Character;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    private LookRadiusMover _mover;
    private CharacterStats _stats;
    [SerializeField] private AttackSkill _skill;
    public void TakeDamage(int amount)
    {
        _stats.TakeDamage(amount);
        Debug.Log($"{transform.name} takes {amount} damage.");
    }

    private void Start()
    {
        _stats = GetComponent<CharacterStats>();
        _mover = GetComponent<LookRadiusMover>();
        _stats.DieAction += Die;
    }

    private void Update()
    {
        var player = PlayerManager.Instance.Player;
        if (player.IsDead) return;
        var position = player.transform.position;
        _mover.Move(position);
        var distance = Vector3.Distance(position, transform.position);
        if(distance < 2f)
            _skill.Attack(player.GetComponent<CharacterStats>());
        _skill.ReduceCooldown(Time.deltaTime);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}