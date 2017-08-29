using UnityEngine;
using WZK;

public class MyResources:WZK.Singleton<MyResources>
{
    public ResourcesScriptableObject _resourcesScriptableObject;
    public T Load<T>(string path) where T : Object
    {
        Debug.Log("--------"+path);
        return Resources.Load<T>(path);
        //path = "Assets/Resources/" + path;
        //Debug.Log(path);
        //return (T)_resourcesScriptableObject.GetObject(path);
    }
}
