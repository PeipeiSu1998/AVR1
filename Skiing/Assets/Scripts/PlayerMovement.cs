using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool shouldStop = false;
    public Rigidbody camera;

    public float movementSpeed = 5;
    public float rotationSpeed = 5;
    public float rotationDegrees = 90;

    // Use this for initialization
    void Start () {
        camera = GetComponent<Rigidbody>();
    }
	
	
	void FixedUpdate () {
        if (shouldStop == false)
        {
            camera.position += transform.forward * Time.deltaTime * movementSpeed;
            //   camera.AddForce(-5f,0f,0f);
        }

    }
}
