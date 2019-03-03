using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsForWinner : MonoBehaviour {
    public AudioClip win;
    public AudioSource source;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;

    void Start()
    {
        fire1.SetActive(false);
        fire2.SetActive(false);
        fire3.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(win);
        PlayerMovement.shouldStop = true;
        fire1.SetActive(true);
        fire2.SetActive(true);
        fire3.SetActive(true);
    }
}
