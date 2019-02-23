using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks_Trigger : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        HeartScript.lifeNumber -= 1;
    }
}
