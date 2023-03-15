using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBoss();
    }

    // Update is called once per frame
    public void SpawnBoss()
    {
        // Check if there are any enemies still alive in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            Debug.Log("Cannot spawn boss, there are still enemies in the scene");
            return;
        }

        // Spawn the boss
        else {
            Vector3 position = new Vector3(0f, 0f, 0f);
            Instantiate(Boss1, position, Quaternion.identity);
        }
    }
}
