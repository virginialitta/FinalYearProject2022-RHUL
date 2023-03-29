using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int highScore;
    public Text scoretxt;
    public bool scoreUp;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoretxt.text = "Score: " + score;

        // Find the ScoreTxt canvas in the scene
        GameObject scoreTextObject = GameObject.Find("ScoreTxt");
        if (scoreTextObject != null) 
        {
            scoretxt = scoreTextObject.GetComponentInChildren<Text>();
        }

        highScore = PlayerPrefs.GetInt("HighScore");
        
    }
    
    void Update() {}

    public void AddScore(int value)
    {
        score += value;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        scoretxt.text = "Score: " + score;
    }

    public void Enemy1Score()
    {
        AddScore(1);
        scoretxt.text = "Score: " + score;
    }

    public void Boss1Score()
    {
        AddScore(50);
        scoretxt.text = "Score: " + score;
    }

    public void Boss2Score()
    {
        AddScore(100);
        scoretxt.text = "Score: " + score;
    }

    public void ScoreUp() {
        AddScore(10);
        scoretxt.text = "Score: " + score;
    }
}
