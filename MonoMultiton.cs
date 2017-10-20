﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoMultiton<T> : MonoBehaviour where T : MonoMultiton<T> {

    private static List<T> m_instances = new List<T>();

    public static int Count {
        get {
            return m_instances.Count;
        }
    }

    public static T[] instances {
        get {
            return m_instances.ToArray();
        }
    }

    protected virtual void Awake()
    {
        m_instances.Add(this as T);
    }

    protected virtual void OnDestroy()
    {
        m_instances.Remove(this as T);
    }
}
