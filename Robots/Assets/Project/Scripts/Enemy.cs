using Project.Scripts;
using Project.Scripts.Character;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    [SerializeField] private GameObject _hitParticles;
    private LookRadiusMover _mover;
    [SerializeField] private AttackSkill _skill;
    private CharacterStats _stats;

    private void Start()
    {
        _stats = GetComponent<CharacterStats>();
        _mover = GetComponent<LookRadiusMover>();
        _stats.DieAction += Die;
        _stats.TakeDamageAction += TakeDamage;
    }

    private void Update()
    {
        var player = PlayerManager.Instance.Player;
        if (player.IsDead) return;
        var position = player.transform.position;
        _mover.Move(position);
        var distance = Vector3.Distance(position, transform.position);
        if (distance < 2f)
            _skill?.Attack(player.GetComponent<CharacterStats>());
        _skill?.ReduceCooldown(Time.deltaTime);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void TakeDamage(int amount)
    {
        var rotation = new Quaternion(0, 180, 180, 0);
        Instantiate(_hitParticles, transform.position, rotation);
        Debug.Log($"{transform.name} takes {amount} damage.");
    }
}