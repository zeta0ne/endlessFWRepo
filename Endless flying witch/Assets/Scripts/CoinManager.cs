using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coin;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float distance = 3f;
    private int amntCoinsOnScreen = 20;
    private float safeZoneCoin = 15f;


    // Start is called before the first frame update
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amntCoinsOnScreen; i++)
        {
            SpawnCoin();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerTransform.position.z - safeZoneCoin > (spawnZ - amntCoinsOnScreen * distance))
        {
            SpawnCoin();
            //DeleteCoin();
        }
    }

  

    private void SpawnCoin()
    {
        GameObject go;
        go = Instantiate(coin) as GameObject;
        go.transform.SetParent(transform); //empty manager object is a parent to all spawned coins
        go.transform.position = new Vector3(0, 0, 1) * spawnZ; //spawns coins on vector z in the middle
        spawnZ += distance;
    }

    /*private void DeleteCoin()
    {
        Destroy(coin);
        
    }*/
}
