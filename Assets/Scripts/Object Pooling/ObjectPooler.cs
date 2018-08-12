using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : GenericSingleton<ObjectPooler> {

    [SerializeField] private int extendFactor;
    [SerializeField] private List<Pool> pools;

    private Dictionary<ObjectsEnums, Queue<GameObject>> poolDictionary;

    void Start () {
        poolDictionary = new Dictionary<ObjectsEnums, Queue<GameObject>>();
        FillQueues();
	}

    /// <summary>
    /// fill all queues based on pools
    /// </summary>
    private void FillQueues()
    {
        foreach(Pool pool in pools)
        {
            poolDictionary.Add(pool.tag, FillPool(pool.size, pool));
        }
    }

    /// <summary>
    /// method for spawning one object from pool
    /// </summary>
    /// <param name="tag"> object tag to spawn </param>
    /// <param name="position"> spawning position </param>
    /// <param name="rotation"> spawning rotation </param>
    /// <returns> gameobject from pool based on selected tag </returns>
    public GameObject SpawnFromPool(ObjectsEnums tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("ObjectPool doesn't contains object with " + tag + " tag.");
            return null;
        }

        //if it is last item, extend pool by extend factor
        if(poolDictionary[tag].Count == 1)
        {
            ExtendPool(extendFactor, poolDictionary[tag], poolDictionary[tag].Dequeue());
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    /// <summary>
    /// fill one queue by current pool
    /// </summary>
    /// <param name="size"> size of the pool </param>
    /// <param name="pool"> pool to filling </param>
    /// <returns> queue filled with objects from pool </returns>
    private Queue<GameObject> FillPool(int size, Pool pool)
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(pool.prefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

        return objectPool;
    }

    /// <summary>
    /// extend queue if it become empty
    /// </summary>
    /// <param name="size"> extend size </param>
    /// <param name="objectPool"> queue to extend </param>
    /// <param name="prefab"> prefab to fill the queue </param>
    private void ExtendPool(int size, Queue<GameObject> objectPool, GameObject prefab)
    {
        objectPool.Enqueue(prefab);

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }
}
