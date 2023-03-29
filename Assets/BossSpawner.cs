using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss1;
    public GameObject Boss2;
    public bool boss1spawned;
    int enemyNum;
    int selfNum;

    void Start()
    {
        boss1spawned = false;
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] self = GameObject.FindGameObjectsWithTag("Boss");
        enemyNum = enemies.Length;
        selfNum = self.Length;

        if (enemyNum == 0 && selfNum == 0 && !boss1spawned)
        {
            SpawnBoss1();
        }
        else if (enemyNum == 0 && selfNum == 0 && boss1spawned)
        {
            SpawnBoss2();
        }
    }


    public void SpawnBoss1()
    {
            Vector3 position = new Vector3(0f, 4f, 0f);
            Instantiate(Boss1, position, Quaternion.identity);
            boss1spawned = true;
    }

    public void SpawnBoss2()
    {
            Vector3 position = new Vector3(0f, 4f, 0f);
            Instantiate(Boss2, position, Quaternion.identity);
        }
}