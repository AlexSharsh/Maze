using System;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GoodBonus : Bonus, IFly, IFlicker
    {
        private float HightFly = 3f;
        [SerializeField] private Material _material;
        public int Point = 1;
        public event Action<int> AddPoints = delegate (int i){ };

        void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _transform = GetComponent<Transform>();
        }   

        
        public override void Update()
        {
            Fly();
            Flick();
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, HightFly), _transform.position.z);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        protected override void Interaction()
        {
            AddPoints.Invoke(Point);
        }
    }
}
