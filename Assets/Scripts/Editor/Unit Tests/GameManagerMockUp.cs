using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Imitates GameManager's functions in order to use in Win/Lose/Draw and Undo Unit Tests.
/// </summary>
public class GameManagerMockUp : MonoBehaviour
{
    public bool CheckIfGameEnded(MovesRecorder movesRecord, Solutions solutions, Grid[,] gridMap, Grid[] gridMapInit ,GameEvent gameEvent)
    {
        var currTurn = Players.CurrentPlayer;
        if (movesRecord.movesRecorder.Count > 4 && solutions.CheckIfGameWon(gridMap)) // one of the players won.
        {
            gameEvent.FireEvent("EndGame");
            Debug.Log("game has ended!, the winner is player" + (currTurn));
            return true;
        }
        if (movesRecord.movesRecorder.Count == gridMapInit.Length) // draw.
        {
            gameEvent.FireEvent("EndGame");
            Debug.Log("game has ended with a draw!");
            return true;
        }
        return false;
    }

    public bool UndoLastMoves(MovesRecorder movesRecorder, GridMock[] gridMapInit, bool shouldUndo)
    {
        var lastMove = movesRecorder.movesRecorder;
        var undoSucceded = false;
        if (lastMove.Count > 0 && shouldUndo)
        {
            gridMapInit[lastMove.Pop()].ResetGridSlot();
            gridMapInit[lastMove.Pop()].ResetGridSlot();
            undoSucceded = true;
        }
        else if (lastMove.Count == 1 && shouldUndo)
        {
            gridMapInit[lastMove.Pop()].ResetGridSlot();
            undoSucceded = true;
        }
        return undoSucceded;
    }
}
