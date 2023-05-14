using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Theme")]
public class Theme : ScriptableObject
{
    public Color color;
    public int price;
    [HideInInspector]
    public int id;
}