using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

/// <summary>
/// Loading the asset bundle requested in the Reskin button on MainMenu.
/// To load assets into the scene - Place the prefabs in Resources folder, and fill the _assetNames string[] in the inspector
/// </summary>
public class LoadAssetBundles : MonoBehaviour
{
    [Header("Assets to replace")]
    [SerializeField] private PlayerData[] _playerData = new PlayerData[2];
    [SerializeField] private GameData _gameData;
    [SerializeField] private Image _background;

    [SerializeField] private string[] _assetNames;
    
    private void Awake()
    {
        LoadAssetBundle();
    }

    public void LoadAssetBundle()
    {
        var bundleName = _gameData.AssetBundleToLoad;
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
        }

        for (int i = 0; i < 2; i++)
        {
            var asset = myLoadedAssetBundle.LoadAsset(_assetNames[i]);
            var instantiate = Resources.Load(asset.name) as GameObject;
            //var instantinate =  Instantiate(asset) as GameObject;
            var loadedImage = instantiate.GetComponent<SpriteRenderer>();
            _playerData[i].PlayerImage = loadedImage.sprite;
            _gameData._imagesStock[i] = loadedImage.sprite;
        }

        var bg = myLoadedAssetBundle.LoadAsset(_assetNames[2]);
        var bgInstantinate = Resources.Load(bg.name) as GameObject;
        _background.sprite = bgInstantinate.gameObject.GetComponent<SpriteRenderer>().sprite;

        myLoadedAssetBundle.Unload(false);
    }
}
