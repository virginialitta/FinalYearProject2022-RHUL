using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script manages the player's lives and updated the UI sprites accordingly
public class LivesManager : MonoBehaviour
{
    // Array to contain the UI elements to be set in the inspector
    public GameObject[] hearts;
    // Reference to the Spaceship.cs script
    Spaceship spaceship;

    // Start is called before the first frame update
    void Start()
    {
        // Locate Spaceship object in the scene
        spaceship = FindObjectOfType<Spaceship>();
    }

    // Update is called once per frame
    public void Update()
    {
        // The hearts UI elements are updated based on the current number of lives
        if (spaceship.lives == 0) {
            // Last (rightmost) heart sprite deactivated if the player has 0 lives
            hearts[0].SetActive(false);
        }

        else if (spaceship.lives == 1) {
            // Second (centre) heart sprite deactivated if the player has 1 life
            hearts[1].SetActive(false);
        }

        else if (spaceship.lives == 2) {
            // First (leftmost) heart sprite deactivated if the player has 2 lives
            hearts[2].SetActive(false);
        }
    }

    // Power up method
    public void AddLife()
    {
        // Increment lives variable by 1
        spaceship.lives++;

        // If the player already has maximum lives, do not add one
        if (spaceship.lives > hearts.Length) {
            spaceship.lives = hearts.Length;
        }

        // Activate or deactivate UI hearts accordingly
        for (int i = 0; i < hearts.Length; i++) {
            if (i < spaceship.lives) {
                hearts[i].SetActive(true);
            }
            else {
                hearts[i].SetActive(false);
            }
        }
    }

}
