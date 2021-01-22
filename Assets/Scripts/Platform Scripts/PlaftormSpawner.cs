using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaftormSpawner : MonoBehaviour
{
    public static PlaftormSpawner instance;

    [SerializeField]

    private GameObject Left_platform, right_Platform;
    private float left_X_Min = -2.45f, left_X_Max = -1.4f, right_X_Min = 2.4f, right_X_Max = 1.6f; // telefon ekranı içerisindeki alanların boyutları .

    private float y_Treshold = 2.6f;

    private float last_Y;

    public int spawn_Count = 8;

    private int platform_Spawned;


    [SerializeField]

    private Transform platform_Parent;

    [SerializeField]

    private GameObject gezegen;
    public float gezegen_y = 6f;
    private float gezegen_x_min = -2.9f, gezegen_X_max =2.9f;



    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        last_Y = transform.position.y;

        SpawnPlatforms();

    }

    public void SpawnPlatforms()
    {
        Vector2 temp = Vector2.zero;
        GameObject newPlatform = null;

        for(int i = 0; i < spawn_Count; i++)
        {
            temp.y = last_Y;

            // platformların sağda ve solda çapraz şekilde çıkması 


            if((platform_Spawned %2) == 0)
            {


                temp.x = Random.Range(left_X_Min,left_X_Max);

                newPlatform = Instantiate(right_Platform, temp, Quaternion.identity);
            } else
            {
                temp.x = Random.Range(right_X_Min, right_X_Max);

                newPlatform = Instantiate(Left_platform, temp, Quaternion.identity);

            }


            // platform parent  == platformların unity arayüzünde defalarca kez çıkmasını engellemek amaçlı kullanılan kod 

            newPlatform.transform.parent = platform_Parent;

            last_Y += y_Treshold;
            platform_Spawned++;

        }

        if (Random.Range(0, 10) > 6)
        {
            SpawnPlanet();

        }

    }

      // gezegen oluşturma kısımları
    void SpawnPlanet()
    {

        Vector2 temp = transform.position;
        temp.x = Random.Range(gezegen_x_min,gezegen_X_max);
        temp.y += gezegen_y;


        GameObject NewPlanet = Instantiate(gezegen, temp, Quaternion.identity);
        NewPlanet.transform.parent = platform_Parent;

    }

}
