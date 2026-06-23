using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControllerC3 : MonoBehaviour
{
    public bool gameOver = false;
    public bool isLowEnough;
    public bool isOnGraund;

    public float upLimit = 15f;
    public float floatForce = 5f;
    public float boundForce = 10f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public InputAction floatAction;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boundSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        floatAction.Enable();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        isLowEnough = transform.position.y < upLimit;
        // While space is pressed and player is low enough, float up
        if (floatAction.IsPressed() && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            explosionParticle.Play();
            Invoke("RestartGame",4.0f);
            
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            explosionParticle.Stop();
            fireworksParticle.Play();

        }
        else if(other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * boundForce, ForceMode.Impulse );
            playerAudio.PlayOneShot(boundSound, 1.0f);
        }

    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
