using UnityEngine;

namespace Project.DataBuilders
{
    internal class MoverBuilder
    {
        private Vector3 _position;
        private int _speed;

        public MoverBuilder SetSpeed(int speed)
        {
            _speed = speed;
            return this;
        }

        public Mover Build()
        {
            var gameObject = new GameObject();
            var mover = gameObject.AddComponent<Mover>();
            mover.Init(_speed);
            gameObject.transform.position = _position;
            return mover;
        }

        public static implicit operator Mover(MoverBuilder builder)
        {
            return builder.Build();
        }

        public MoverBuilder Position(Vector3 initialPosition)
        {
            _position = initialPosition;
            return this;
        }
    }
}