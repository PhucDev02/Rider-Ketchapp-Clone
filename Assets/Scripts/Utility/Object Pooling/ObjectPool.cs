using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    [SerializeField] private Pool[] Pools;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        this.RegisterListener(EventID.OnNewDeal, (param) => RecallAll());

    }
    private void Start()
    {
        foreach (var pool in Pools)
        {
            pool.ListObject = new List<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                pool.ListObject.Add(CreateGameObject(pool.Prefab));
            }
        }
    }
    private GameObject CreateGameObject(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.parent = transform;
        obj.SetActive(false);
        return obj;
    }

    public GameObject Spawn(string tag)
    {
        foreach (var pool in Pools)
        {
            if (pool.Prefab.name == tag)
            {
                foreach (var obj in pool.ListObject)
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.SetActive(true);
                        return obj;
                    }
                }
                // expand pool
                if (pool.Expandable)
                {
                    GameObject obj = CreateGameObject(pool.Prefab);
                    pool.ListObject.Add(obj);
                    obj.SetActive(true);
                    return obj;
                }
                else
                {
                    Debug.LogWarning("The pool with tag " + tag + " is not expandable!");
                    return null;
                }
            }
        }

        Debug.LogWarning("The pool with tag " + tag + " is not exist!");
        return null;
    }

    public void Recall(GameObject obj)
    {
        MonoBehaviour instance = obj.GetComponent<MonoBehaviour>();


        //if (instance is Obstacle)
        //{
        //    (instance as Obstacle).Reset();
        //}
        //if (instance is HoopController)
        //{
        //    (instance as HoopController).Reset();
        //}
        obj.transform.parent = transform;
        obj.SetActive(false);
    }

    public void RecallAll()
    {

        foreach (var pool in Pools)
        {
            foreach (var obj in pool.ListObject)
            {
                Recall(obj);
            }
        }
    }
}