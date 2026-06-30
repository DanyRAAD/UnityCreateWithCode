using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 2;
    private float xRange = 4;
    private float ySpawnPos = -6;

    public ParticleSystem explotionParticle;
    public int pointValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSapawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Mouse was clicked");
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform == transform)
                {
                    Destroy(gameObject);
                    Instantiate(explotionParticle, transform.position, explotionParticle.transform.rotation);
                    gameManager.UpdateScore(pointValue);
                }
            }
        }

        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }

    Vector3 RandomSapawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange), ySpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DestroyZone"))
        {
            Destroy(gameObject);
        }
    }
}

