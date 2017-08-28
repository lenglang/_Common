using UnityEngine;
using WZK;
using UnityEngine.SceneManagement;
using System;

public class ResourcesTest : MonoBehaviour {
	void Start ()
    {
       AssetBundleManager.Instance.Load(Application.persistentDataPath + "/" + "资源序列化.unity3d",OnComplete);
	}
    /// <summary>
    /// 完成加载
    /// </summary>
    /// <param name="obj"></param>
    private void OnComplete(AssetBundle obj)
    {
        MyResources._assetBundle = obj;
        Debug.Log("完成加载");
        AssetBundleRequest abr= obj.LoadAssetAsync("资源序列化");
        this.InvokeWaitForYieldInstruction<AssetBundleRequest>(InitComplete, abr);
       
    }

    private void InitComplete(AssetBundleRequest abr)
    {
        MyResources._resourcesScriptableObject = abr.asset as ResourcesScriptableObject;

        MyResources.Load<GameObject>("Prefabs/动作/通用");
        SceneManager.LoadScene("化妆间");
    }
}
