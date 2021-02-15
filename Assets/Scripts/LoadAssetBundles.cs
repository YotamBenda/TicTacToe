using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

/// <summary>
/// Loading the asset bundle requested in the Reskin button on MainMenu.
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
        //_playerData[0].PlayerImage = myLoadedAssetBundle.LoadAsset<Sprite>("X_Image");
        //_playerData[1].PlayerImage = myLoadedAssetBundle.LoadAsset<Sprite>("HintImage");
        //_gameData.Background.sprite = myLoadedAssetBundle.LoadAsset<Sprite>("Background");

        //var asset = myLoadedAssetBundle.LoadAsset(_assetName);
        //Instantiate(asset);
        for (int i = 0; i < 2; i++)
        {
            var asset = myLoadedAssetBundle.LoadAsset(_assetNames[i]);
            var instantinate =  Instantiate(asset) as GameObject;
            _playerData[i].PlayerImage = instantinate.gameObject.GetComponent<Image>().sprite;
        }

        var bg = myLoadedAssetBundle.LoadAsset(_assetNames[2]);
        var bgInstantinate = Instantiate(bg) as GameObject;
        _background.sprite = bgInstantinate.gameObject.GetComponent<Image>().sprite;

        myLoadedAssetBundle.Unload(false);
    }
}
