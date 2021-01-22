using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D vucut;

    public float move_Speed = 2f;

    public float normal_Push = 10f;
    public float extra_Push = 14f;

    private bool initial_Push;

    private int itme_miktarı;

    private bool player_Died;
    



    void Awake()
    {

        vucut = GetComponent<Rigidbody2D>();
           

    }
   
    void FixedUpdate()
    {
        Move();
        

    }
    void Move()
    {
        if (player_Died)
            return;
       
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            vucut.velocity = new Vector2(move_Speed, vucut.velocity.y);

        } else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            vucut.velocity = new Vector2(-move_Speed, vucut.velocity.y);

        }

    }

     void OnTriggerEnter2D(Collider2D target) 
    {

        if (player_Died)
            return;

        if (target.tag == "ExtraPush") // ilk itme kısmında extra hızlandırma
        {
            if (!initial_Push)
            {
                initial_Push = true;

                vucut.velocity = new Vector2(vucut.velocity.x, 18f);

                target.gameObject.SetActive(false);

                SoundManager.instance.jumpsoundfx();




                return;

            }


        }
        if (target.tag == "NormalPush")
        {
            vucut.velocity = new Vector2(vucut.velocity.x, 12f);

            target.gameObject.SetActive(false);

            itme_miktarı++;

            SoundManager.instance.jumpsoundfx();

        }
        if (target.tag == "ExtraPush") // yukarı okları aldıgındaki extra hızlandırma
        {
            vucut.velocity = new Vector2(vucut.velocity.x, extra_Push);

            target.gameObject.SetActive(false);

            itme_miktarı++;

            SoundManager.instance.jumpsoundfx();


            // platformların sonsuz bir şekilde yukarıya dogru çıkmaya devam etmesi 
        }
        if (itme_miktarı == 2)
        {
            itme_miktarı = 0;
            PlaftormSpawner.instance.SpawnPlatforms();

        }


        if(target.tag== "FallDown" || target.tag=="Gezegen")
        {
            player_Died = true;

            SoundManager.instance.GameOversfx();

            // GameManager.instance.RestartGame();   

            Timescript.instance.GameOver();
            

            // sesin çıkması soundmanager

        }
    }
}
