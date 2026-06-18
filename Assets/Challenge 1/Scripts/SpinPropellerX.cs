using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject spinner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinner.transform.rotation *= Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime);
    }
}
