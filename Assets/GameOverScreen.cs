using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    void Start()
    {

    }

    public void PlayAgainButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButtonClicked()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
