using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{
    float movementX;
    public float movementSpeed = 5f;
    Rigidbody2D rb; 
    public int lives;
    LivesManager livesManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementSpeed * movementX, rb.velocity.y);
        rb.velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("FireEnemyBullet"))
        {
            lives--;
            Destroy(collision.gameObject);
            if (lives == 0) {
                Destroy(gameObject);
                SceneManager.LoadScene("GameOverScreen"); // Load the game over screen
            }
        }
    }

}
