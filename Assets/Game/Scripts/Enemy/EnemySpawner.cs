using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnPrefab = null;
    [Range(0.0F, 40.0F)]
    public float spawnRange = 25F;

    [Range(0.0F, 10F)]
    public float spawnDelay = 2F;
    private float _timer;

    public float rightLaneCenter;
    public int rightLaneSpawnerLow;
    public int rightLaneSpawnerHigh;
    public int numRightLaneCars;


    void Start()
    {
    }
    
    void Update()
    {
        if (spawnPrefab != null)
        {
            _timer += Time.deltaTime;
            if (_timer >= spawnDelay)
            {
                _timer = 0;
                SpawnCube();
            }

        }
    }

    private void SpawnCube()
    {
        Vector3 position = new Vector3(Random.Range(-spawnRange, spawnRange), 2, Random.Range(-spawnRange, spawnRange));
        Instantiate(spawnPrefab, position, Quaternion.identity);
    }
}

