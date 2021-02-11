using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Button> gridMap = new List<Button>();
    [SerializeField] private Players players;

    private void Start()
    {
        foreach(var grid in gridMap)
        {
            grid.GetComponent<Grid>().SetGameManager(this);
        }
        players.playersTurn = 0;
    }

    public void NextTurn()
    {
        if (players.playersTurn == 0)
        {
            players.playersTurn++;
        }
        else
        {
            players.playersTurn--;
        }
    }
}
