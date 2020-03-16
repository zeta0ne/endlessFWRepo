using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinProperties : MonoBehaviour
{ 
    public float speed = 50;

    // Start is called before the first frame update
    void Start()
    {
        speed = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0, Space.World);
    }
}
