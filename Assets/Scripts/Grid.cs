using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    private Button _button;
    [SerializeField] private Players players;

    private GameManager gameManager;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
        Debug.Log("gm set");
    }

    public void SetGridImage()
    {
        _button.image.sprite = players.playerImage[players.playersTurn];
        _button.interactable = false;
        gameManager.NextTurn();
    }



}
