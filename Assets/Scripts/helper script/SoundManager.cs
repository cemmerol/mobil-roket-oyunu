using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;


    [SerializeField]

    private AudioSource sfx;

    [SerializeField]

    private AudioClip jumpclip, gameOverClip;

    void Awake()
    {
        if (instance == null)
            instance = this;

    }
   
    public void jumpsoundfx()
    {
        sfx.clip = jumpclip;
        sfx.Play();

    }
    public void GameOversfx()
    {
        sfx.clip = gameOverClip;
        sfx.Play();

    }

   




}

