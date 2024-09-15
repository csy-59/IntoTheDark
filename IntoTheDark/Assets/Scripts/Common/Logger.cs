using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : Singleton<Logger>
{
    public void Log(string msg)
    {
#if UNITY_EDITOR
        Debug.Log(msg);
#endif
    }

    public void LogWarning(string msg)
    {
#if UNITY_EDITOR
        Debug.LogWarning(msg);
#endif
    }

    public void LogError(string msg)
    {
        Debug.LogError(msg); 
    }
}
