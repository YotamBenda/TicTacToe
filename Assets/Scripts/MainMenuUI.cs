using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// MainMenuUI manages all the MainMenu scene.
/// </summary>
public class MainMenuUI : MonoBehaviour
{
    [Header("Game Attribues")]
    [SerializeField] private PlayerData[] playersData = new PlayerData[2];
    [SerializeField] private GameData gameData;
    [SerializeField] private InputField assetNameInput;

    /// <summary>
    /// Setting the game mode according to input in MainMenu.
    /// case 1: Player1 will be Player, Player2 is Computer.
    /// </summary>
    /// <param name="gameMode"></param>
    public void SetGameMode(int gameMode)
    {
        switch (gameMode)
        {
            case 0:
                foreach(PlayerData player in playersData)
                {
                    player.isComputer = false;
                }
                break;
            case 1:
                playersData[0].isComputer = false;
                playersData[1].isComputer = true;
                break;
            case 2:
                foreach(PlayerData player in playersData)
                {
                    player.isComputer = true;
                }
                break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadAssetBundle()
    {
        gameData.AssetBundleToLoad = assetNameInput.text;
    }
}
