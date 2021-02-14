using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private PlayerData[] _playersData;

    [Header("UI Menus")]
    [SerializeField] private GameObject _gameEndMenu;
    [SerializeField] private GameObject _gamePauseMenu;
    [SerializeField] private Sprite[] _playersImageUI;

    private Sprite[] _imageStock = new Sprite[2];

    private void Start()
    {
        
    }
    public void EndGame()
    {
        _gameEndMenu.SetActive(true);
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
            _playersImageUI[i] = _playersData[i].PlayerImage;
        }
    }
}
