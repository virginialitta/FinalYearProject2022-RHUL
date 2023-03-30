using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script handles the spawning of of enemy objects
public class EnemySpawner : MonoBehaviour
{
    // References to different enemies to be set in the inspector
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    // Variables for enemy position when spawning
    public int numRows;
    public int numColumns;
    public float horizontalSpacing = 2.0f;
    public float verticalSpacing = 2.0f;

    Boss bosshp;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the first type of enemy on start
        SpawnEnemy1();
    }

    // Spawns the first type of enemy in a 2 rows of 10
    void SpawnEnemy1() {

        Vector3 startingPosition = transform.position;
        numRows = 2;
        numColumns = 10;

        // Loops through rows and columns to spawn the enemies
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                Vector3 position = new Vector3(startingPosition.x + col * horizontalSpacing, startingPosition.y - row * verticalSpacing, startingPosition.z);
                Instantiate(Enemy1, position, Quaternion.identity);
            }
        }
        
    }

    // Spawns the second type of enemy in a 3 rows of 6
    public void SpawnEnemy2() {

        Vector3 startingPosition = transform.position;
        numRows = 2;
        numColumns = 12;

            // Loops through rows and columns to spawn the enemies
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    Vector3 position = new Vector3(startingPosition.x + col * horizontalSpacing, startingPosition.y - row * verticalSpacing, startingPosition.z);
                    Instantiate(Enemy2, position, Quaternion.identity);
                }
            }       
    }

    // Spawns the third type of enemy in a 3 rows of 10
    public void SpawnEnemy3() {

        Vector3 startingPosition = transform.position;
        numRows = 3;
        numColumns = 10;

            // Loops through rows and columns to spawn the enemies
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    Vector3 position = new Vector3(startingPosition.x + col * horizontalSpacing, startingPosition.y - row * verticalSpacing, startingPosition.z);
                    Instantiate(Enemy3, position, Quaternion.identity);
                }
            }    
    }
}