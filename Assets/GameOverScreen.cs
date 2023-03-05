using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public void PlayAgainButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButtonClicked()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
