using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
#if UNITY_EDITOR
    public void Log(string msg)
    {
        Debug.Log(msg);
    }

    public void LogWarning(string msg)
    {
        Debug.LogWarning(msg);
    }
#endif

    public void LogError(string msg)
    {
        Debug.LogError(msg); 
    }
}
