using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public int spheresToSpawn = 5;
    public GameObject spherePrefab;

    [SerializeField] private float spawnRangeX = 1.5f;
    [SerializeField] private float spawnRangeY = 1.5f;
    [SerializeField] private float spawnRangeZ = 1.5f;
    // Start is called before the first frame update

    public Text CounterText;

    private int Count = 0;

    void Start()
    {
        Count = 0;
        for (int i = 0; i < spheresToSpawn; i++)
        {
            Instantiate(spherePrefab, randomSpawnLocation(), spherePrefab.gameObject.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 randomSpawnLocation() {
        return new Vector3(Random.Range(-spawnRangeX, spawnRangeX),
            Random.Range(-spawnRangeY, spawnRangeY),
            Random.Range(-spawnRangeZ, spawnRangeZ));
    }

    public void reportCollision() {
        Count += 1;
        CounterText.text = "Count : " + Count/2;
    }
}
