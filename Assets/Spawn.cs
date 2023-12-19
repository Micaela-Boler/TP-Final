using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private GameObject randomObstacle;
    public GameObject[] obstacles;
    public Vector2 spawnPoint;

    int randomIndex;
    public float spawnTime = 4;
    public float repetition = 5;



    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, repetition);
    }


    public void SpawnEnemy()
    {
        randomIndex = Random.Range(0, obstacles.Length);
        randomObstacle = obstacles[randomIndex];

        Instantiate(randomObstacle, spawnPoint, randomObstacle.transform.rotation);
    }
}
