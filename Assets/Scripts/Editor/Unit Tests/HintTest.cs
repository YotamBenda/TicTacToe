using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// HintTest is checking 2 scenarios
/// CanGiveHint = all grids are set to neutral (-1)
/// CanNotGiveHint = all grids are set to Player2 (1)
/// </summary>
namespace Tests
{
    public class HintTest
    {
        [Test]
        public void CheckForHint_CanGiveHint()
        {
            var gameManager = new GameManager();
            var usableSlots = new List<Grid>();
            var gridMap = new Grid[9];
            for (int i = 0; i < 9; i++)
            {
                gridMap[i] = new Grid();
                gridMap[i].PlayerID = -1;
            }
            Assert.Positive(gameManager.CheckForHint(false, usableSlots, gridMap));
        }

        [Test]
        public void CheckForHint_CannotGiveHint()
        {
            var gameManager = new GameManager();
            var usableSlots = new List<Grid>();
            var gridMap = new Grid[9];
            for (int i = 0; i < 9; i++)
            {
                gridMap[i] = new Grid();
                gridMap[i].PlayerID = 1;
            }
            Assert.Zero(gameManager.CheckForHint(false, usableSlots, gridMap));
        }
    }
}
