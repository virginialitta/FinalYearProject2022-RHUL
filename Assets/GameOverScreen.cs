using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This script handles the game over screen
public class GameOverScreen : MonoBehaviour
{
    // Load the Game Scene when Play Again is clicked
    public void PlayAgainButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Load the Start Screen when Main Menu is clicked
    public void MainMenuButtonClicked()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
