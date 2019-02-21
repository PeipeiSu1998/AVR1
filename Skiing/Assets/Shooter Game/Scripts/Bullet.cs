using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10;
    public float lifeTime = 10;

    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        Destroy(gameObject, lifeTime);
        myRigidbody.velocity = transform.forward * moveSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);

        if (other.collider.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
