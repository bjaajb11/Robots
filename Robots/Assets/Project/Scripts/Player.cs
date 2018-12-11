using UnityEngine;

public class Player : MonoBehaviour
{
    private Mover _mover;
    
    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _mover.Move(horizontal, vertical, Time.deltaTime);
    }
}