using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2 : MonoBehaviour
{
    public float speed, shootTimer, bulletCooldown;
    public GameObject bullet;
    public Transform bossGun1;
    public Transform bossGun2;
    public int hp;
    public float timer = 0f;
    public static int score;
    public float leftBound = -10.0f;
    public float rightBound = 10.0f;
    private bool movingRight = true;
    ScoreManager scoremanager;
    EnemySpawner enemyspawner;

    // Start is called before the first frame update
    void Start()
    {
        bulletCooldown = shootTimer;
        GameObject gamemanager = GameObject.Find("GameManager");
        scoremanager = gamemanager.GetComponent<ScoreManager>();

        enemyspawner = GameObject.FindObjectOfType<EnemySpawner>();
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
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "FireBullet")
        {
            Destroy(collision.gameObject);
            hp--;
            if (hp <= 0)
            {
                scoremanager.Boss2Score();
                Die();
                enemyspawner.SpawnEnemy3();
            }
        }
    }

    void Shoot() 
    {
        GameObject.Instantiate(bullet, bossGun1.position, Quaternion.Euler(0,0,-180f));
        GameObject.Instantiate(bullet, bossGun2.position, Quaternion.Euler(0,0,-180f));
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
