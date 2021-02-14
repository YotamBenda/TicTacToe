using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class CreateAssetBundles : EditorWindow
{
    Sprite X_Image;
    Sprite O_Image;
    Sprite _background;
    string _assetBundleName;

    [MenuItem("Window/CreateAssetBundle")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CreateAssetBundles));
    }
    void OnGUI()
    {
        GUILayout.Label("X Image", EditorStyles.boldLabel);
        X_Image =  EditorGUILayout.ObjectField(X_Image, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight)) as Sprite;

        GUILayout.Label("O Image", EditorStyles.boldLabel);
        O_Image = EditorGUILayout.ObjectField(O_Image, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight)) as Sprite;

        GUILayout.Label("Background", EditorStyles.boldLabel);
        _background =  EditorGUILayout.ObjectField(_background, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight)) as Sprite;

        _assetBundleName = EditorGUILayout.TextField("AssetBundle Name", _assetBundleName);

        void BuildAllAssetBundles()
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }
            BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows);
        }
        if(GUILayout.Button("Build AssetBundle"))
        {
            BuildAllAssetBundles();
            string X_Image_assetPath = AssetDatabase.GetAssetPath(X_Image);
            string O_Image_assetPath = AssetDatabase.GetAssetPath(O_Image);
            string BG_assetPath = AssetDatabase.GetAssetPath(_background);
            
            AssetImporter.GetAtPath(X_Image_assetPath).SetAssetBundleNameAndVariant(_assetBundleName, "");
            AssetImporter.GetAtPath(O_Image_assetPath).SetAssetBundleNameAndVariant(_assetBundleName, "");
            AssetImporter.GetAtPath(BG_assetPath).SetAssetBundleNameAndVariant(_assetBundleName, "");
        }

    }
}
