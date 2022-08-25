using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float fireInterval = 0.5f;
    private float time = Time.time;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        float timeDiff = Time.time - time;
        if (Input.GetKeyDown(KeyCode.Space) && timeDiff > fireInterval)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            time = Time.time;

           
        }
       
    }
}
