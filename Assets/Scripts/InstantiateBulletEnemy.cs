using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBulletEnemy : MonoBehaviour
{
    public GameObject bullet;
    public GameObject effect;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;

    void Start()
    {
        InvokeRepeating("instBullet", 1f, 1f);
        InvokeRepeating("instEffect", 0.05f, 0.05f);
    }

    // Update is called once per frame
    void instBullet()
    {
        Instantiate(bullet, point1.position, transform.rotation);
        Instantiate(bullet, point2.position, Quaternion.Euler(0f,0f,-180f));
        Instantiate(bullet, point3.position, Quaternion.Euler(0f, 0f, 90f));
        Instantiate(bullet, point4.position, Quaternion.Euler(0f, 0f, -90f));
    }

    void instEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}

