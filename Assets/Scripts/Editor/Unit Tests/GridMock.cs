using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMock : MonoBehaviour
{
    public int PlayerID = 0;
    public void ResetGridSlot()
    {
        PlayerID = -1;
    }
}
