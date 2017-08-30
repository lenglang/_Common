using System.Collections.Generic;
using UnityEngine;
using WZK;

public class MyResources:WZK.Singleton<MyResources>
{
    public ResourcesScriptableObject _resourcesScriptableObject;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public T Load<T>(string path) where T : Object
    {
        Debug.Log("--------"+path);
        //return Resources.Load<T>(path);
        path = "Assets/Resources/" + path;
        return (T)_resourcesScriptableObject.GetObject(path);
    }
    public T[] LoadAll<T>(string path) where T : Object
    {
        Debug.Log("all--------" + path);
        List<T> list = new List<T>();
        for (int i = 0; i < _resourcesScriptableObject._objectList.Count; i++)
        {
            if (_resourcesScriptableObject._objectList[i]._assetPath.Contains(path))
            {
                Debug.Log("6666up--------" + path);
                list.Add((T)_resourcesScriptableObject._objectList[i]._object);
                Debug.Log("6666down--------" + path);
            }
        }
        T[] t = new T[list.Count];
        for (int i = 0; i < list.Count; i++)
        {
            t[i] = list[i];
        }
        Debug.Log(t.Length + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        return t;
    }
}
