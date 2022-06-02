using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private Reference _reference;
        private ListExecuteObjects _interactiveObjects;
        private InputController _inputController;

        private CameraController _cameraController;

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
        ViewBonus _viewBonus;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _pauseButton;

        private int GoodBonusCount;

        void Awake()
        {
            _reference = new Reference();

            _cameraController = new CameraController(_player.transform, _reference.MainCamera.transform);

            _viewEndGame = new ViewEndGame(_reference.GameLabel);
            _viewBonus = new ViewBonus(_reference.BonusLabel);
            //_restartButton.gameObject.SetActive(false);
            //_pauseButton.gameObject.SetActive(false);
            _viewBonus.Display(0);

            _restartButton.onClick.AddListener(RestartGame);
            _pauseButton.onClick.AddListener(PauseGame);

            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObjects = new ListExecuteObjects();

            _BadBonusPoints = new BadBonusPoints();
            _badBonusPointsListObj = _BadBonusPoints.Init(_badBonusPrefab, _BadBonusPointsList);

            _GoodBonusPoints = new GoodBonusPoints();
            _goodBonusPointsListObj = _GoodBonusPoints.Init(_goodBonusPrefab, _GoodBonusPointsList);

            _interactiveObjects.AddExecute(_inputController);
            _interactiveObjects.AddExecute(_cameraController);

            for (int i = 0; i < _badBonusPointsListObj.Count; i++)
            {
                BadBonus badBonus = _badBonusPointsListObj[i].gameObject.GetComponentInChildren<BadBonus>();
                badBonus.OnCaughtPlayer += GameOver;
            }

            for (int i = 0; i < _goodBonusPointsListObj.Count; i++)
            {
                GoodBonus goodBonus = _goodBonusPointsListObj[i].gameObject.GetComponentInChildren<GoodBonus>();
                goodBonus.AddPoints += AddBonus;
            }

            //foreach (var item in _interactiveObjects)
            //{
            //    if (item is GoodBonus goodBonus)
            //    {
            //        goodBonus.AddPoints += AddBonus;
            //    }

            //    if (item is BadBonus badBonus)
            //    {
            //        badBonus.OnCaughtPlayer += GameOver;
            //    }
            //}
        }

        private void AddBonus(int value)
        {
            GoodBonusCount += value;
            _viewBonus.Display(GoodBonusCount);
            Debug.Log("Bonus: " + GoodBonusCount);
        }

        public void GameOver(string name, Color color)
        {
            _viewEndGame.GameOver();
            Time.timeScale = 0f;
            _pauseButton.interactable = false;
            Debug.Log(name + " color: " + color);
        }

        private void Win()
        {
            if (Time.timeScale > 0)
            {
                _viewEndGame.Win();
                Time.timeScale = 0f;
                _pauseButton.interactable = false;
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }

        private void PauseGame()
        {
            if(Time.timeScale > 0)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
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
