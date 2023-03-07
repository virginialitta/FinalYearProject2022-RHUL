using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public GameObject[] hearts;
    Spaceship spaceship;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = FindObjectOfType<Spaceship>();
    }

    public void Update()
    {
        if (spaceship.lives == 0) {
            hearts[0].SetActive(false);
        }

        else if (spaceship.lives == 1) {
            hearts[1].SetActive(false);
        }

        else if (spaceship.lives == 2) {
            hearts[2].SetActive(false);
        }
    }

    public void AddLife()
    {
        spaceship.lives++;

        if (spaceship.lives > hearts.Length) {
            spaceship.lives = hearts.Length;
        }

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
