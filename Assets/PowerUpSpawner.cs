using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is responsible for spawning power-ups randomly at a specified interval
public class PowerUpSpawner : MonoBehaviour
{
    // GameObject variables for each type of power-up to be assigned in the inspector
    public GameObject shield;
    public GameObject plusone;
    public GameObject gun;
    public GameObject score;

    // Variables for controlling the interval and spawn location of the power-ups
    public float spawnInterval = 20f;
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -10f;
    public float maxY = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    // Coroutine to spawn power-ups at random intervals
    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            // Set a random interval for the next power-up to spawn
            float randomInterval = Random.Range(spawnInterval * 0.5f, spawnInterval * 1f);
            yield return new WaitForSeconds(randomInterval);

            // Generate a random position for the power-up to spawn
            float randomX = Random.Range(minX, maxX);
            float startY = maxY + 1.0f; // Spawn power-up above the screen
            Vector3 startPos = new Vector3(randomX, startY, 0);

            // Generate a random power-up type to spawn
            int randomPowerUp = Random.Range(0, 4);

            // Select the appropriate power-up prefab based on the randomPowerUp variable
            GameObject powerUpPrefab;

            switch (randomPowerUp)
            {
                case 0:
                    powerUpPrefab = shield;
                    break;
                case 1:
                    powerUpPrefab = plusone;
                    break;
                case 2:
                    powerUpPrefab = gun;
                    break;
                case 3:
                    powerUpPrefab = score;
                    break;
                default:
                    powerUpPrefab = shield;
                    break;
            }

            // Instantiate the selected power-up prefab at the random position and set its downwards velocity
            GameObject powerUp = Instantiate(powerUpPrefab, startPos, Quaternion.identity);
            Rigidbody2D rb = powerUp.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -2.0f); // Set downward velocity

            // Destroy the power-up if it falls off the screen (after 10 seconds)
            Destroy(powerUp, 10.0f);
        }
    }
}
