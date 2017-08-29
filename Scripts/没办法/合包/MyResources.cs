using UnityEngine;
using WZK;

public class MyResources:Singleton<MyResources>
{
    
    public ResourcesScriptableObject _resourcesScriptableObject;
    public T Load<T>(string path) where T : Object
    {
        path = "Assets/Resources/" + path;
        Debug.Log(path);
        return (T)_resourcesScriptableObject.GetObject(path);
    }
}
