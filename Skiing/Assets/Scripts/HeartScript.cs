using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartScript : MonoBehaviour {
    public static int lifeNumber = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (lifeNumber == 2)
        {
            heart1.GetComponent<Renderer>().enabled = false;
        }else if(lifeNumber == 1)
        {
            heart1.GetComponent<Renderer>().enabled = false;
            heart2.GetComponent<Renderer>().enabled = false;
        }
        else if (lifeNumber == 0)
        {
            SceneManager.LoadScene("Lose Scene");
        }
	}
}
