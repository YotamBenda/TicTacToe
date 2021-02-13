using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;

    [Header("UI Menus")]
    [SerializeField] private GameObject _gameEndMenu;
    [SerializeField] private GameObject _gamePauseMenu;

    public void EndGame()
    {
        _gameEndMenu.SetActive(true);
    }
    public void RestartGame()
    {
        _gameEndMenu.SetActive(false);
        _gameEvent.FireEvent("AssignRandom");
        _gameEvent.FireEvent("RestartGame");
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
}
