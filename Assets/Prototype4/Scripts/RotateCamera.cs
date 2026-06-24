using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rorationSpeed = 150f;
    private InputSystem_Actions controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        controls.Player.Enable();
        Debug.Log(controls.Player.Move);
    }

    private void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float horizontalInput = moveInput.x; //left and rigth W/S Arrows 
        transform.Rotate(Vector3.up, horizontalInput * rorationSpeed * Time.deltaTime);
    }
}
