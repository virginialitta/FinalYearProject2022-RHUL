using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script handles the behaviour of boss objects
public class Boss : MonoBehaviour
{
    // Public variables that can be set in the inspector
    public float speed, shootTimer, bulletCooldown;
    public GameObject bullet;
    public Transform bossGun1;
    public int hp;
    public float timer = 0f;
    public static int score;
    public float leftBound = -10.0f;
    public float rightBound = 10.0f;

    // Private variables
    private bool movingRight = true;
    ScoreManager scoremanager;
    EnemySpawner enemyspawner;

    // Start is called before the first frame update
    void Start()
    {
        bulletCooldown = shootTimer;

        // Find and assign the ScoreManager component from the GameManager object
        GameObject gamemanager = GameObject.Find("GameManager");
        scoremanager = gamemanager.GetComponent<ScoreManager>();

        // Find and assign the EnemySpawner component
        enemyspawner = GameObject.FindObjectOfType<EnemySpawner>();
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

        // Move the boss left and right within the given boundaries
        if (movingRight) {
            transform.position = transform.position + new Vector3(1, 0, 0) * speed * Time.deltaTime;
            if (transform.position.x >= rightBound) {
                movingRight = false;
                // If the boss hits the right boundary, move it down one unit
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }        
        else 
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            if (transform.position.x <= leftBound) {
                movingRight = true;
                // If the boss hits the left boundary, move it down one unit
                transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }

        // Increase the boss's speed every 5 seconds
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            speed *= 1.25f;
            timer = 0f;
        }
        
    }

    // Called when the boss collides with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the boss is hit by a bullet, destroy the bullet and decrease the boss's HP
        if (collision.transform.tag == "FireBullet")
        {
            Destroy(collision.gameObject);
            hp--;
            if (hp <= 0)
            {
                // Increase the score and spawn a new enemy when the boss is defeated
                scoremanager.Boss1Score();
                Die();
                enemyspawner.SpawnEnemy2();
            }
        }
    }

    // Shoots three bullets in a cone pattern
    void Shoot() 
    {
        for (int i = 0; i < 3; i++)
        {
            float angle = (i - 1) * 60 + 180; // Creates the cone pattern, +180 to maintain downward direction
            GameObject.Instantiate(bullet, bossGun1.position, Quaternion.Euler(0,0,angle));
        }
    }

    // Destroys the boss object
    void Die()
    {
        Destroy(gameObject);
    }

}
