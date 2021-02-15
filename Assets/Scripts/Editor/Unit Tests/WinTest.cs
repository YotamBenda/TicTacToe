using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace Tests
{
    public class WinTest
    {
        [Test]
        public void CheckIfGameWon_Win()
        {
            var gridMap = new Grid[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gridMap[i, j] = new Grid();
                    gridMap[i, j].PlayerID = 0;
                }
            }
            Solutions _solutions = new Solutions();
            Assert.IsTrue(_solutions.CheckIfGameWon(gridMap));
        }

        [Test]
        public void CheckIfGameWon_Lose()
        {
            var gridMap = new Grid[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gridMap[i, j] = new Grid();
                    gridMap[i, j].PlayerID = 1;
                }
            }
            Solutions _solutions = new Solutions();
            Assert.IsTrue(_solutions.CheckIfGameWon(gridMap));
        }

        [Test]
        public void CheckIfGameWon_Draw()
        {
            var _gridMap = new Grid[3, 3];
            var gridMapInit = new Grid[9];
            var _solutions = new Solutions();
            var _gameManager = new GameManagerMockUp();
            var _movesRecorder = new MovesRecorder();
            var _gameEvent = new GameEvent();
            var index = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _gridMap[i, j] = new Grid();
                    _gridMap[i, j].PlayerID = index;
                    index++;
                }
            }
            Assert.IsFalse(_gameManager.CheckIfGameEnded(_movesRecorder, _solutions, _gridMap, gridMapInit, _gameEvent));
        }
    }
}

