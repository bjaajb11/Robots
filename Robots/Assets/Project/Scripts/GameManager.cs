using System.Linq;
using Project.Scripts.Character;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _enemyCount;
    [SerializeField] private GameOverUI _gameOverUI;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void Start()
    {
        var stats = PlayerManager.Instance.Player.GetComponent<CharacterStats>();
        stats.DieAction += PlayerDied;
        _gameOverUI.Hide();

        var enemies = FindObjectsOfType<Enemy>().ToList();
        enemies.ForEach(e => e.GetComponent<CharacterStats>().DieAction += TrackEnemies);
        _enemyCount = enemies.Count;
    }

    private void TrackEnemies()
    {
        _enemyCount--;
        if (_enemyCount < 1)
            _gameOverUI.Show("You Win!");
    }

    private void PlayerDied()
    {
       _gameOverUI.Show("Game Over");
    }
}