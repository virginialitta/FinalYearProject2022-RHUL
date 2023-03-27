using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss1;

    void Start()
    {
        
    }

    void Update()
    {
        SpawnBoss();
    }


    public void SpawnBoss()
    {
  
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
        int enemyNum = enemies.Length;
        int bossNum = bosses.Length;

        if (enemyNum == 0 && bossNum == 0) {
            Vector3 position = new Vector3(0f, 4f, 0f);
            Instantiate(Boss1, position, Quaternion.identity);
        }

    }
}