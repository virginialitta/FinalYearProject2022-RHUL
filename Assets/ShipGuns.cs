using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGuns : MonoBehaviour
{
    public float bulletCooldown = .05f;
    float cooldownLength;
    public GameObject bullet;
    public Transform gun;
    // Start is called before the first frame update
    void Start()
    {
        cooldownLength = bulletCooldown;
        bulletCooldown = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && bulletCooldown <= 0)
        {
            GameObject.Instantiate(bullet, gun.position, Quaternion.identity);
            bulletCooldown = cooldownLength;
        }

        if (bulletCooldown >= 0)
        {
            bulletCooldown -= Time.deltaTime;
        }
    }
}
