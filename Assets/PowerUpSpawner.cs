using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject shield;
    public GameObject plusone;
    public GameObject gun;
    public GameObject score;
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

    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            float randomInterval = Random.Range(spawnInterval * 0.5f, spawnInterval * 1f);
            yield return new WaitForSeconds(randomInterval);

            float randomX = Random.Range(minX, maxX);
            float startY = maxY + 1.0f; // Spawn power-up above the screen
            Vector3 startPos = new Vector3(randomX, startY, 0);

            int randomPowerUp = Random.Range(0, 4);

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

            GameObject powerUp = Instantiate(powerUpPrefab, startPos, Quaternion.identity);
            Rigidbody2D rb = powerUp.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -2.0f); // Set downward velocity

            // Destroy the power-up if it falls off the screen
            Destroy(powerUp, 10.0f);
        }
    }
}
