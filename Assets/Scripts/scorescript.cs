using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scorescript : MonoBehaviour
{

    private Text scoreText;

    private int score = 0;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "0";

    }

     void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag=="ExtraPush")
        {
            target.gameObject.SetActive(false);
            score = score + 2;
            scoreText.text = score.ToString();

        }

        if (target.tag == "NormalPush" )
        {
            target.gameObject.SetActive(false);
            score++;
            scoreText.text = score.ToString();
        }



    }
}
