using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerP2 : MonoBehaviour
{
    public InputAction moveAction;
    public Vector2 moveInput;
    public float speed = 10.0f;
    public float xRange = 15.0f;
    public float zRange = 16.0f;
    public float zMin = -1.0f;

    public GameObject projectilePrefab;
    public InputAction fireAction;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
        }

        if(transform.position.z < zMin)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,zMin);
        }
        if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,zRange);
        }
        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * moveInput.y * Time.deltaTime * speed);
        transform.Translate(Vector3.right * moveInput.x * Time.deltaTime * speed);

        if (fireAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
