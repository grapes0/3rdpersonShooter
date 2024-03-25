using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public Transform[] spawnPoints;
    public int enemySpawnCount;
    public float timer;

    private float _starterTimer;

    private void Start()
    {
        _starterTimer = timer;
    }
    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = _starterTimer;
            SpawnNewWave();
        }
    }

    public void SpawnNewWave()
    {
        for(int i = 0; i <= enemySpawnCount - 1; i++)
        {
            var pickedSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[pickedSpawnPointIndex]);
        }
    }
}
