using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private PlayerData[] playersData = new PlayerData[2];

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
}
