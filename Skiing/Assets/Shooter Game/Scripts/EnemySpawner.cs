using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float spawnDelay = 4;
    public float spawnRadius = 20;

    private float timeOfLastSpawn = 0;

    public void Update()
    {
        if (Time.time - timeOfLastSpawn > spawnDelay)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        timeOfLastSpawn = Time.time;

        Enemy enemy = Instantiate(enemyPrefab);

        Vector3 direction = new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f));
        direction = direction.normalized * spawnRadius;

        enemy.transform.position = direction;
    }
}
