using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public int numRows;
    public int numColumns;
    public float horizontalSpacing = 2.0f;
    public float verticalSpacing = 2.0f;
    Boss bosshp;

    void Start()
    {
        SpawnEnemy1();
    }


    void SpawnEnemy1() {

        Vector3 startingPosition = transform.position;
        numRows = 2;
        numColumns = 10;

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                Vector3 position = new Vector3(startingPosition.x + col * horizontalSpacing, startingPosition.y - row * verticalSpacing, startingPosition.z);
                Instantiate(Enemy1, position, Quaternion.identity);
            }
        }
        
    }

    public void SpawnEnemy2() {

        Vector3 startingPosition = transform.position;
        numRows = 3;
        numColumns = 6;

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    Vector3 position = new Vector3(startingPosition.x + col * horizontalSpacing, startingPosition.y - row * verticalSpacing, startingPosition.z);
                    Instantiate(Enemy2, position, Quaternion.identity);
                }
            }       
    }

    public void SpawnEnemy3() {

        Vector3 startingPosition = transform.position;
        numRows = 3;
        numColumns = 10;

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