using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yenioyuncu : MonoBehaviour
{
    public GameObject oyuncu1;
    public GameObject oyuncu2;
    public GameObject Panel;
    void Start()
    {
        oyuncu1.SetActive(false);
        oyuncu2.SetActive(false);
        Panel.SetActive(true);
    }


    public void oyuncu1button()
    {
        oyuncu1.SetActive(true);
        oyuncu2.SetActive(false);
        Panel.SetActive(false);



    }

    public void oyuncu2button()
    {
        oyuncu1.SetActive(false);
        oyuncu2.SetActive(true);
        Panel.SetActive(false);


    }



}
