using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
namespace WZK
{
    /// <summary>
    /// AssetBundle编辑器打包扩展
    /// </summary>
    public class AssetBundleEditor : Editor
    {

        [MenuItem("AssetBundle/打包选中文件为一个AssetBundle(可多选)-压缩")]

        static void BulidCompressedAssetBundle()
        {
            BuildAssetBundle();
        }
        [MenuItem("AssetBundle/打包选中文件为一个AssetBundle(可多选)-不压缩")]
        static void BulidUncompressedAssetBundle()
        {
            BuildAssetBundle(false);
        }
        static void BuildAssetBundle(bool IscompressedAssetBundle=true)
        {
            if (Selection.objects.Length == 0)
                return;
            for (int i = 0; i < Selection.objects.Length; i++)
            {
                Build(Selection.objects[i], IscompressedAssetBundle);
            }
            Debug.LogError("共打包" + Selection.objects.Length + "个AssetBundle");
        }


        static void Build(Object obj, bool IscompressedAssetBundle=true)
        {
            AssetBundleBuild assetBundleBuild = new AssetBundleBuild();
            assetBundleBuild = new AssetBundleBuild();
            assetBundleBuild.assetNames = new string[Selection.objects.Length];
            assetBundleBuild.assetNames[0] = AssetDatabase.GetAssetPath(obj);
            string directoryName = Path.GetDirectoryName(assetBundleBuild.assetNames[0]);
            assetBundleBuild.assetBundleName = Path.GetFileName(assetBundleBuild.assetNames[0]) + ".unity3d";

#if UNITY_ANDROID
            directoryName += "/Android";
#endif
#if UNITY_IOS
        directoryName += "/iOS";
#endif
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
#if UNITY_ANDROID
            if(IscompressedAssetBundle){BuildPipelineHelper.BuildAssetBundles(directoryName, new AssetBundleBuild[] { assetBundleBuild }, BuildAssetBundleOptions.None, BuildTarget.Android);}
            else{BuildPipelineHelper.BuildAssetBundles(directoryName, new AssetBundleBuild[] { assetBundleBuild }, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.Android);}
#endif

#if UNITY_IOS
            if (IscompressedAssetBundle) { BuildPipelineHelper.BuildAssetBundles(directoryName, new AssetBundleBuild[] { assetBundleBuild }, BuildAssetBundleOptions.None, BuildTarget.iOS); }
            else { BuildPipelineHelper.BuildAssetBundles(directoryName, new AssetBundleBuild[] { assetBundleBuild }, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.iOS); }
#endif
        }
    }
}
