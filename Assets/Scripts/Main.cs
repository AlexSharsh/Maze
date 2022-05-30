using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        ViewEndGame _viewEndGame;
        [SerializeField] private GameObject _gameOverPrefab;

        ViewBonus _viewBonus;
        [SerializeField] private GameObject _viewBonusPrefab;

        [SerializeField] private Button _restartButton;

        private int GoodBonusCount;

        void Awake()
        {
            //GameObject _gameOverPrefab = Resources.Load<GameObject>("Bonus");
            //GameObject _viewBonusPrefab = Resources.Load<GameObject>("EndGame");

            _viewEndGame = new ViewEndGame(_gameOverPrefab);
            _viewBonus = new ViewBonus(_viewBonusPrefab);
            _viewBonus.Display(0);
            _restartButton.onClick.AddListener(RestartGame);

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
            _viewEndGame.GameOver();

            Time.timeScale = 0f;
        }

        private void Win()
        {
            if (Time.timeScale > 0)
            {
                _viewEndGame.Win();
                Time.timeScale = 0f;
            }
        }

        public void Bonus(int points)
        {
            Debug.Log("Bonus: " + points);
            GoodBonusCount += points;
            _viewBonus.Display(GoodBonusCount);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
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

            if (IsWin())
            {
                Win();
            }
        }

        private bool IsWin()
        {
            if (GoodBonusCount == _goodBonusPointsListObj.Count)
            {
                return true;
            }

            return false;
        }
    }
}
