using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script handles behaviour for the player spaceship
public class Spaceship : MonoBehaviour
{
    float movementX; // x axis movement
    public float movementSpeed = 5f; // speed of the spaceship
    Rigidbody2D rb; // rigidbody componenent reference
    public int lives; // number of player lives
    LivesManager livesManager; // livesmanager script reference
    public bool shieldActive = false; // flag for the shield power up
    public GameObject shieldedSpaceship; // prefab for the spaceship with the shield, to be set in the inspector

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); // Set the Rigidbody2D component of the spaceship
        lives = 3; // Set initial live number
        shieldedSpaceship.SetActive(false); // Deactivate the shielded spaceship sprite
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal movement input from the player
        movementX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // Calculate the movement vector and apply the movement to the spaceship
        Vector2 movement = new Vector2(movementSpeed * movementX, rb.velocity.y);
        rb.velocity = movement;
    }

    // Called when the spaceship collides with an enemy bullet
    void OnTriggerEnter2D(Collider2D collision)
    {
        // If collided with an enemy bullet and the shield is not active, decrease lives by 1
        if (collision.gameObject.CompareTag("FireEnemyBullet"))
        {
            if (!shieldActive) {
                lives--;
                // If the player has no more lives, destroy the spaceship
                if (lives == 0) {
                    Destroy(gameObject);
                    SceneManager.LoadScene("GameOverScreen"); // Load the game over screen
                }
            }

            // Destroy the bullet
            Destroy(collision.gameObject);
        }

        // If collided with an enemy or a boss, meaning they have reached the bottom of the screen, destroy the player spaceship
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss")) 
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScreen"); // Load the game over screen
        }
    }

    // Shield power up implementation
    public void ActivateShield() 
    {
        // If the shield is not already active, activate it and disable the collider, making the spaceship "immune" to bullets
        if (!shieldActive) {
            shieldActive = true;
            GetComponent<Collider2D>().enabled = false;
            shieldedSpaceship.SetActive(true); // Activate the shielded sprite to display the shield in game
            StartCoroutine(ShieldDuration());
        }
    }

    // Couroutine for shield duration
    IEnumerator ShieldDuration()
    {
        // Wait for 5 seconds, then re-enable the collider, deactivate the shielded sprite and set the shield as inactive
        yield return new WaitForSeconds(5f);
        GetComponent<Collider2D>().enabled = true;
        shieldedSpaceship.SetActive(false);
        shieldActive = false;
    }

    
}
