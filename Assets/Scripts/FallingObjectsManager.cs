using UnityEngine;

public class FallingObjectsManager : MonoBehaviour
{
    public GameObject[] objectsToFall;
    public Transform spawnArea;
    public Transform player; 
    public float spawnInterval = 4f;
    public float objectLifetime = 5f;
    public float fallSpeed = 5f;
    public AudioClip objectFallSound;
    public AudioSource audioSource;

    [HideInInspector]
    public float timer = 30f;

    private int playerScore = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            spawnInterval = Mathf.Max(0.5f, spawnInterval - 0.2f);
            CancelInvoke(nameof(SpawnObject));
            InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
            timer = 30f;
            playerScore += 100;
            Debug.Log("Score: " + playerScore);
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
            spawnArea.position.y,
            0
        );

        GameObject newObject = Instantiate(objectsToFall[Random.Range(0, objectsToFall.Length)], spawnPosition, Quaternion.identity);

        FallingObject fallingObjectScript = newObject.AddComponent<FallingObject>();
        fallingObjectScript.Initialize(player, fallSpeed, objectLifetime);

        if (objectFallSound != null)
        {
            audioSource.PlayOneShot(objectFallSound);
        }
    }
}


