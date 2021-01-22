using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Timescript : MonoBehaviour
{
    public static Timescript instance;

    public float time;
    public Text time_t;
    private Text scoreText;

    private int score = 0;

    public Text FinalScore;
    public Text HighTimeScore;
    public Animator endPanelAnim;



    void Awake()
    {
        Makeinstance();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "0";
    }
    void Start()
    {
        time = -2;
        time_t.text = " " + (int)time;

    }

    void Makeinstance()
    {
        if (instance == null)
            instance = this;


    }



    void Update()
    {
        time +=Time.deltaTime;
        time_t.text = " " + (int)time;
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "ExtraPush")
        {
            target.gameObject.SetActive(false);
            score = score + 2;
            scoreText.text = score.ToString();

        }

        if (target.tag == "NormalPush")
        {
            target.gameObject.SetActive(false);
            score++;
            scoreText.text = score.ToString();
        }



    }


    public void GameOver()
    {

        HighTimeScore.text = "Time Score :" + time_t.text + " Second";
        FinalScore.text = " : "+scoreText.text;
        endPanelAnim.Play("EndPanel");

    }


    public void Again(){
        
        GameManager.instance.RestartGame();

    }


}
