using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody camera;

    public float movementSpeed = 5;
    public float rotationSpeed = 5;
    public float rotationDegrees = 90;

    // Use this for initialization
    void Start () {
        camera = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        camera.position += transform.forward * 1 * Time.deltaTime * movementSpeed;

    }
}
