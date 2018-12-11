using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private int _speed;

    public int Speed
    {
        get { return _speed; }
      private  set { _speed = value; }
    }

    public void Init(int speed)
    {
        Speed = speed;
    }

    public Vector3 Position
    {
        get { return gameObject.transform.position; }
        private set { gameObject.transform.position = value; }
    }

    public void Move(float horizontal, float vertical, float deltaTime)
    {
        var position = Position;
        var distance = Speed * deltaTime;
        position.x += horizontal * distance;
        position.z += vertical * distance;
        Position = position;
    }
}