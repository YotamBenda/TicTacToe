﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HintTest
    {
        [Test]
        public void CheckForHint_Test()
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


    }
}
