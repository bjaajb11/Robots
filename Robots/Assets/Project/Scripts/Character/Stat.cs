using System;
using UnityEngine;

namespace Project.Scripts
{
    [Serializable]
    public class Stat
    {
        [SerializeField] private int _value;
        public int Value => _value;

        public void SetBaseValue(int value)
        {
            _value = value;
        }
    }
}