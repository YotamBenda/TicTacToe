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
        CurrentPlayer = _playersData.PlayersTurn;
    }
    public void ChangePlayer()
    {
        var check = _currPlay % 2 == 0 ? CurrentPlayer = 0 : CurrentPlayer = 1;
        _currPlay++;
        _playersData.PlayersTurn = CurrentPlayer;
    }
}
