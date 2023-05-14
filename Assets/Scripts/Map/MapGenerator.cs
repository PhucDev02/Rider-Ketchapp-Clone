using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator Instance;
    private void Awake()
    {
        Instance = this;
        InputManager.canTouch = true;
    }
    [SerializeField] private Transform lastTerrain;
    public void GenNextTerrain()
    {
        int index = Random.Range(1, 7);
        GameObject newMap = ObjectPool.Instance.Spawn("Terrain " + index);
        newMap.transform.position
           = lastTerrain.transform.position + Vector3.right * 40;
        lastTerrain = newMap.transform;
    }
    public void Reset()
    {
        lastTerrain = GameObject.FindGameObjectWithTag("Terrain").transform;
    }
}
