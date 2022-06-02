using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Reference
    {
        private GameObject _bonusLabel;
        private GameObject _gameLabel;
        private GameObject _restartButton;
        private GameObject _pauseButton;
        private Canvas _canvas;
        private Camera _mainCamera;

        public GameObject BonusLabel
        {
            get
            {
                if(_bonusLabel == null)
                {
                    GameObject bonusLabelPrefab = Resources.Load<GameObject>("UI/BonusLabel");
                    _bonusLabel = Object.Instantiate(bonusLabelPrefab, Canvas.transform);
                }
                return _bonusLabel;
            }

            set { _bonusLabel = value; }
        }

        public GameObject GameLabel
        {
            get
            {
                if (_gameLabel == null)
                {
                    GameObject gameLabelPrefab = Resources.Load<GameObject>("UI/GameLabel");
                    _gameLabel = Object.Instantiate(gameLabelPrefab, Canvas.transform);
                }
                return _gameLabel;
            }

            set { _gameLabel = value; }
        }

        public GameObject RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    GameObject restartButtonPrefab = Resources.Load<GameObject>("UI/RestartButton");
                    _restartButton = Object.Instantiate(restartButtonPrefab, Canvas.transform);
                }
                return _restartButton;
            }

            set { _restartButton = value; }
        }

        public GameObject PauseButton
        {
            get
            {
                if (_pauseButton == null)
                {
                    GameObject pauseButtonPrefab = Resources.Load<GameObject>("UI/PauseButton");
                    _pauseButton = Object.Instantiate(pauseButtonPrefab, Canvas.transform);
                }
                return _pauseButton;
            }

            set { _pauseButton = value; }
        }

        public Canvas Canvas
        {
            get 
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas; 
            }

            set { _canvas = value; }
        }

        public Camera MainCamera
        {
            get 
            { 
                if(_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera; 
            }
            set { _mainCamera = value; }
        }
    }
}
