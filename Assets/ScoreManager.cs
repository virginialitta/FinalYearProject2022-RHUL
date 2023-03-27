using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text MyText;
    public bool scoreUp;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        MyText.text = "Score: " + score;

        // Find the ScoreTxt canvas in the scene
        GameObject scoreTextObject = GameObject.Find("ScoreTxt");
        if (scoreTextObject != null) 
        {
            MyText = scoreTextObject.GetComponentInChildren<Text>();
        }
    }

    // Update is called once per frame
    public void Enemy1Score()
    {
        score += 1;
        MyText.text = "Score: " + score;
    }

    public void Boss1Score()
    {
        score += 50;
        MyText.text = "Score: " + score;
    }

    public void ScoreUp() {
        score += 10;
        MyText.text = "Score: " + score;
    }
}
