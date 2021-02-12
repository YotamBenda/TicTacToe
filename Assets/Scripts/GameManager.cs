using System.Collections;
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
    [SerializeField] private Solutions solutions;
    [SerializeField] private Grid[] gridMapInit;
    private Grid[,] gridMap;
    public GameManager()
    {
        gridMap = new Grid[3,3];
    }

    private void Awake()
    {
        InitScriptableObjects();
        InitGridsNum();
    }

    public void NextTurn()
    {
        var currTurn = _playersData.PlayerID;
        if (_movesRecord.movesRecorder.Count > 4 && solutions.CheckIfGameWon(gridMap))
        {
            _gameEvent.FireEvent("EndGame");
            InitScriptableObjects();
            Debug.Log("game has ended!, the winner is player" + (currTurn + 1));
            return;
        }
        if (_movesRecord.movesRecorder.Count == gridMapInit.Length)
        {
            _gameEvent.FireEvent("EndGame");
            InitScriptableObjects();
            Debug.Log("game has ended with a draw!");
        }
    }

    private void InitScriptableObjects()
    {
        _movesRecord.movesRecorder.Clear();
        _playersData.PlayerID = 0;
    }
    
    private void InitGridsNum()
    {
        var slotNum = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                gridMap[i, j] = gridMapInit[slotNum];
                gridMap[i, j].SlotNum = slotNum;
                slotNum++;
            }
        }
    }
}
