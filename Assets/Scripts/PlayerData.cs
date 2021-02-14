using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/PlayerData", order = 3)]

public class PlayerData : ScriptableObject
{
    public Sprite PlayerImage;
    public int PlayerID;
    public bool isComputer;
    public float ComputersDelay = 2f;
}
