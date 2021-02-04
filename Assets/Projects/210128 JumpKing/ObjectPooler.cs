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

    #region Singleton
    public static ObjectPooler Instance;

	private void Awake()
	{
        Instance = this;
	}
    #endregion

    public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        foreach(Pool pool in pools)
		{
            Queue<GameObject> objectPool = new Queue<GameObject>();
			for (int i = 0; i < pool.size; i++)
			{
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
			}
            poolDictionary.Add(pool.tag, objectPool);
		}
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
	{
        if (!poolDictionary.ContainsKey(tag))
		{
            Debug.LogWarning("니가 찾는 태그 " + tag + "는 없어...");
            return null;
		}

        GameObject obj = poolDictionary[tag].Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        return obj;
	}

    public void ReturnToPool(string tag, GameObject obj)
	{
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("니가 찾는 태그 " + tag + "는 없어...");
            return;
        }

        poolDictionary[tag].Enqueue(obj);
    }
}
