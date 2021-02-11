using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public int SlotNum { get; set; }
    public int PlayersNum { get; set; }

    private Button _button;
    private GameManager gameManager; // ctor? //event?

    [Header("Scriptable Objects")]
    [SerializeField] private Players players;
    [SerializeField] private MovesRecorder movesRecord;
    [SerializeField] private GameEvent _gameEvent;


    private void Awake()
    {
        _button = GetComponent<Button>();
        PlayersNum = -1;
    }
    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
    }

    public void SetGridImage()
    {
        _button.image.sprite = players.playerImage[players.playersTurn];
        _button.interactable = false;
        PlayersNum = players.playersTurn;
        movesRecord.movesRecorder.Push(SlotNum);
        _gameEvent.FireEvent("NextTurn");
    }
    public void EndGame()
    {
        _button.image.sprite = players.playerImage[2]; //resets to neutral
    }

    private void InitGameEvents()
    {
        _gameEvent.OnEndGame += EndGame;
    }


}
