using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the spawning of boss objects
public class BossSpawner : MonoBehaviour
{
    // Public variables that can be set in the inspector
    public GameObject Boss1;
    public GameObject Boss2;
    public GameObject Boss3;

    public bool boss1spawned;
    public bool boss2spawned;
    int enemyNum;
    int selfNum;

    // Start is called before the first frame update
    void Start()
    {
        boss1spawned = false;
        boss2spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get arrays of all enemies and bosses in the scene and store their length as integers
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] self = GameObject.FindGameObjectsWithTag("Boss");
        enemyNum = enemies.Length;
        selfNum = self.Length;

        // If there are no enemies or bosses in the scene, and the first boss has not been spawned, spawn the first boss
        if (enemyNum == 0 && selfNum == 0 && !boss1spawned)
        {
            SpawnBoss1();
        }
        // If there are no enemies or bosses in the scene, and the first boss has been spawned, spawn the second boss
        else if (enemyNum == 0 && selfNum == 0 && boss1spawned && !boss2spawned)
        {
            SpawnBoss2();
        }

        // If there are no enemies or bosses in the scene, and the first and second boss have been spawned, spawn the final boss
        else if (enemyNum == 0 && selfNum == 0 && boss1spawned && boss2spawned)
        {
            SpawnBoss3();
        }
    }

    // Spawns the first boss at a fixed position
    public void SpawnBoss1()
    {
            Vector3 position = new Vector3(0f, 4f, 0f);
            Instantiate(Boss1, position, Quaternion.identity);
            boss1spawned = true;
    }

    // Spawns the second boss at a fixed position
    public void SpawnBoss2()
    {
            Vector3 position = new Vector3(0f, 4f, 0f);
            Instantiate(Boss2, position, Quaternion.identity);
            boss2spawned = true;
    }

    // Spawns the final boss at a fixed position
    public void SpawnBoss3()
    {
            Vector3 position = new Vector3(0f, 4f, 0f);
            Instantiate(Boss3, position, Quaternion.identity);
    }
}