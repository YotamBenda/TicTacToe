using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/PlayersData", order = 1)]
public class PlayersData : ScriptableObject
{
    public Sprite[] PlayerImage;
    public int PlayerImgToUse = 0;
    public int PlayersTurnsOrder;
    public bool[] GameModes = new bool[3];
    public bool ComputersTurn;
    public float ComputersDelay = 2f;
}
