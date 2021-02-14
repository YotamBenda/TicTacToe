using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private PlayersData _playersData;

    [Header("UI Menus")]
    [SerializeField] private GameObject _gameEndMenu;
    [SerializeField] private GameObject _gamePauseMenu;
    [SerializeField] private Image _player1;
    [SerializeField] private Image _player2;

    public void EndGame()
    {
        _gameEndMenu.SetActive(true);
    }
    public void RestartGame()
    {
        _gameEndMenu.SetActive(false);
        _gameEvent.FireEvent("AssignRandom");
        _gameEvent.FireEvent("RestartGame");
        RandomAssignXOImages();
    }

    public void PauseGame()
    {
        _gamePauseMenu.SetActive(true);
        _gameEvent.FireEvent("PauseGame");
    }

    public void UndoMoves()
    {
        _gameEvent.FireEvent("UndoMoves");
    }
    public void ContinueGame()
    {
        _gamePauseMenu.SetActive(false);
        _gameEvent.FireEvent("ContinueGame");
    }

    private void RandomAssignXOImages()
    {
        var XOImages = _playersData.PlayerImage;
        if (_playersData.ComputersTurn)
        {
            _player1.sprite = XOImages[1];
            _player2.sprite = XOImages[0];
        }
        else
        {
            _player1.sprite = XOImages[0];
            _player2.sprite = XOImages[1];
        }
    }
}
