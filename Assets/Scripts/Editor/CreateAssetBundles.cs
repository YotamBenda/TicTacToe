using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

/// <summary>
/// Creating AssetBundle menu on GUI in order to create an AssetBundle and setting it to the X/O/BG sprites.
/// </summary>
public class CreateAssetBundles : EditorWindow
{
    GameObject X_Image;
    GameObject O_Image;
    GameObject Background;
    string _assetBundleName;

    [MenuItem("Window/CreateAssetBundle")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CreateAssetBundles));
    }
    void OnGUI()
    {
        GUILayout.Label("X Image", EditorStyles.boldLabel);
        X_Image =  EditorGUILayout.ObjectField(X_Image,typeof(GameObject) ,false, GUILayout.Height(EditorGUIUtility.singleLineHeight)) as GameObject;

        GUILayout.Label("O Image", EditorStyles.boldLabel);
        O_Image = EditorGUILayout.ObjectField(O_Image, typeof(GameObject), false, GUILayout.Height(EditorGUIUtility.singleLineHeight)) as GameObject;

        GUILayout.Label("Background", EditorStyles.boldLabel);
        Background =  EditorGUILayout.ObjectField(Background, typeof(GameObject), false, GUILayout.Height(EditorGUIUtility.singleLineHeight)) as GameObject;

        _assetBundleName = EditorGUILayout.TextField("AssetBundle Name", _assetBundleName);

        void BuildAllAssetBundles()
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }
            BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);
        }
        if(GUILayout.Button("Build AssetBundle"))
        {
            BuildAllAssetBundles();
            string X_Image_assetPath = AssetDatabase.GetAssetPath(X_Image);
            string O_Image_assetPath = AssetDatabase.GetAssetPath(O_Image);
            string BG_assetPath = AssetDatabase.GetAssetPath(Background);
            
            AssetImporter.GetAtPath(X_Image_assetPath).SetAssetBundleNameAndVariant(_assetBundleName, "");
            AssetImporter.GetAtPath(O_Image_assetPath).SetAssetBundleNameAndVariant(_assetBundleName, "");
            AssetImporter.GetAtPath(BG_assetPath).SetAssetBundleNameAndVariant(_assetBundleName, "");
        }
    }
}
