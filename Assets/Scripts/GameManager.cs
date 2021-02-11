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
    [SerializeField] private List<Grid> gridMap = new List<Grid>();

    private bool isCorrect;

    private void Awake()
    {
        InitScriptableObjects();
        InitGridsNum();
        InitGameEvents();
    }

    public void NextTurn()
    {
        var turn = _playersData.PlayersTurn;
        if (_movesRecord.movesRecorder.Count > 4 && CheckIfGameWon(turn))
        {
            _gameEvent.FireEvent("EndGame");
            Debug.Log("game has ended!, the winner is player" + (turn + 1));
            return;
        }
   }

    public bool CheckIfGameWon(int lastTurn)
    {
        for (int i = 0; i < 8; i++)
        {
            isCorrect = true;
            for (int j = 0; j < 3; j++)
            {
                var temp = solutions.AllSolutions[i, j];
                if(gridMap[temp].PlayersNum != lastTurn)
                {
                    isCorrect = false;
                    break;
                }
            }
            if(isCorrect)
            {
                break;
            }
        }
        return isCorrect;
    }

    private void InitScriptableObjects()
    {
        _movesRecord.movesRecorder.Clear();
        _playersData.PlayersTurn = 0;
    }
    
    private void InitGridsNum()
    {
        var slotNum = 0;
        foreach (var grid in gridMap)
        {
            grid/*.GetComponent<Grid>()*/.SetGameManager(this);
            grid.SlotNum = slotNum;
            slotNum++;
        }
    }

    private void InitGameEvents()
    {
        _gameEvent.OnNextTurn += NextTurn;
    }
}
