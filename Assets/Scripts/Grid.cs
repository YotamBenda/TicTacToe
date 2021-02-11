﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public int SlotNum { get; set; }
    public int currImage { get; set; }

    private Button _button;
    private GameManager gameManager; // ctor? //event?

    [Header("Scriptable Objects")]
    [SerializeField] private Players players;
    [SerializeField] private MovesRecorder movesRecord;


    private void Awake()
    {
        _button = GetComponent<Button>();
        currImage = 2;
    }
    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
    }

    public void SetGridImage()
    {
        _button.image.sprite = players.playerImage[players.playersTurn];
        _button.interactable = false;
        currImage = players.playersTurn;
        movesRecord.movesRecorder.Push(SlotNum);
        gameManager.NextTurn();
    }



}