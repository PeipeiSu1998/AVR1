using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsForWinner : MonoBehaviour {
    public AudioClip win;
    public AudioSource source;

 void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(win);
    }
}
