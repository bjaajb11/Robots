using Project.Scripts;
using Project.Scripts.Character;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    private CharacterStats _stats;

    public void TakeDamage(int amount)
    {
        _stats.TakeDamage(amount);
        Debug.Log($"{transform.name} takes {amount} damage.");
    }

    private void Start()
    {
        _stats = GetComponent<CharacterStats>();
        _stats.DieAction += Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}