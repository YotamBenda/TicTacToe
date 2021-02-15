using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Grid is set on each of the grids on the board, managing it's data and assigning X/O images according to CorrentPlayer.
/// <param name="PlayerID"> when set to -1 = neutral.</param>
/// </summary>
public class Grid : MonoBehaviour
{
    public int SlotNum { get; set; }
    public int PlayerID { get; set; }

    private Button _button;
    private GameManager gameManager; 

    [Header("Scriptable Objects")]
    [SerializeField] private MovesRecorder movesRecord;
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private PlayerData[] _playersDataNew;
    [SerializeField] private Sprite _neutralImage;
    [SerializeField] private Sprite _hintImage;


    private void Awake()
    {
        _button = GetComponent<Button>();
        PlayerID = -1;
    }

    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
    }

    /// <summary>
    /// SetGridImage() sets to image on the grid according to CorrentPlayer, pushes the slotNum assigned from GameManager into MovesRecorder.
    /// </summary>
    public void SetGridImage()
    {
        PlayerID = Players.CurrentPlayer;
        _button.image.sprite = _playersDataNew[PlayerID].PlayerImage;
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
        _button.image.sprite = _neutralImage;
        _button.interactable = true;
        PlayerID = -1;
    }

    public void ShowHint()
    {
        _button.image.sprite = _hintImage;
    }

    public void RemoveHint()
    {
        if (_button.image.sprite = _hintImage)
        {
            _button.image.sprite = _neutralImage;
        }
    }
}
