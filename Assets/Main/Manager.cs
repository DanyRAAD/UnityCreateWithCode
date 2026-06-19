using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("mainscene");
        }
    }

    public void LoadChallenge1()
    {
        SceneManager.LoadScene("Challenge 1");
    }

    public void LoadChallenge2()
    {
        SceneManager.LoadScene("Challenge 2");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Scene");
    }
}