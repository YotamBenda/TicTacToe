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
                Debug.Log("game has ended!, the winner is player" + (turn + 1));
                return;
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
        for (int i = 0; i < 8; i++)
        {
            //Debug.Log("******************************** I IS+ " + i);
            isCorrect = true;
            for (int j = 0; j < 3; j++)
            {
                //Debug.Log("******************************** J IS + " + j);
                var temp = solutions.AllSolutions[i, j];
                if(gridMap[temp].CurrImg != lastTurn)
                {
                    //Debug.Log("### i got out");
                    isCorrect = false;
                    break;
                }
            }
            if(isCorrect)
            {
                Debug.Log("i left in the correct option");
                return isCorrect;
            }
        }
        return isCorrect;
    }
}
