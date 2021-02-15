using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Imitates Grid's function in order to use in Undo test.
/// </summary>
public class GridMock : MonoBehaviour
{
    public int PlayerID = 0;
    public void ResetGridSlot()
    {
        PlayerID = -1;
    }
}
