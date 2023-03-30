using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script manages the score system for the game
public class ScoreManager : MonoBehaviour
{
    public int score; // current score
    public int highScore; // highest score achieved
    public Text scoretxt; // UI text element
    public bool scoreUp; // flag for power up activation

    // Start is called before the first frame update
    void Start()
    {
        // Initialize score and UI
        score = 0;
        scoretxt.text = "Score: " + score;

        // Find the ScoreTxt canvas in the scene and set UI text component
        GameObject scoreTextObject = GameObject.Find("ScoreTxt");
        if (scoreTextObject != null) 
        {
            scoretxt = scoreTextObject.GetComponentInChildren<Text>();
        }

        // Get the high score from player prefs
        highScore = PlayerPrefs.GetInt("HighScore");
        
    }

    // Add score to the player's current score
    public void AddScore(int value)
    {
        score += value;

        // Check if the current score is higher than the highest score and update it if necessary
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        // Save the current score in player prefs
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        // Update the score UI text component
        scoretxt.text = "Score: " + score;
    }

    // Increase the player's score by 1 when an enemy of basic type is destroyed
    public void Enemy1Score()
    {
        AddScore(1);
        scoretxt.text = "Score: " + score;
    }

    // Increase the player's score by 50 when the first boss is destroyed
    public void Boss1Score()
    {
        AddScore(50);
        scoretxt.text = "Score: " + score;
    }

    // Increase the player's score by 100 when the second boss is destroyed
    public void Boss2Score()
    {
        AddScore(100);
        scoretxt.text = "Score: " + score;
    }

    // Increase the player's score by 100 when the final boss is destroyed
    public void Boss3Score()
    {
        AddScore(500);
        scoretxt.text = "Score: " + score;
    }

    // Power up that adds +10 to the score
    public void ScoreUp() {
        AddScore(10);
        scoretxt.text = "Score: " + score;
    }
}
