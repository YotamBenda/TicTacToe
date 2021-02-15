using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
