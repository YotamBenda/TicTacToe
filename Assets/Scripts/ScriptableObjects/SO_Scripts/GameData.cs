using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Keeps the AssetBundle to load to the game, and also the Background from the loaded AssetBundle.
/// </summary>
[CreateAssetMenu(menuName = "Variables/GameData", order = 4)]
public class GameData : ScriptableObject
{
    public string AssetBundleToLoad;
    public Image Background;
}
