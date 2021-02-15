﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class gets information from ScriptableObjects that contain data of the game state.
/// It's incharge of holding the Grids list, used to check if the game has ended, checking for possible hints and undo moves.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Scripteable Objects")]
    [SerializeField] private MovesRecorder _movesRecord;
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private PlayerData[] _playersData;

    [Header("Game Setup")]
    [SerializeField] private Solutions _solutions;
    [SerializeField] private Grid[] _gridMapInit;

    private Grid[,] _gridMap;
    private bool _shouldUndo = false;
    private bool _shouldHint = false;
    private List<Grid> usableSlots = new List<Grid>();


    public GameManager()
    {
        _gridMap = new Grid[3, 3];
    }

    private void Awake()
    {
        InitScriptableObjects();
        InitGridsNum();
    }

    private void Start()
    {
        if (CheckIfPlayerVSComputer())
        {
            _shouldUndo = true;
            _shouldHint = true;
        }
        NextTurn();
    }

    /// <summary>
    /// NextTurn checks if the current player to place on the board is a computer. if so, it triggers the PlaceComputersTurn Enumartor.
    /// The Enumerator is used in order to give the computer a delay time before placing his turn.
    /// If it's not the computer's turn, it checks for hints and displays for the player.
    /// <param _shouldHint> is false when the game mode is set to Player vs Player only. </param>
    /// </summary>
    public void NextTurn()
    {
        var currPlayer = Players.CurrentPlayer;
        if (_playersData[currPlayer].isComputer)
        {
            StartCoroutine("PlaceComputersTurn");
        }
        else if (_shouldHint)
        {
            CheckForHint(true, usableSlots, _gridMapInit);
        }
        CheckIfGameEnded();
    }

    private IEnumerator PlaceComputersTurn()
    {
        yield return new WaitForSeconds(_playersData[0].ComputersDelay);
        usableSlots[CheckForHint(false, usableSlots, _gridMapInit)].SetGridImage();
        CheckIfGameEnded();
    }

    /// <summary>
    /// CheckIfGameEnded 1st if statement checks if there were 5 moves or more && asks Solutions if game was won by one of the players
    /// 2nd if statement checks if there have been the same amount of moves as the board's amount of Grids, in which case -
    /// calls a Draw by setting CurrentPlayer to -1 (this is used by UIManager to set Draw message.
    /// </summary>
    /// <returns></returns>
    public bool CheckIfGameEnded()
    {
        var currTurn = Players.CurrentPlayer;
        if (_movesRecord.movesRecorder.Count > 4 && _solutions.CheckIfGameWon(_gridMap)) // one of the players won.
        {
            _gameEvent.FireEvent("EndGame");
            InitScriptableObjects();
            return true;
        }
        if (_movesRecord.movesRecorder.Count == _gridMapInit.Length) // draw.
        {
            Players.CurrentPlayer = -1;
            _gameEvent.FireEvent("EndGame");
            InitScriptableObjects();
            return true;
        }
        return false;
    }

    /// <summary>
    /// CheckForHint takes
    /// </summary>
    /// <param name="shouldShow"></param>
    /// <param name="usableSlots"></param>
    /// <param name="gridMap"></param>
    /// <returns></returns>
    public int CheckForHint(bool shouldShow, List<Grid> usableSlots, Grid[] gridMap)
    {
        usableSlots.Clear();
        int random;
        for (int i = 0; i < gridMap.Length; i++)
        {
            if (gridMap[i].PlayerID == -1)
            {
                usableSlots.Add(gridMap[i]);
            }
        }
        random = Random.Range(0, usableSlots.Count - 1);
        if (shouldShow)
        {
            usableSlots[random].ShowHint();
        }
        return random;
    }
    public bool CheckIfPlayerVSComputer()
    {
        var check = _playersData[1].isComputer;

        return check;
    }

    public void UndoLastMoves()
    {
        var lastMove = _movesRecord.movesRecorder;
        if (lastMove.Count > 0 && _shouldUndo)
        {
            _gridMapInit[lastMove.Pop()].ResetGridSlot();
            _gridMapInit[lastMove.Pop()].ResetGridSlot();

        }
        else if (lastMove.Count == 1 && _shouldUndo)
        {
            _gridMapInit[lastMove.Pop()].ResetGridSlot();
        }
    }

    private void InitScriptableObjects()
    {
        _movesRecord.movesRecorder.Clear();
    }


    private void InitGridsNum()
    {
        var slotNum = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _gridMap[i, j] = _gridMapInit[slotNum];
                _gridMap[i, j].SlotNum = slotNum;
                _gridMap[i, j].SetGameManager(this);
                slotNum++;
            }
        }
    }
}
