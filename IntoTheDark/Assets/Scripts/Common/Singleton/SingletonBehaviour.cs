using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindAnyObjectByType<T>();
            }

            if (instance == null)
            {
                GameObject go = new GameObject();
                instance = go.AddComponent<T>();
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        Init();
    }

    protected virtual void Init() { }
}
