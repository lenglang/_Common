using System;
using System.Collections.Generic;
using UnityEngine;
using WZK;

public class MyResources:WZK.Singleton<MyResources>
{
    public ResourcesScriptableObject _resourcesScriptableObject;
    public List<Sprite> _spriteList = new List<Sprite>();
    public List<Texture> _textureList = new List<Texture>();
    protected override void Awake()
    {
        base.Awake();
    }
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        Debug.Log("--------" + path);
        path = "Assets/合包资源/" + path;
        return (T)_resourcesScriptableObject.GetObject(path);
    }
    public Sprite LoadSprite(string path)
    {
        Debug.Log("++++++++" + path);
        string name = path.Substring(path.LastIndexOf("/")+1);
        Debug.Log(name);
        return _spriteList.Find(n => n.name == name);
    }
    public Texture LoadTexture(string path)
    {
        Debug.Log("主题" + path);
        string name = path.Substring(path.LastIndexOf("/") + 1);
        return _textureList.Find(n => n.name == name);
    }
    public T[] LoadAll<T>(string path) where T : UnityEngine.Object
    {
        Debug.Log("图集" + path);
        List<T> list = new List<T>();
        for (int i = 0; i < _resourcesScriptableObject._objectList.Count; i++)
        {
            if (_resourcesScriptableObject._objectList[i]._assetPath.Contains(path))
            {
                list.Add((T)_resourcesScriptableObject._objectList[i]._object);
            }
        }
        T[] t = new T[list.Count];
        for (int i = 0; i < list.Count; i++)
        {
            t[i] = list[i];
        }
        return t;
    }
}
