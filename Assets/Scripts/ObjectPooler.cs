using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public class ObjectPoolItem
    { 
        public int amount;
        public GameObject prefab;
        public bool shouldExpand;
    }

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    private List<GameObject> objects;
    public List<ObjectPoolItem> pooledObjects;

 private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FillList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject GetPooledObject(string tag)
    {
        return Instance._GetPooledObject(tag);
    }

    private GameObject _GetPooledObject(string tag)
    {
        for(int i=0; i <= objects.Count; i++)
        {
            if (!objects[i].activeInHierarchy && objects[i].tag == tag)
            {
                return objects[i];
            }
        }
        foreach (var pool in pooledObjects)
        {
            if(pool.prefab.tag == tag)
            {
                if (pool.shouldExpand)
                {
                    AddNewObject(pool);
                }
            }
        }

        return null;
    }

    void FillList()
    {
        objects = new List<GameObject>();

        foreach(var pool in pooledObjects)
        { 
            for (int i = 0; i <= pool.amount; i++)
            {
                AddNewObject(pool);
            }
        }
    }

    private GameObject AddNewObject(ObjectPoolItem p)
    {
        GameObject g = Instantiate(p.prefab);
        g.SetActive(false);
        objects.Add(g);
        return g;
    }
}
