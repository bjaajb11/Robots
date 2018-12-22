using Project.Scripts.Character;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;

    private void Start()
    {
        var stats = PlayerManager.Instance.Player.GetComponent<CharacterStats>();
        stats.DieAction += PlayerDied;
        _gameOverUI.SetActive(false);
    }

    private void PlayerDied()
    {
        _gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}