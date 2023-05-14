using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Vehicle Skin")]
public class VehicleSkin : ScriptableObject
{
    public Sprite preview;
    public int price;
    public bool isPurchased;
    [HideInInspector]
    public int id;
}