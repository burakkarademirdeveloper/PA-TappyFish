using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxTime;
    private float timer;
    public float maxY;
    public float minY;
    void Start()
    {
        InstantiateObstacle();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            InstantiateObstacle();
            timer = 0;
        }
    }
    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(10, Random.Range(minY, maxY));
    }
}
