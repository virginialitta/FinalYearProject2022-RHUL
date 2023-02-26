using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed, shootTimer, bulletCooldown;
    public GameObject bullet;
    public Transform gun1;
    public int hp;
    public float timer = 0f;
    public static int score;
    public float leftBound = -10.0f;
    public float rightBound = 10.0f;
    private bool movingRight = true;
    public Text MyText;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletCooldown = shootTimer;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = bulletCooldown;
        }

        if (movingRight) {
            transform.position = transform.position + new Vector3(1, 0, 0) * speed * Time.deltaTime;
            if (transform.position.x >= rightBound) {
                movingRight = false;
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        } else {
            transform.position = transform.position + new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            if (transform.position.x <= leftBound) {
                movingRight = true;
                transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }

        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            speed *= 1.25f;
            timer = 0f;
        }

        MyText.text = "Score: " + Enemy.score;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "FireBullet")
        {
            Destroy(collision.gameObject);
            hp--;
            if (hp <= 0)
            {
                Die();
            }
            Enemy.score++;
        }
    }

    void Shoot() 
    {
        if (Random.Range(0, 10) == 1)
        {
            // newBullet needs to be created to stop the enemy from shooting itself
            GameObject newBullet = GameObject.Instantiate(bullet, gun1.position, Quaternion.Euler(0,0,-180f));
            newBullet.transform.tag = "Enemy";
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
