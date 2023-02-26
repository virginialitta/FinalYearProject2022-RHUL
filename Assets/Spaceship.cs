using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    float movementX;
    public float movementSpeed = 5f;
    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
            Destroy(gameObject);
        }
    }

}
