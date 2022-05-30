using UnityEngine;

namespace Maze
{
    public class InputController : IExecute
    {
        private readonly Unit _player;

        private float horizontal;
        private float vertical;

        public InputController(Unit player)
        {
            _player = player;
        }
        
        public void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            _player.Move(horizontal, 0f, vertical);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.Jump();
            }
        }
    }
}
