using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public float spawnRange = 9f;
    public float enemiesToSpawn = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) {
            enemiesToSpawn++;
            spawnEnemyWave();
            spawnPowerups();
        }
        
    }

    private Vector3 newEnemyPosition() {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnX, 0, spawnZ);
    }

    private void spawnEnemyWave()
    {
        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefab, newEnemyPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void spawnPowerups() {
        //for (int i = 0; i < enemiesToSpawn-1; i++) {
            Instantiate(powerUpPrefab, newEnemyPosition(), powerUpPrefab.transform.rotation);
        //}
    }
}
