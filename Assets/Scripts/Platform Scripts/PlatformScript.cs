using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformScript : MonoBehaviour
{
    [SerializeField]

    private GameObject yıldız, yukarıok;

    [SerializeField]

    private Transform spawn_Point;


    // platforumların üstünde platformla birlikte yıldız ve yukarı ok simgelerinin çıkması ( yukarı ok daha fazla ittigi için çıkma ollasılıgı daha düşük şekilde ayarlandı)
    void Start()
    {
        GameObject newYıldız = null;
        
        if (Random.Range(0, 10) > 3)
        {
            newYıldız = Instantiate(yıldız, spawn_Point.position, Quaternion.identity);
        }
        else
        {
            newYıldız = Instantiate(yukarıok, spawn_Point.position, Quaternion.identity);

        }
        newYıldız.transform.parent = transform;
    }


}
