using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solutions : MonoBehaviour
{

public Solutions()
    {
        AllSolutions = new int[9,3];
    }
    public int[,] AllSolutions { get; }

    private void Awake()
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
}
