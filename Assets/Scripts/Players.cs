using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Players : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private PlayerData[] _playersData;
    [SerializeField] private Sprite[] _imagesStock = new Sprite[2];

    public static int CurrentPlayer { get; set; }
    private int _playsCounter = 0;
    private bool _playerVsComputer;

    private void Awake()
    {
        CurrentPlayer = 0;
    }
    private void Start()
    {
        for (int i = 0; i < _playersData.Length; i++)
        {
             _playersData[i].PlayerImage = _imagesStock[i];
        }
    }
    public void SetNextPlayer()
    {
        _playsCounter++;
        var check = _playsCounter % 2 == 0 ? CurrentPlayer = 0 : CurrentPlayer = 1;
        _gameEvent.FireEvent("NextTurn");
    }

    public void AssignPlayersInRandom()
    {
        var check = (Random.Range(0, 1));
        _playersData[0].PlayerImage = _imagesStock[check];

        if (check == 0)
        {
            _playersData[1].PlayerImage = _imagesStock[1];
            CurrentPlayer = 0;
            _playsCounter = 0;
        }
        else
        {
            _playersData[1].PlayerImage = _imagesStock[0];
            CurrentPlayer = 1;
            _playsCounter = 1;
        }
    }
}
