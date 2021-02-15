using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadAssetBundles : MonoBehaviour
{
    [Header("Assets to replace")]
    [SerializeField] private PlayerData[] _playerData = new PlayerData[2];
    [SerializeField] private GameData _gameData;
    private void Start()
    {
        LoadAssetBundle();
    }
    public void LoadAssetBundle()
    {
        var assetName = "ExPrefab";
        var bundleName = "111";
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
        }
        //_playerData[0].PlayerImage = myLoadedAssetBundle.LoadAsset<Sprite>("X_Image");
        //_playerData[1].PlayerImage = myLoadedAssetBundle.LoadAsset<Sprite>("HintImage");
        //_gameData.Background.sprite = myLoadedAssetBundle.LoadAsset<Sprite>("Background");

        var asset = myLoadedAssetBundle.LoadAsset<Sprite>(assetName);
        Instantiate(asset);
        myLoadedAssetBundle.Unload(false);
    }
}
