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
            Destroy(hearts[0].gameObject);
        }

        else if (spaceship.lives == 1) {
            Destroy(hearts[1].gameObject);
        }

        else if (spaceship.lives == 2) {
            Destroy(hearts[2].gameObject);
        }
    }
}
