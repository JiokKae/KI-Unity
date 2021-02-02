using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject prefSkeleton;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        
    }

    IEnumerator Spawn()
	{
		while (true)
		{
            GameObject skeleton = Instantiate(prefSkeleton, new Vector3(Random.Range(-40f, 40f), 0f, Random.Range(-40f, 40f)), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
            if(Random.Range(1f, 100f) < 20f)
               skeleton.SendMessage("RGB");
            yield return new WaitForSeconds(10f);
		}
	}
}
