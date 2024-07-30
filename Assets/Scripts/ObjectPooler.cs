using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    
    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler Instance;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) 
        {
            Queue<GameObject> ObjectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject objectToSpawn = Instantiate(pool.prefab);
                objectToSpawn.SetActive(false);
                ObjectPool.Enqueue(objectToSpawn);
            }

            poolDictionary.Add(pool.tag, ObjectPool);
            transform.rotation = Quaternion.identity;
        }
    }

    public GameObject SpawnFromPool(string tag,Vector3 position, Quaternion rotation,Vector3 direction)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        Bullets bullet = objectToSpawn.GetComponent<Bullets>();
        if (bullet != null) 
        { 
            bullet.SetDirection(direction);
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
