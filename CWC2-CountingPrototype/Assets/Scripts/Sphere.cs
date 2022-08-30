using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float initialSpeed = 4f;
    public Light lightSource;
    // Start is called before the first frame update

    [SerializeField] private Color[] colors = { Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta, Color.red};

    private SpawnManager spawnManager;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(randomDirection() * initialSpeed, ForceMode.Impulse);

        Renderer renderer = GetComponent<Renderer>();
        Color color = colors[Random.Range(0, colors.Length)];
         
        renderer.material.color = color; 
        lightSource.color = color;

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 randomDirection() {
        return new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
//            spawnManager.reportCollision();
        }
    }
    
}
