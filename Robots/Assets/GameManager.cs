using Project.Scripts.Character;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;

    private void Start()
    {
        var stats = PlayerManager.Instance.Player.GetComponent<CharacterStats>();
        stats.DieAction += PlayerDied;
    }

    private void PlayerDied()
    {
        _gameOverUI.SetActive(true);
    }
}