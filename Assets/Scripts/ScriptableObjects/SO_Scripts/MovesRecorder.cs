using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/MovesRecorder", order = 2)]

public class MovesRecorder : ScriptableObject
{
    public Stack<int> movesRecorder = new Stack<int>();

}
