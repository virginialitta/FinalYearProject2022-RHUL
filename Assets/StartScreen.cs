using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Handles behaviour of the start screen
public class StartScreen : MonoBehaviour
{

    // If the Start button is clicked, start a game
    public void StartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    // If the Quit button is clicked, close the game
    public void QuitButtonClicked()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

}
