using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (CheckIfPlayerVSComputer())
        {
            _shouldUndo = true;
            _shouldHint = true;
        }
        NextTurn();
    }

    public void NextTurn() 
    {
        var currPlayer = Players.CurrentPlayer;
        if (_playersData[currPlayer].isComputer)
        {
            StartCoroutine("PlaceComputersTurn");
        }
        else if (_shouldHint)
        {
            CheckForHint(true);
        }
        CheckIfGameEnded();
    } 

    // used an Enumerator to give the computers turn delay before setting a move.
    private IEnumerator PlaceComputersTurn() 
    {
        yield return new WaitForSeconds(_playersData[0].ComputersDelay);
        _gridMapInit[CheckForHint(false)].SetGridImage();
        CheckIfGameEnded();
    }

    public bool CheckIfGameEnded()
    {
        var currTurn = Players.CurrentPlayer;
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
            _gridMapInit[random].ShowHint();
        }
        return usableSlots[random];
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
        else if (lastMove.Count == 1)
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
