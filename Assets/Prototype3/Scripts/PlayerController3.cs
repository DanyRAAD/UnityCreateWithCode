using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{
    private Rigidbody playerRb;
    public InputAction jumAction;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGraund = true;
    public bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        jumAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumAction.triggered && isOnGraund)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGraund = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if  (collision.gameObject.CompareTag("Ground"))
        {
            isOnGraund = true;
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
