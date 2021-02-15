using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameManager controls the game state contain it's data.
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
        InitMovesRecorder();
        InitGridsNum();
    }

    private void Start()
    {
        if (ComputerIsPlaying())
        {
            _shouldUndo = true;
            _shouldHint = true;
        }
        NextTurn();
    }

    /// <summary>
    /// Setting up the next turn.
    /// plays the computer's turn if needed, activates hints, and checking if game ended.
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
    /// Checks for amount of moves and a call to Solutions passing in the gridMap.
    /// if draw, CurrentPlayer set to -1 for UIElement to call the Draw message
    /// </summary>
    /// <returns></returns>
    public bool CheckIfGameEnded()
    {
        if (_movesRecord.movesRecorder.Count > 4 && _solutions.CheckIfGameWon(_gridMap)) // one of the players won.
        {
            _gameEvent.FireEvent("EndGame");
            InitMovesRecorder();
            return true;
        }
        if (_movesRecord.movesRecorder.Count == _gridMapInit.Length) // draw.
        {
            Players.CurrentPlayer = -1;
            _gameEvent.FireEvent("EndGame");
            InitMovesRecorder();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checking the gridMap to find empty grids, picks one in random, and offers it as a hint.
    /// it also used in placing the computer's turn.
    /// </summary>
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

    /// <summary>
    /// Returns a bool in order to determine if undo and hint funtions should activate
    /// </summary>
    public bool ComputerIsPlaying()
    {
        var check = _playersData[1].isComputer;

        return check;
    }

    /// <summary>
    /// Checks for the last 2 grids that've been placed, and reset in the gridMap
    /// </summary>
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

    /// <summary>
    /// Resets the stack keeping last moves
    /// </summary>
    private void InitMovesRecorder()
    {
        _movesRecord.movesRecorder.Clear();
    }

    /// <summary>
    /// Takes the grid placed through inspector and saves it in a 2d array for Solutions functions.
    /// </summary>
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
