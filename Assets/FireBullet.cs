using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is responsible for the behavior of the bullets fired by the player
public class FireBullet : MonoBehaviour
{
    // speed = velocity of the bullet across the screen
    // timer = how long until bullet despawns
    public float speed, timer;

    // Update is called once per frame
    void Update()
    {
        // Move the bullet upwards based on its current position and speed
        transform.position += transform.up*speed*Time.deltaTime;

        // Decrement the timer each frame
        timer -= Time.deltaTime;

        // If the timer has expired, destroy the bullet game object
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
