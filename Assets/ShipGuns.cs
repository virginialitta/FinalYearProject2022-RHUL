using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGuns : MonoBehaviour
{
    public float bulletCooldown = 1f;
    float cooldownLength;
    public GameObject bullet;
    public Transform gun, gunLeft, gunRight;
    public bool twoGuns;
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
            if (twoGuns == true) {
                GameObject.Instantiate(bullet, gunLeft.position, Quaternion.identity);
                GameObject.Instantiate(bullet, gunRight.position, Quaternion.identity);
            }

            else {
                GameObject.Instantiate(bullet, gun.position, Quaternion.identity);
            }

            bulletCooldown = cooldownLength;
        }

        if (bulletCooldown >= 0)
        {
            bulletCooldown -= Time.deltaTime;
        }
    }

    public void GunPowerUp() 
    {
        twoGuns = true;
        StartCoroutine(GunDuration());
    }

    private IEnumerator GunDuration() 
    {
        yield return new WaitForSeconds(5f);
        twoGuns = false;
    }
}
