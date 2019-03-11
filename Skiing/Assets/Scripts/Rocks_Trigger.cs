using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks_Trigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {

            HeartScript.lifeNumber -= 1;
        }
    }
}
