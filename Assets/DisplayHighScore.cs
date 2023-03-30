using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script displays the player's current score and their high score in a UI text object
public class DisplayHighScore : MonoBehaviour
{
    // Public variables that can be set in the inspector as the UI text elements
    public Text scoretxt;
    public Text highScoretxt;

    // Start is called before the first frame update
    void Start()
    {
        // Find the ScoreTxt object in the scene and set the scoretxt variable to its Text component
        GameObject scoreTextObject = GameObject.Find("ScoreTxt");
        if (scoreTextObject != null) 
        {
            scoretxt = scoreTextObject.GetComponentInChildren<Text>();
        }

        // Find the HighScoreTxt object in the scene and set the highScoretxt variable to its Text component
        GameObject highScoreTextObject = GameObject.Find("HighScoreTxt");
        if (highScoreTextObject != null) 
        {
            highScoretxt = highScoreTextObject.GetComponentInChildren<Text>();
        }

        // Get the player's current score and high score from PlayerPrefs and display them in the UI text objects
        int score = PlayerPrefs.GetInt("Score");
        int highScore = PlayerPrefs.GetInt("HighScore");

        // Display the score in the scene
        scoretxt.text = "Score: " + score;
        highScoretxt.text = "High Score: " + highScore;
    }

}
