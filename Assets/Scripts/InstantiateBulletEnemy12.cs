using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBulletEnemy12 : MonoBehaviour
{
    public GameObject bullet;
    public GameObject effect;
    public Transform point;

    void Start()
    {

    }

    public void instBullet()
    {
        Instantiate(bullet, point.position, transform.rotation);
    }
}
