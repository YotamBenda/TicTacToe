using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Players : MonoBehaviour
{
    [SerializeField] private PlayersData _playersData;
    [SerializeField] private GameEvent _gameEvent;
    public int CurrentPlayer { get; set; }
    private int _currPlay = 1;
    private bool _shouldSwitchPlayerComputer;

    private void Awake()
    {
        CurrentPlayer = _playersData.PlayerID;
        CheckGameMode();
    }
    public void SetCurrentPlayer()
    {
        var check = _currPlay % 2 == 0 ? CurrentPlayer = 0 : CurrentPlayer = 1;
        _currPlay++;
        _playersData.PlayerID = CurrentPlayer;
        if (_shouldSwitchPlayerComputer)
        {
            _playersData.ComputersTurn = !_playersData.ComputersTurn;
        }
        _gameEvent.FireEvent("NextTurn");
    }

    public void CheckGameMode()
    {
        var gameModes = _playersData.GameModes;
        var index = 0;
        for (int i = 0; i < gameModes.Length; i++)
        {
            if (gameModes[i])
            {
                index = i;
                break;
            }
        }
        switch (index)
        {
            case 0:
                _playersData.ComputersTurn = false;
                break;

            case 1:
                _shouldSwitchPlayerComputer = true;
                break;

            case 2:
                _playersData.ComputersTurn = true;
                break;
        }
    }

    public void EndGame()
    {
        _playersData.PlayerID = 0;
        _currPlay = 1;
        //add UI that tells which player X/O
    }
}
