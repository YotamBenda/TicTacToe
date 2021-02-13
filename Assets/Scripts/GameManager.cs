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
    [SerializeField] private Solutions _solutions;
    [SerializeField] private Grid[] _gridMapInit;

    private int gameMode;
    private bool _shouldSwitchPlayerComputer = false;
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
        if (_shouldSwitchPlayerComputer)
        {
            _playersData.ComputersTurn = !_playersData.ComputersTurn;
        }
        CheckIfGameEnded();
    }

    public void CheckIfGameEnded()
    {
        var currTurn = _playersData.PlayerID;
        if (_movesRecord.movesRecorder.Count > 4 && _solutions.CheckIfGameWon(_gridMap)) // one of the players won.
        {
            _gameEvent.FireEvent("EndGame");
            InitScriptableObjects();
            Debug.Log("game has ended!, the winner is player" + (currTurn + 1));
            Time.timeScale = 0;
            Debug.Log("time scale is " + Time.timeScale);
            return;
        }
        if (_movesRecord.movesRecorder.Count == _gridMapInit.Length) // draw.
        {
            _gameEvent.FireEvent("EndGame");
            InitScriptableObjects();
            Debug.Log("game has ended with a draw!");
            Time.timeScale = 0;
            return;
        }
        _gameEvent.FireEvent("SetCurrentPlayer");
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
    
    public void RestartGame()
    {
        Time.timeScale = 1;
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
                _gridMap[i, j] = _gridMapInit[slotNum];
                _gridMap[i, j].SlotNum = slotNum;
                slotNum++;
            }
        }
    }
}
