using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed, shootTimer, EnemyMovementDown;
    public GameObject bullet;
    public int hp;
    public bool goingLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void EnemyMovement() {
        speed *= 1.25f;
        transform.position -= transform.up*EnemyMovementDown;
        goingLeft = !goingLeft;
    }
}
