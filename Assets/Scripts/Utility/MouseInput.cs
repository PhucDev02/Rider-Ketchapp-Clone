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
    public static bool IsMouseOverUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        //check touch
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }

        return false;
    }
}
