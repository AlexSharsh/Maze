using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] public View _player;
        [SerializeField] public View _trigger;

        private Controller _controller;

        void Awake()
        {
            _controller = new Controller(_player, _trigger);
        }

        void Update()
        {
            _controller.MyUpdate();
        }
    }
}
