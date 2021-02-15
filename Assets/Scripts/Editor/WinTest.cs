using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace Tests
{
    public class WinTest
    {
        [Test]
        public void CheckIfGameWon_Test()
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
            Assert.IsFalse(_solutions.CheckIfGameWon(gridMap));
        }
    }
}

