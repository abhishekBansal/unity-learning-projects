using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float powerUpStrength = 25f;
    public float powerUpTimeout = 7;

    public GameObject powerUpIndicator;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerUp = false;
    
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * vInput * speed);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")) {
            Debug.Log("Power up");
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            // start power up timer
            StartCoroutine(PowerupCountDownRoutine());
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter: " + gameObject.name + "Power up: " + hasPowerUp);
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp) {
            
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountDownRoutine() {
        yield return new WaitForSeconds(powerUpTimeout);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
}
