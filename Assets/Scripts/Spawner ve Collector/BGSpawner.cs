﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] bgs;

    private float height;
    private float highest_Y_Pos;


    private void Awake()
    {

        bgs = GameObject.FindGameObjectsWithTag("BG");


    }



    // arkadaki backgorund görüntülerinin sonsuz bir şekilde devam etmesi 


    void Start()
    {

        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;

        highest_Y_Pos = bgs[0].transform.position.y;

        for (int i=1;i<bgs.Length;i++)
        {

            if (bgs[i].transform.position.y > highest_Y_Pos)
                highest_Y_Pos = bgs[i].transform.position.y;

        }


    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "BG")
        {
            if(target.transform.position.y >= highest_Y_Pos)
            {
                Vector3 temp = target.transform.position;

                for (int i= 0; i < bgs.Length; i++)
                {
                    if(!bgs[i].activeInHierarchy)
                    {
                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);
                        highest_Y_Pos = temp.y;
                    }

                }


            }

        }
    }

}
