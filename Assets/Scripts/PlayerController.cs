using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the vehicle forward
        //opcion 1 transform.Translate(0,0,1);
        //opcion 2
        transform.Translate(Vector3.forward * Time.deltaTime * 20);
    }
}
