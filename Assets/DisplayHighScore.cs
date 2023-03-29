using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    public Text scoretxt;
    public Text highScoretxt;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreTextObject = GameObject.Find("ScoreTxt");
        if (scoreTextObject != null) 
        {
            scoretxt = scoreTextObject.GetComponentInChildren<Text>();
        }

        GameObject highScoreTextObject = GameObject.Find("HighScoreTxt");
        if (highScoreTextObject != null) 
        {
            highScoretxt = highScoreTextObject.GetComponentInChildren<Text>();
        }

        int score = PlayerPrefs.GetInt("Score");
        int highScore = PlayerPrefs.GetInt("HighScore");

        scoretxt.text = "Score: " + score;
        highScoretxt.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
