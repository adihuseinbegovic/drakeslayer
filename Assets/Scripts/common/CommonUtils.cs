using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CommonUtils
{
    public static void IncreaseScore(int value)
    {
        GameObject scoreNumberTextObject = GameObject.FindWithTag("ScoreNumberText");
        if (scoreNumberTextObject != null)
        {
            var score = scoreNumberTextObject.GetComponent<Text>();
            score.text = (int.Parse(score.text) + value).ToString();
        }
    }
}
