using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed, shootTimer, EnemyMovementDown, bulletCooldown;
    public GameObject bullet;
    public Transform gun1;
    public int hp;
    public bool goingLeft;
    public float timer = 0f;
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
        if (goingLeft == true)
        {
            transform.position -= transform.right*speed*Time.deltaTime;
        }

        else
        {
            transform.position += transform.right*speed*Time.deltaTime;
        }
        
        if (Mathf.Abs(transform.position.x) >= 8.4)
        {
            EnemyMovement();
        }

        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            speed *= 1.25f;
            timer = 0f;
        }
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
        }
    }

    void EnemyMovement() {
        transform.position -= transform.up*EnemyMovementDown;
        goingLeft = !goingLeft;
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
