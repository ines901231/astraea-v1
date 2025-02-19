using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public GameObject enemy;

    float maxSpawnRateInSeconds = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(enemy);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        SpawnTimer();
    }

    void SpawnTimer()
    {
        float spawnInSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 1f;
            Invoke("SpawnEnemy", spawnInSeconds);
    }

    void IncreaseTimeSpawn()
    {
        if(maxSpawnRateInSeconds > 1f) 
            maxSpawnRateInSeconds --;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseTimeSpawn");
    }

    public void ScheduleEnemySpawner()
    {
        maxSpawnRateInSeconds = 3f;

        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseTimeSpawn", 0f, 30f);
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseTimeSpawn");
    }
}
