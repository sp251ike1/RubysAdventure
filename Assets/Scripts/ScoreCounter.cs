using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;

    public Text scoreText;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
        Debug.Log(amount);
        if (score >=4)
        {
            scoreText.text = score.ToString("You Win! Game Created by Stanley Freihofer");
        }
    }
}
