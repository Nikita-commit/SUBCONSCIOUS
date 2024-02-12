using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBulletPlayer : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public GameObject bullet;
    [SerializeField] AudioClip soundsBulls;
    public AudioSource audioSource;

    public void StartinstBullet()
    {
        InvokeRepeating("instBullet", 0.1f, 0.1f);
    }

    void instBullet()
    {
        audioSource.PlayOneShot(soundsBulls, 1f);
        Instantiate(bullet, point1.position, transform.rotation);
        Instantiate(bullet, point2.position, Quaternion.Euler(0f, 0f, -180f));
        Instantiate(bullet, point3.position, Quaternion.Euler(0f, 0f, 90f));
        Instantiate(bullet, point4.position, Quaternion.Euler(0f, 0f, -90f));
    }
    public void OffinstBullet()
    {
        CancelInvoke("instBullet");
    }
}
