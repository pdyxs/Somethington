using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScriptableConfig<T> : ScriptableObject where T : ScriptableConfig<T>
{
    private static T _config;
    public static T Get()
    {
#if !UNITY_EDITOR
        if (_config == null) 
#endif
        {
            _config = Resources.Load(AssetName) as T;
        }
        return _config;
    }

    private static string AssetName {
        get {
            return "Config-" + typeof(T).Name;
        }
    }

#if UNITY_EDITOR
    protected static void create()
    {
        T config = Get();
        if (config == null)
        {
            config = ScriptableObject.CreateInstance<T>();
            if (!AssetDatabase.IsValidFolder("Assets/Resources"))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
            }
            AssetDatabase.CreateAsset(config, "Assets/Resources/" + AssetName + ".asset");
            AssetDatabase.SaveAssets();
        }

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = config;
    }
#endif

}
