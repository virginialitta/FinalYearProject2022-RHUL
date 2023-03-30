using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the behavior of the spaceship's guns and shooting mechanics
public class ShipGuns : MonoBehaviour
{
    public float bulletCooldown = 1f; // cooldown between bullets
    float cooldownLength; // cooldown length
    public GameObject bullet; // bullet prefab to be assigned in the inspector
    public Transform gun, gunLeft, gunRight; // gun transforms
    public bool twoGuns; // flag to check for gun upgrade power up

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the cooldown timer and set it to 0
        cooldownLength = bulletCooldown;
        bulletCooldown = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is clicked and the cooldown timer has expired
        if (Input.GetMouseButton(0) && bulletCooldown <= 0)
        {
            // If the ship has the double gun power up, fire bullets from both gun transforms
            if (twoGuns == true) {
                GameObject.Instantiate(bullet, gunLeft.position, Quaternion.identity);
                GameObject.Instantiate(bullet, gunRight.position, Quaternion.identity);
            }

            // If the power up is not active, fire a bullet from the main gun transform
            else {
                GameObject.Instantiate(bullet, gun.position, Quaternion.identity);
            }

            // Reset the cooldown timer
            bulletCooldown = cooldownLength;
        }

        // If the cooldown timer has not expired, decrement it
        if (bulletCooldown >= 0)
        {
            bulletCooldown -= Time.deltaTime;
        }
    }

    // Double gun power up implementation
    public void GunPowerUp() 
    {
        twoGuns = true;
        StartCoroutine(GunDuration());
    }

    // Coroutine to manage the duration of the gun power-up
    private IEnumerator GunDuration() 
    {
        // Deactivate after 5 seconds
        yield return new WaitForSeconds(5f);
        twoGuns = false;
    }
}
