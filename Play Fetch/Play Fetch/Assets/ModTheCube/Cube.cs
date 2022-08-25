using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public Vector3 position = new Vector3(3, 4, 1);
    public float scale;
    public Color color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    void Start()
    {
        transform.position = position;
        transform.localScale = Vector3.one * scale;
        
        Material material = Renderer.material;

        material.color = color;
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
