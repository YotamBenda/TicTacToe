﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public int SlotNum { get; set; }
    public int PlayerID { get; set; }

    private Button _button;
    private GameManager gameManager; 

    [Header("Scriptable Objects")]
    [SerializeField] private PlayersData _playersData;
    [SerializeField] private MovesRecorder movesRecord;
    [SerializeField] private GameEvent _gameEvent;


    private void Awake()
    {
        _button = GetComponent<Button>();
        PlayerID = -1;
    }

    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
    }

    public void SetGridImage()
    {
        PlayerID = _playersData.PlayerImgToUse;
        _button.image.sprite = _playersData.PlayerImage[PlayerID];
        _button.interactable = false;
        movesRecord.movesRecorder.Push(SlotNum);
        if (gameManager.CheckIfGameEnded())
        {
            return;
        }
        _gameEvent.FireEvent("SetCurrentPlayer");
    }

    public void ResetGridSlot()
    {
        _button.image.sprite = _playersData.PlayerImage[2]; 
        _button.interactable = true;
        PlayerID = -1;
    }
}
