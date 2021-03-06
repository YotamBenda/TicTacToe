﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// UntoTest is checking 3 scenarios.
/// ShouldUndo_CanUndo - computer is playing + there are possible hints on the gridMap.
/// ShouldUndo_CanNotUndo - computer is playing + there arent any possible hints (board is full).
/// ShouldNotUndo_CanUndo - computer isn't playing + there are opossible hints
/// </summary>
namespace Tests
{
    public class UndoTest
    {
        [Test]

        public void UndoTest_ShouldUndo_CanUndo()
        {
            var movesRecorder = new MovesRecorder();
            var gridMapInit = new GridMock[9];
            var shouldUndo = true;
            var gameManager = new GameManagerMockUp();

            for (int i = 0; i < gridMapInit.Length ; i++)
            {
                gridMapInit[i] = new GridMock();
                movesRecorder.movesRecorder.Push(i);
            }
            gameManager.UndoLastMoves(movesRecorder, gridMapInit, shouldUndo);
            for (int j = 0; j < gridMapInit.Length; j++)
            {
                if(j < 7)
                {
                    Assert.AreEqual(gridMapInit[j].PlayerID, 0);
                }
                else
                {
                    Assert.AreEqual(gridMapInit[j].PlayerID, -1);
                }
            }   
        }

        [Test]
        public void UndoTest_ShouldUndo_CanNotUndo()
        {
            var movesRecorder = new MovesRecorder();
            var gridMapInit = new GridMock[9];
            var shouldUndo = true;
            var gameManager = new GameManagerMockUp();

            for (int i = 0; i < gridMapInit.Length; i++)
            {
                gridMapInit[i] = new GridMock();
            }
            Assert.IsFalse(gameManager.UndoLastMoves(movesRecorder, gridMapInit, shouldUndo));
        }

        [Test]
        public void UndoTest_ShouldNotUndo_CanUndo()
        {
            var movesRecorder = new MovesRecorder();
            var gridMapInit = new GridMock[9];
            var shouldUndo = false;
            var gameManager = new GameManagerMockUp();

            for (int i = 0; i < gridMapInit.Length; i++)
            {
                gridMapInit[i] = new GridMock();
                movesRecorder.movesRecorder.Push(i);
            }
            Assert.IsFalse(gameManager.UndoLastMoves(movesRecorder, gridMapInit, shouldUndo));
        }
    }
}
