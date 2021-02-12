using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/PlayersData", order = 1)]
public class PlayersData : ScriptableObject
{
    public Sprite[] PlayerImage;
    public int PlayerID = 0;
}
