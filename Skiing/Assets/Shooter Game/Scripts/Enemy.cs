using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float killDistance = 0.5f;

    private Transform playerCameraRig;

    private NavMeshAgent navAgent;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        playerCameraRig = GameObject.FindObjectOfType<OVRCameraRig>().transform;

        navAgent.destination = playerCameraRig.position;
    }

    private void Update()
    {
        Vector3 vectorToPlayer = transform.position - playerCameraRig.position;
        float distanceToEnemy = vectorToPlayer.magnitude;

        if (distanceToEnemy < killDistance)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
