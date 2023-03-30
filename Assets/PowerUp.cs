using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defines power up types
public enum PowerUpType
{
    Shield,
    PlusOne,
    TwoGuns,
    ScoreUp
}

// Handles power up activation
public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public float duration = 10f;

    // Called when detecting collision with the player spaceship
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the collided object has the Player tag
        if (other.CompareTag("Player"))
        {
            // Apply the power up and destroy the sprite
            ApplyPowerUp(other.gameObject);
            Destroy(gameObject);
        }
    }

    // Applies the corresponding power ups to the player
    private void ApplyPowerUp(GameObject player)
    {
        // Get necessary components from other objects
        Spaceship spaceship = player.GetComponent<Spaceship>();
        LivesManager livesmanager = GameObject.FindObjectOfType<LivesManager>();
        ShipGuns shipguns = GameObject.FindObjectOfType<ShipGuns>();
        ScoreManager scoremanager = GameObject.FindObjectOfType<ScoreManager>();

        // Switch statement to determine which type of power-up has been obtained and apply the corresponding effect
        switch (powerUpType)
        {
            case PowerUpType.Shield:
                // Activate shield power-up
                player.GetComponent<Spaceship>().ActivateShield();
                break;
            case PowerUpType.PlusOne:
                // Add one life to the player
                livesmanager.AddLife();
                break;
            case PowerUpType.TwoGuns:
                // Activate gun power-up
                shipguns.GunPowerUp();
                break;
            case PowerUpType.ScoreUp:
                // Activate score power-up
                scoremanager.ScoreUp();
                break;
        }
    }
}

