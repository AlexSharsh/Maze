using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Maze
{
    public class BadBonus : Bonus, IFly, IRotation
    {
        private float HightFly;
        private float SpeedRotation;

        public event Action<string, Color> OnCaughtPlayer = delegate (string str, Color color) { };
        
        void Awake()
        {
            HightFly = Random.Range(1f, 5f);
            SpeedRotation = Random.Range(1f, 10f);
            _transform = GetComponent<Transform>();
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, HightFly), _transform.position.z);
        }

        public void Rotate()
        {
            _transform.Rotate(Vector3.up * SpeedRotation, Space.World);
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }

        protected override void Interaction()
        {
            OnCaughtPlayer.Invoke(gameObject.name, _color);
        }
    }
}
