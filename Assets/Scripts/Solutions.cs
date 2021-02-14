using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solutions : MonoBehaviour
{   
    [Header("Scriptable Objects")]
    [SerializeField] private GameEvent _gameEvent;

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
