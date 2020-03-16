using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private Transform playerTransform;
    private Vector3 moveVector;
    private float spawnZ = 15.0f; //where obj is spawned on z
    private float tileLength = 30.0f; //length of 1 tile
    private float safeZone = 40.0f;
    private int amnObstOnScreen = 15; // amount of tiles on screen
    private int lastPrefabIndex = 0;
    private List<GameObject> activeObst; //list for objects on screen

    // Start is called before the first frame update
    private void Start()
    {
        activeObst = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnObstOnScreen; i++)
        {
            SpawnObst();
        }
    }

    // Update is called once per frame
    private void Update()
    {


        if (playerTransform.position.z - safeZone > (spawnZ - amnObstOnScreen * tileLength))
        {
            SpawnObst();
            DeleteObst();
        }
    }

    private void SpawnObst(int prefabIndex = -1) // -1 means random
    {
        GameObject go;
        go = Instantiate(obstaclePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeObst.Add(go);
    }

    private void DeleteObst()
    {
        Destroy(activeObst[0]); //deleting first object from list of objs on screen
        activeObst.RemoveAt(0);
    }


    private int RandomPrefabIndex()
    {
        if (obstaclePrefabs.Length <= 1) // if there is only 1 prefab on the list, the 1st is returned
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, obstaclePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

}
