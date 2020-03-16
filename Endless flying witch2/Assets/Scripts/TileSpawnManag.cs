using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManag : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    //public Rigidbody rb;
    private float speed = 9;
    private List<GameObject> activeTiles;
    private float spawnZ = -10.0f;
    private float tileLength = 10.0f;
    private int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
    }

    private void MoveTiles()
    {
        foreach (GameObject gO in activeTiles)
        {
            gO.transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void GenerateTiles(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTiles();
        GenerateTiles();
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
