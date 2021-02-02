using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCube;
    [SerializeField]
    LevelController levelController;
    [SerializeField]
    Camera _camera;

    Vector3 startPosition;
    GameObject lastCube;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        startPosition = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z);

        lastCube = Instantiate(prefabCube, startPosition, Quaternion.identity);
    }

    
    void Update()
    {

        if (player.transform.position.x + 10 > lastCube.transform.position.x)
		{
            int lastPosX = (int)lastCube.transform.position.x;
            LevelData data = levelController.GetLevelData(player.transform.position.x);

            var offset = Random.Range(data.holeMin, data.holeMax);
            var floor = Random.Range(data.floorMin, data.floorMax);
            var height = Random.Range(data.heightMin, data.heightMax);
            for (int i = 0; i < floor; i++)
			{    
               lastCube = Instantiate(prefabCube, new Vector3(lastPosX + i + offset, height, lastCube.transform.position.z), Quaternion.identity);
			}
		}
    }
    private void LateUpdate()
    {
        LevelData data = levelController.GetLevelData(player.transform.position.x);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -10 - data.holeMin), 0.05f);
    }
}
