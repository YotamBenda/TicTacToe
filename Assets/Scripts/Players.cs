using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Players : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private PlayersData _playersData;
    [SerializeField] private GameEvent _gameEvent;

    public int CurrentPlayer { get; set; }
    private int _playsCounter = 1;
    private bool _playerVsComputer;

    private void Awake()
    {
        CurrentPlayer = _playersData.PlayerImgToUse;
        CheckGameMode();
    }
    public void SetCurrentPlayer()
    {
        var check = _playsCounter % 2 == 0 ? CurrentPlayer = 0 : CurrentPlayer = 1;
        _playersData.PlayerImgToUse = CurrentPlayer;
        if (_playerVsComputer)
        {
            _playersData.ComputersTurn = !_playersData.ComputersTurn;
        }
        _playsCounter++;
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
                _playerVsComputer = true;
                break;

            case 2:
                _playersData.ComputersTurn = true;
                break;
        }
    }

    public void AssignPlayersInRandom()
    {
        if (_playerVsComputer)
        {
            _playersData.ComputersTurn = (Random.value > 0.5f);
        }
        else if (Random.value > 0.5f)
        {
            _playersData.PlayersTurnsOrder = 0; //TODO
        }
    }

    public void EndGame()
    {
        _playersData.PlayerImgToUse = 0;
        _playsCounter = 1;
        //add UI that tells which player X/O
    }
}
