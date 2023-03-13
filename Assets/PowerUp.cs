using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Shield,
    PlusOne,
    TwoGuns,
    ScoreUp
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public float duration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUp(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyPowerUp(GameObject player)
    {
        Spaceship spaceship = player.GetComponent<Spaceship>();
        LivesManager livesmanager = GameObject.FindObjectOfType<LivesManager>();
        ShipGuns shipguns = GameObject.FindObjectOfType<ShipGuns>();
        Enemy enemy = GameObject.FindObjectOfType<Enemy>();
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
                enemy.ScoreUp();
                break;
        }
    }
}

