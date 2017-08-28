using UnityEngine;
using WZK;

public class MyResources
{
    public static T Load<T>(string path) where T : Object
    {
        ResourcesScriptableObject so = MemoryPrefs.GetObject<ResourcesScriptableObject>("序列化资源列表");
        if (so == null)
        {
            Debug.Log("不存在该序列化资源列表");
            return default(T);
        }
        path = "Resources/" + path;
        return (T)so.GetObject(path);
    }
}
