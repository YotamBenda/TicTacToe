using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Players class is in charge of which player's turn is it, and assigning X / O images randomly (X always 1st)
/// When playing PlayerVSComputer game mode, _playersData[0] will be the player, [1] will be PC.
/// </summary>
public class Players : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private PlayerData[] _playersData;
    [SerializeField] private GameData _gameData;

    
    [SerializeField] private Sprite[] _imagesStock = new Sprite[2];
    public static int CurrentPlayer { get; set; }
    private int _playsCounter = 0;

    private void Awake()
    {
        CurrentPlayer = 0;
    }

    public void SetNextPlayer()
    {
        _playsCounter++;
        var check = _playsCounter % 2 == 0 ? CurrentPlayer = 0 : CurrentPlayer = 1;
        _gameEvent.FireEvent("NextTurn");
    }

    /// <summary>
    /// Assigning the X / O images randomly, changing CurrentPlayer so X will always start.
    /// </summary>
    public void AssignPlayersInRandom()
    {
        var check = (Random.Range(0, 1));
        _playersData[0].PlayerImage = _gameData._imagesStock[check];

        if (check == 0)
        {
            _playersData[1].PlayerImage = _gameData._imagesStock[1];
            CurrentPlayer = 0;
            _playsCounter = 0;
        }
        else
        {
            _playersData[1].PlayerImage = _gameData._imagesStock[0];
            CurrentPlayer = 1;
            _playsCounter = 1;
        }
    }
}
