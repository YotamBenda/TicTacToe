using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Scripteable Objects")]
    [SerializeField] private Players players;
    [SerializeField] private MovesRecorder movesRecord;

    [Header("Game Setup")]
    [SerializeField] private Solutions solutions;
    [SerializeField] private List<Grid> gridMap = new List<Grid>();

    private bool isCorrect;



    private void Start()
    {
        var slotNum = 0;
        movesRecord.movesRecorder.Clear();
        foreach (var grid in gridMap)
        {
            grid.GetComponent<Grid>().SetGameManager(this);
            grid.SlotNum = slotNum;
            slotNum++;
        }
        players.playersTurn = 0;
    }

    public void NextTurn()
    {
        var turn = players.playersTurn;
        if (movesRecord.movesRecorder.Count > 4)
        {
            if (CheckIfGameWon(turn))
            {
                //end game
                Debug.Log("game has ended!, the winner is player" + (turn+1));
            }
        }
        if (turn == 0)
        {
            turn++;
        }
        else
        {
            turn--;
        }
        players.playersTurn = turn;

   }

    public bool CheckIfGameWon(int lastTurn)
    {
        for (int i = 0; i < 9; i++)
        {
            isCorrect = true;
            for (int j = 0; j < 3; j++)
            {
                var temp = solutions.AllSolutions[i, j];
                if(gridMap[temp].currImage != lastTurn)
                {
                    isCorrect = false;
                }
            }
            if(isCorrect)
            {
                return isCorrect;
            }

        }
        return isCorrect;
    }
}
