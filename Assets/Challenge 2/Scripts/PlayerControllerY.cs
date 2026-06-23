using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerY : MonoBehaviour
{
    public GameObject dogPrefab;
    public InputAction fireAction;
    //public int health = 5.0f; 

    // Start is called before the first frame update
    void Start()
    {
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (fireAction.triggered)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
