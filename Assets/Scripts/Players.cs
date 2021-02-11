using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Variables/Players", order = 1)]
public class Players : ScriptableObject
{

    public Sprite[] playerImage;
    public int playersTurn = 0;

    public void ChangeTurns()
    {
        if(playersTurn == 0)
        {
            playersTurn++;
        }
        else
        {
            playersTurn--;
        }
    }
}
