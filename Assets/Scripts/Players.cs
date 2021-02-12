using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Players : MonoBehaviour
{
    [SerializeField] private PlayersData _playersData;
    public int CurrentPlayer { get; set; }
    private int _currPlay = 1;
    private void Awake()
    {
        CurrentPlayer = _playersData.PlayerID;
    }
    public void ChangePlayer()
    {
        var check = _currPlay % 2 == 0 ? CurrentPlayer = 0 : CurrentPlayer = 1;
        _currPlay++;
        _playersData.PlayerID = CurrentPlayer;
    }
    public void EndGame()
    {
        _playersData.PlayerID = 0;
        //add UI that tells which player X/O
    }
}
