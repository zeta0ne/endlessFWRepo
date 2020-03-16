using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject[] wallPrefabs;

    private Transform playerTransform;
    private Vector3 moveVector;
    private float spawnZ = -10.0f; //where obj is spawned on z
    private float tileLength = 30.0f; //length of 1 tile
    private float safeZone = 45.0f; 
    private int amnWallsOnScreen = 10; // amount of tiles on screen
    private int lastPrefabIndex = 0; 
    private List<GameObject> activeWalls; //list for objects on screen

    // Start is called before the first frame update
    private void Start()
    {
        activeWalls = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnWallsOnScreen; i++)
        {
            SpawnWalls();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        

        if (playerTransform.position.z - safeZone > (spawnZ - amnWallsOnScreen * tileLength))
        {
            SpawnWalls();
            DeleteTile();
        }
    }

    private void SpawnWalls(int prefabIndex = -1) // -1 means random
    {
        GameObject go;
        go = Instantiate(wallPrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeWalls.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeWalls[0]); //deleting first object from list of objs on screen
        activeWalls.RemoveAt(0); 
    }

    
    private int RandomPrefabIndex()
    {
        if (wallPrefabs.Length <= 1) // if there is only 1 prefab on the list, the 1st is returned
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, wallPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
    
}
