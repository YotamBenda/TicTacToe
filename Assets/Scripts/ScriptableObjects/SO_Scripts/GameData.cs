using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Variables/GameData", order = 4)]
public class GameData : ScriptableObject
{
    public string AssetBundleToLoad;
    public Image Background;
}
