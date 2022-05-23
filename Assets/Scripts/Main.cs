using System;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObjects _interactiveObjects;
        private InputController _inputController;

        [SerializeField] private GameObject _player;

        void Awake()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObjects = new ListExecuteObjects();

            _interactiveObjects.AddExecute(_inputController);
        }

        
        void Update()
        {
            for (int i = 0; i < _interactiveObjects.Lenght; i++)
            {
                if (_interactiveObjects[i] == null)
                {
                    continue;
                }

                _interactiveObjects[i].Update();
            }
        }
    }
}
