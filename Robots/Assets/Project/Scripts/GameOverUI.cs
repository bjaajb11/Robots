using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Text _message;
    [SerializeField] private Text _messageShadow;

    public void Show(string message)
    {
        gameObject.SetActive(true);
        _message.text = message;
        _messageShadow.text = message;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}