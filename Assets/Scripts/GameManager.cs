﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Scripteable Objects")]
    [SerializeField] private PlayersData _playersData;
    [SerializeField] private MovesRecorder _movesRecord;
    [SerializeField] private GameEvent _gameEvent;

    [Header("Game Setup")]
    [SerializeField] private Solutions _solutions;
    [SerializeField] private Grid[] _gridMapInit;

    private Grid[,] _gridMap;

    public GameManager()
    {
        _gridMap = new Grid[3,3];
    }

    private void Awake()
    {
        InitScriptableObjects();
        InitGridsNum();
        //CheckGameMode();
    }
    private void Start()
    {
        NextTurn();
    }

    public void NextTurn() 
    {
        if (_playersData.ComputersTurn)
        {
            StartCoroutine("PlaceComputersTurn");
        }
        CheckIfGameEnded();
    } 

    // used an Enumerator to give the computers turn delay before setting a move.
    private IEnumerator PlaceComputersTurn() 
    {
        yield return new WaitForSeconds(_playersData.ComputersDelay);
        _gridMapInit[CheckForHint(false)].SetGridImage();
        CheckIfGameEnded();
    }

    public bool CheckIfGameEnded()
    {
        var currTurn = _playersData.PlayerImgToUse;
        if (_movesRecord.movesRecorder.Count > 4 && _solutions.CheckIfGameWon(_gridMap)) // one of the players won.
        {
            _gameEvent.FireEvent("EndGame");
            InitScriptableObjects();
            Debug.Log("game has ended!, the winner is player" + (currTurn));
            return true;
        }
        if (_movesRecord.movesRecorder.Count == _gridMapInit.Length) // draw.
        {
            _gameEvent.FireEvent("EndGame");
            InitScriptableObjects();
            Debug.Log("game has ended with a draw!");
            return true;
        }
        return false;
    }

    public int CheckForHint(bool shouldShow)
    {
        var usableSlots = new List<int>();
        int random;
        for (int i = 0; i < _gridMapInit.Length; i++)
        {
            if(_gridMapInit[i].PlayerID == -1)
            {
                usableSlots.Add(i);
            }
        }
        random = Random.Range(0, usableSlots.Count - 1);
        if (shouldShow)
        {
            Debug.Log(usableSlots[random]);
        }
        return usableSlots[random];
    }

    public void UndoLastMoves()
    {
        var lastMove = _movesRecord.movesRecorder;
        if (lastMove.Count > 0 && _playersData.GameModes[0] == false)
        {
            _gridMapInit[lastMove.Pop()].ResetGridSlot();
            _gridMapInit[lastMove.Pop()].ResetGridSlot();

        }
        if (lastMove.Count == 1)
        {
            _gridMapInit[lastMove.Pop()].ResetGridSlot();
        }
    }

    private void InitScriptableObjects()
    {
        _movesRecord.movesRecorder.Clear();
        _playersData.PlayerImgToUse = 0;
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
