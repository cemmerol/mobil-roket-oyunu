﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

   
    void Awake()
    {
        if (instance == null)
            instance = this;
        
    }

    public void RestartGame()
    {
        
        Invoke("LoadGamePlay",0.2f);   
    }

     void LoadGamePlay()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }





}
