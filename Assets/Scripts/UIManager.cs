using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Managing all the Menus, UI buttons and texts.
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private PlayerData[] _playersData;
    [SerializeField] private GameData _gameData;
    [SerializeField] private TimerData _timerData;

    [Header("UI Menus and Attributes")]
    [SerializeField] private GameObject _gameEndMenu;
    [SerializeField] private GameObject _gamePauseMenu;
    [SerializeField] private Image[] _playersImageUI;
    [SerializeField] private Image _background;
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _winnerText;

    private void Update()
    {
        _timerText.text = _timerData.Timer.ToString("F0");
    }

    /// <summary>
    /// <param name = "CurrentPlayer"> is set to -1 by GameManager to call Draw.</param>
    /// </summary>
    public void EndGame()
    {
        _gameEndMenu.SetActive(true);
        if (Players.CurrentPlayer == -1)
        {
            _winnerText.text = "Game Ended in a draw!";
        }
        else
        {
            _winnerText.text = "The Winner is player " + (Players.CurrentPlayer+1).ToString();
        }
    }

    public void RestartGame()
    {
        _gameEndMenu.SetActive(false);
        _gameEvent.FireEvent("AssignRandom");
        _gameEvent.FireEvent("RestartGame");
        AssignXOImages();
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
    private void AssignXOImages()
    {
        for (int i = 0; i < _playersImageUI.Length; i++)
        {
            _playersImageUI[i].sprite = _playersData[i].PlayerImage;
        }
    }
}
