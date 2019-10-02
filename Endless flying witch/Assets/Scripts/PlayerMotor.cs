using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    public float speed = 20f;
    private float lane;
    private float floor;
    public float chLnSpeed = 10f;


    // Start is called before the first frame update
    void Start()
        
    {
        lane = 0;
        floor = 1;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        //x
        //moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //y
        //moveVector.y = Input.GetAxisRaw("Vertical") * speed;
        //z
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);

        Vector3 newPosition = transform.position; //returns position of a character
        newPosition.x = lane;
        newPosition.y = floor;
        transform.position = Vector3.Lerp(transform.position, newPosition, chLnSpeed * Time.deltaTime);
     

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (lane > -2f)
                lane -= 2f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (lane < 2f)
                lane += 2f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (floor < 4)
                floor += 3.5f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (floor > 3)
                floor -= 3.5f;
        }
        

    }
}