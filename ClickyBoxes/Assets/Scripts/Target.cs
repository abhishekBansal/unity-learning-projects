using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{ 
    public float maxForce = 18;
    public float minForce = 14;
    public float torqueRange = 12;
    public float xRange = 4;
    public int pointValue;
    public ParticleSystem explosion;

    private GameManager gameManager;
    private Rigidbody targetRb;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(randomForce(), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), ForceMode.Impulse);
        transform.position = randomPosition();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.updateScore(pointValue);
            Instantiate(explosion, transform.position, explosion.transform.rotation);

            if (CompareTag("Bad") == true)
            {
                gameManager.gameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (CompareTag("Good") == true) {
            gameManager.gameOver();
        }
    }

    private Vector3 randomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private Vector3 randomTorque() {
        return new Vector3(Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange));
    }

    private Vector3 randomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), -6);
    }
   
}
