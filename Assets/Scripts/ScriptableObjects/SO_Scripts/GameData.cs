using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Keeps the AssetBundle to load to the game.
/// </summary>
[CreateAssetMenu(menuName = "Variables/GameData", order = 4)]
public class GameData : ScriptableObject
{
    public string AssetBundleToLoad;
    public Sprite[] _imagesStock = new Sprite[2];

}
