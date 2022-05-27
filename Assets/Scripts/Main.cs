using System;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObjects _interactiveObjects;
        private InputController _inputController;

        private BadBonusPoints _BadBonusPoints;
        private GoodBonusPoints _GoodBonusPoints;
        private List<GameObject> _badBonusPointsListObj;
        private List<GameObject> _goodBonusPointsListObj;

        [SerializeField] private Transform[] _BadBonusPointsList;
        [SerializeField] private Transform[] _GoodBonusPointsList;
        [SerializeField] private GameObject _badBonusPrefab;
        [SerializeField] private GameObject _goodBonusPrefab;

        [SerializeField] private GameObject _player;

        void Awake()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObjects = new ListExecuteObjects();

            _BadBonusPoints = new BadBonusPoints();
            _badBonusPointsListObj = _BadBonusPoints.Init(_badBonusPrefab, _BadBonusPointsList);

            _GoodBonusPoints = new GoodBonusPoints();
            _goodBonusPointsListObj = _GoodBonusPoints.Init(_goodBonusPrefab, _GoodBonusPointsList);

            _interactiveObjects.AddExecute(_inputController);


            for(int i = 0; i < _badBonusPointsListObj.Count; i++)
            {
                BadBonus badBonus = _badBonusPointsListObj[i].gameObject.GetComponentInChildren<BadBonus>();
                badBonus.OnCaughtPlayer += GameOver;
            }

            for (int i = 0; i < _goodBonusPointsListObj.Count; i++)
            {
                GoodBonus goodBonus = _goodBonusPointsListObj[i].gameObject.GetComponentInChildren<GoodBonus>();
                goodBonus.AddPoints += Bonus;
            }
        }

        public void GameOver(string name, Color color)
        {
            Debug.Log(name + " color: " + color);
        }
        public void Bonus(int points)
        {
            Debug.Log("Bonus: " + points);
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
