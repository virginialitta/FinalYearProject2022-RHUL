using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script handles the behaviour of boss objects
public class Boss3 : MonoBehaviour
{
    // Public variables that can be set in the inspector
    public float speed, shootTimer1, shootTimer2, bulletCooldown1, bulletCooldown2, bulletSpeed;
    public GameObject bullet1;
    public GameObject bullet2;
    public Transform bossGun1;
    public Transform bossGun2;
    public Transform bossGun3;
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
        bulletCooldown1 = shootTimer1;
        bulletCooldown2 = shootTimer2;

        // Find and assign the ScoreManager component from the GameManager object
        GameObject gamemanager = GameObject.Find("GameManager");
        scoremanager = gamemanager.GetComponent<ScoreManager>();

        // Find and assign the EnemySpawner component
        enemyspawner = GameObject.FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown the bullet timers
        shootTimer1 -= Time.deltaTime;
        shootTimer2 -= Time.deltaTime;

        // If the bullet timer has expired, shoot the appropriate bullet type and reset the timer
        if (shootTimer1 <= 0f)
        {
            ShootBullet1();
            shootTimer1 = bulletCooldown1;
        }

        if (shootTimer2 <= 0f)
        {
            ShootBullet2();
            shootTimer2 = bulletCooldown2;
        }

        // Move the boss left and right within the given boundaries
        if (movingRight) 
        {
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
                // Increase the score and display the victory screen when the boss is defeated
                scoremanager.Boss3Score();
                Die();
                SceneManager.LoadScene("Victory Screen");
            }
        }
    }

    // Shoots the first bullet type, two of them which follow the player
    void ShootBullet1() 
    {
        // Find the position of the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Calculate the direction towards the player
        Vector3 direction = (player.transform.position - bossGun1.position).normalized;

        // Calculate the angle between the bullet's forward vector and the direction towards the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Instantiate the bullets prefabs at the gun's position with the correct rotation
        GameObject newBullet1 = Instantiate(bullet1, bossGun2.position, Quaternion.Euler(0f, 0f, angle));
        GameObject newBullet2 = Instantiate(bullet1, bossGun3.position, Quaternion.Euler(0f, 0f, angle));

        // Set the bullets velocity to be in the direction of their forward vector
        newBullet1.GetComponent<Rigidbody2D>().velocity = newBullet1.transform.up * bulletSpeed;
        newBullet2.GetComponent<Rigidbody2D>().velocity = newBullet2.transform.up * bulletSpeed;
    }

    // Shoots the second bullet downwards
    void ShootBullet2() 
    {
        GameObject newBullet = GameObject.Instantiate(bullet2, bossGun1.position, Quaternion.Euler(0,0,-180f));
    }

    // Destroys the boss object
    void Die()
    {
        Destroy(gameObject);
    }

}