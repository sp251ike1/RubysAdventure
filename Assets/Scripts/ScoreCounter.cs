//SCRIPT MADE BY STANLEY FREIHOFER
//NO LONGER IN USE
//LOGIC MOVED TO RUBY CONTROLLER

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;

    public TMP_Text scoreText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString() + " /4 Robots Fixed";    
    }

    public void ChangeScore(int amount)
    {
        score += amount;
        //scoreText.text = score.ToString();
        scoreText.text = "Score: " + score.ToString() + " /4 Robots Fixed";
        Debug.Log(amount);
        if (score >=4)
        {
            scoreText.text = score.ToString("You Win! Game Created by Stanley Freihofer");
        }
    }
}
