using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public int numRows = 2;
    public int numColumns = 10;
    public float horizontalSpacing = 2.0f;
    public float verticalSpacing = 2.0f;

    void Start()
    {
        Vector3 startingPosition = transform.position;

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                Vector3 position = new Vector3(startingPosition.x + col * horizontalSpacing, startingPosition.y - row * verticalSpacing, startingPosition.z);
                Instantiate(Enemy1, position, Quaternion.identity);
            }
        }
    }
}