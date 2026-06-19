using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, -1);
        transform.localScale = Vector3.one * 3.0f;
        
        Material material = Renderer.material;
        //material.color = new Color(0.5f, 1.0f, 0.3f, 0.8f);
        InvokeRepeating("ChangeColor", 0.0f, 2.0f);
       
    }
    
    void Update()
    {
        transform.Rotate(0.0f, 10.0f * Time.deltaTime, 0.0f);
    }

    void ChangeColor()
    {
        Color color = Random.ColorHSV();
        color.a = 0.4f;
        Renderer.material.color = color;
    }
}
