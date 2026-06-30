using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20f;
    private float spawnPosZ = 20f;

    private float spawnRangeZ = 15f;
    private float spawnPosX = 20f;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

   
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);

        
        bool spawnLeft = Random.Range(0, 2) == 0;

        Vector3 sideSpawnPosition;

        if (spawnLeft)
        {
            sideSpawnPosition = new Vector3(-spawnPosX, 0, Random.Range(0, spawnRangeZ));
            Instantiate(animalPrefabs[animalIndex], sideSpawnPosition, Quaternion.Euler(0, 90, 0));
        }
        else
        {
            sideSpawnPosition = new Vector3(spawnPosX, 0, Random.Range(0, spawnRangeZ));
            Instantiate(animalPrefabs[animalIndex], sideSpawnPosition, Quaternion.Euler(0, -90, 0));
        }
    }
}