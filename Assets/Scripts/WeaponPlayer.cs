using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{
    private player Player;
    public float offset;
    public Joystick joystick;
    private Vector3 difference; //вращение оружия по джойстику
    private float rotZ;

    public GameObject bullet;
    public GameObject bullet2;
    public Transform shotPoint;
    public float StartTimeBtwShoots;
    float timeBtwShots;

    private Shake shake;

    public bool bull;

    AudioSource audioSource;
    [SerializeField] AudioClip soundsBull;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        shake = GameObject.FindGameObjectWithTag("GameControllerObject").GetComponent<Shake>();
        bull = true;
        audioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if(Mathf.Abs(joystick.Horizontal) > 0.3f|| Mathf.Abs(joystick.Vertical) > 0.3f)
        {
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(timeBtwShots <= 0f)
        {
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                shake.CamShake();
                audioSource.PlayOneShot(soundsBull, 1f);
                if (bull == true)
                {
                    Instantiate(bullet, shotPoint.position, transform.rotation);
                }
                if (bull == false)
                {
                    Instantiate(bullet2, shotPoint.position, transform.rotation);
                }
                timeBtwShots = StartTimeBtwShoots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void bullFalse()
    {
        bull = false;
        Invoke("bullTrue", 15f);
    }

    public void bullTrue()
    {
        bull = true;
    }
}
