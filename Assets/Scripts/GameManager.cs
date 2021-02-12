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
   }

    private void InitScriptableObjects()
    {
        _movesRecord.movesRecorder.Clear();
        _playersData.PlayerID = 0;
    }
    
    private void InitGridsNum()
    {
        var slotNum = 0;
        foreach (var grid in gridMap)
        {
            grid.SetGameManager(this);
            grid.SlotNum = slotNum;
            slotNum++;
        }
    }
}
