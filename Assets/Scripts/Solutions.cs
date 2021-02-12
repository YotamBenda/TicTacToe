using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solutions : MonoBehaviour
{
    public Solutions()
    {
        AllSolutions = new int[8,3];
    }
    
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private PlayersData _playerData;
    public int[,] AllSolutions { get; }

    private void Awake()
    {
        InitSolutionsRaw();
    }
    private void InitSolutionsRaw()
    {
        AllSolutions[0, 0] = 0;
        AllSolutions[0, 1] = 1;
        AllSolutions[0, 2] = 2;

        AllSolutions[1, 0] = 3;
        AllSolutions[1, 1] = 4;
        AllSolutions[1, 2] = 5;

        AllSolutions[2, 0] = 6;
        AllSolutions[2, 1] = 7;
        AllSolutions[2, 2] = 8;

        AllSolutions[3, 0] = 0;
        AllSolutions[3, 1] = 3;
        AllSolutions[3, 2] = 6;

        AllSolutions[4, 0] = 1;
        AllSolutions[4, 1] = 4;
        AllSolutions[4, 2] = 7;

        AllSolutions[5, 0] = 2;
        AllSolutions[5, 1] = 5;
        AllSolutions[5, 2] = 8;

        AllSolutions[6, 0] = 0;
        AllSolutions[6, 1] = 4;
        AllSolutions[6, 2] = 8;

        AllSolutions[7, 0] = 2;
        AllSolutions[7, 1] = 4;
        AllSolutions[7, 2] = 6;
    }

    public bool CheckIfGameWon(List<Grid> gridMap)
    {
        return (CheckRows(gridMap) || CheckColumns(gridMap));
    }

    private bool CheckRows(List<Grid> gridMap)
    {
        var isCorrect = false;
        for (int i = 0; i < 9 && !isCorrect; i += 3)
        {
            for (int j = 0; j < 2; j++)
            {
                if (gridMap[i + j].PlayerID != gridMap[i + j + 1].PlayerID ||
                   (gridMap[i + j].PlayerID == -1 || gridMap[i + j + 1].PlayerID == -1))
                {
                    isCorrect = false;
                    break;
                }
                else
                {
                    isCorrect = true;
                }
            }
        }
        return isCorrect;
    }
    private bool CheckColumns(List<Grid> gridMap)
    {
        var isCorrect = false;
        for (int i = 0; i < 2 && !isCorrect; i++)
        {
            for (int j = 0; j < 6; j+=3)
            {
                if (gridMap[i + j].PlayerID != gridMap[i + j + 3].PlayerID)
                {
                    isCorrect = false;
                    break;
                }
                else
                {
                    isCorrect = true;
                }
            }
        }
        return isCorrect;
    }
}
