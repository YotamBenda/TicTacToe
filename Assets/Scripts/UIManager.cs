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
    [SerializeField] private Image[] _playersImageUI;

    [Header("AssetBundle Setup")]
    [SerializeField] private LoadAssetBundles _assetBundleLoader;

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

    public void LoadAssetBundle(string bundleName)
    {
        _assetBundleLoader.LoadAssetBundle(bundleName);
    }

    private void AssignXOImages()
    {
        for (int i = 0; i < _playersImageUI.Length; i++)
        {
            _playersImageUI[i].sprite = _playersData[i].PlayerImage;
        }
    }


}
