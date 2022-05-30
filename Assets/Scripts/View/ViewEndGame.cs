using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class ViewEndGame
    {
        private Text _endGameLabel;
        public ViewEndGame(GameObject endGamePrefab)
        {
            _endGameLabel = endGamePrefab.GetComponent<Text>();
            _endGameLabel.text = string.Empty;
        }

        public void GameOver()
        {
            _endGameLabel.text = "Game over";
        }

        public void Win()
        {
            _endGameLabel.text = "You are WIN";
        }
    }
}
