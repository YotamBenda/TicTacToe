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

    public bool CheckIfGameWon(Grid[,] gridMap)
    {
        return (CheckRows(gridMap) || CheckColumns(gridMap) || CheckDiagonals(gridMap));
    }

    private bool CheckRows(Grid[,] gridMap)
    {
        var isCorrect = false;
        for (int i = 0; i < 3 && !isCorrect; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (gridMap[j, i].PlayerID != gridMap[j + 1, i].PlayerID ||
                   (gridMap[j, i].PlayerID == -1))
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
    private bool CheckColumns(Grid[,] gridMap)
    {
        var isCorrect = false;
        for (int i = 0; i < 3 && !isCorrect; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (gridMap[i, j].PlayerID != gridMap[i, j + 1].PlayerID ||
                   (gridMap[i, j].PlayerID == -1))
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

    private bool CheckDiagonals(Grid[,] gridMap)
    {
        var isCorrect = false;
        var iInit = 0;
        var iModifier = 1;
        for (int i = 0; i < 3 && !isCorrect; i+=2)
        {
            for (int j = 0; j < 2; j++)
            {
                if (gridMap[i + iInit, j].PlayerID != gridMap[(i + iInit) + iModifier, j + 1].PlayerID ||
                   (gridMap[i + iInit, j].PlayerID == -1))
                {
                    isCorrect = false;
                    iInit = 0;
                    iModifier = -1; 
                    break;
                }
                else
                {
                    iInit += iModifier;
                    isCorrect = true;
                }
            }
        }
        return isCorrect;
    }
}
