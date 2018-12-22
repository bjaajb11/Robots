using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    public static PlayerManager Instance { get; private set; }
    public Player Player => _player;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
}