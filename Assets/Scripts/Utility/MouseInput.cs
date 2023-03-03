using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput
{
    public static Vector3 lastPosition, newPosition;
    public static bool canPlay = false;
    public static bool IsSingleTap()
    {
        if ((newPosition - lastPosition).magnitude <= 0.04f)
        {
            return true;
        }
        else return false;
    }
}
