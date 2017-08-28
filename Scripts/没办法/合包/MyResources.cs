using UnityEngine;
using WZK;

public class MyResources
{
    public static string _resourcesListName = "合包资源列表";
    public static AssetBundle _assetBundle;
    public static ResourcesScriptableObject _resourcesScriptableObject;
    public static T Load<T>(string path) where T : Object
    {
        path = "Assets/合包资源/" + path;
        Debug.Log(path);
        return (T)_resourcesScriptableObject.GetObject(path);
    }
}
