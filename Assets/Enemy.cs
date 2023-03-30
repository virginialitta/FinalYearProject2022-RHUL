using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script handles the behaviour of enemy objects
public class Enemy : MonoBehaviour
{
    // Public variables that can be set in the inspector
    public float speed, shootTimer, bulletCooldown;
    public GameObject bullet;
    public Transform gun1;
    public int hp;
    public float timer = 0f;
    public float leftBound = -10.0f;
    public float rightBound = 10.0f;

    // Private variables
    private bool movingRight = true;
    ScoreManager scoremanager;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletCooldown = shootTimer;

        // Find and assign the ScoreManager component from the GameManager object
        GameObject gamemanager = GameObject.Find("GameManager");
        scoremanager = gamemanager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown the shoot timer
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            // Shoot bullets and reset timer
            Shoot();
            shootTimer = bulletCooldown;
        }

        // Move the enemies left and right within the given boundaries
        if (movingRight) {
            transform.position = transform.position + new Vector3(1, 0, 0) * speed * Time.deltaTime;
            if (transform.position.x >= rightBound) {
                movingRight = false;
                // If the enemy hits the right boundary, move it down one unit
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        } else {
            transform.position = transform.position + new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            if (transform.position.x <= leftBound) {
                movingRight = true;
                // If the enemy hits the left boundary, move it down one unit
                transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }

        // Increase the enemy's speed every 5 seconds
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            speed *= 1.25f;
            timer = 0f;
        }
    }

    // Called when the enemes collide with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the boss is hit by a bullet, destroy the bullet and decrease the boss's HP
        if (collision.transform.tag == "FireBullet")
        {
            Destroy(collision.gameObject);
            hp--;
            if (hp <= 0)
            {
                // Increase the score and destroy the enemy when it has been defeated
                scoremanager.Enemy1Score();
                Die();
            }
        }
    }

    // Enemy has a 10% chance of shooting a bullet
    void Shoot() 
    {
        if (Random.Range(0, 10) == 1)
        {
            // newBullet needs to be created to stop the enemy from shooting itself
            GameObject.Instantiate(bullet, gun1.position, Quaternion.Euler(0,0,-180f));
        }
    }

    // Destroys the enemy object
    void Die()
    {
        Destroy(gameObject);
    }

}