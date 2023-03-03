using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    static bool enable = true;
    public static void Log(string s)
    {
        if (enable) Debug.Log(s);
    }
    public static void Log(string s, GameObject obj)
    {
        if (enable) Debug.Log(s, obj);
    }
}
