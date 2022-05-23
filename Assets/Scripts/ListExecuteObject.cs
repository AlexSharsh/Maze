using System.Collections;
using System;
using UnityEngine;

namespace Maze
{
    public sealed class ListExecuteObjects : IEnumerator, IEnumerable
    {
        private IExecute[] _interactiveObject;
        private int _index = -1;

        public object Current => _interactiveObject[_index];
        public int Lenght => _interactiveObject.Length;

        void Start()
        {

        }

        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            set => _interactiveObject[curr] = value;
        }

        public void AddExecute(IExecute execute)
        {
            if(_interactiveObject == null)
            {
                _interactiveObject = new[] {execute};
                return;
            }

            Array.Resize(ref _interactiveObject, Lenght + 1);
            _interactiveObject[Lenght  -1] = execute;
        }

        public bool MoveNext()
        {
            if (_index == Lenght - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }
    }
}
