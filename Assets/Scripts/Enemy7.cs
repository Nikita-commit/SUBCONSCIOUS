using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7 : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;
    public GameObject floatingDamage;
    public Transform floatingPoint;

    private player Player;

    public GameObject StartElectricityEffect;
    public GameObject DeathEffect;
    public GameObject[] BloodPrefab;
    GameObject bloodPrefab;

    private Shake shake;

    public GameObject hill1;
    public GameObject hill2;
    public GameObject hill3;

    public GameObject effect;
    public GameObject obj;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform point5;
    public Transform point6;
    public Transform point7;
    public Transform point8;
    public Transform point9;
    public Transform point10;
    public Transform point11;
    public Transform point12;
    public GameObject DeathSong;
    public AudioClip soundsWalking;
    public AudioClip soundsPortal;
    AudioSource audioSource;

    private void Start()
    {
        Player = FindObjectOfType<player>();
        shake = GameObject.FindGameObjectWithTag("GameControllerObject").GetComponent<Shake>();
        Instantiate(StartElectricityEffect, transform.position, Quaternion.identity);
        InvokeRepeating("create", 0.2f, 0.2f);
        InvokeRepeating("createObj", 0.5f, 1f);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundsPortal);
        audioSource.PlayOneShot(soundsWalking, 0.5f);
        bloodPrefab = BloodPrefab[Random.Range(0, BloodPrefab.Length)];
    }

    void Update()
    {
        int rand = Random.Range(0, 30);
        if (health <= 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            Instantiate(DeathSong, transform.position, Quaternion.identity);
            switch (rand)
            {
                case 1:
                    Instantiate(hill1, transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(hill2, transform.position, Quaternion.identity);
                    break;
                case 10:
                    Instantiate(hill3, transform.position, Quaternion.identity);
                    break;
                case 15:
                    Instantiate(hill3, transform.position, Quaternion.identity);
                    break;
                case 20:
                    Instantiate(hill3, transform.position, Quaternion.identity);
                    break;
                case 25:
                    Instantiate(hill3, transform.position, Quaternion.identity);
                    break;
            }
            Player.LevelInt++;
            spawn();
            Destroy(gameObject);
        }
        else if (Player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject bloodPrefab = BloodPrefab[Random.Range(0, BloodPrefab.Length)];
        if (collision.tag == "Player")
        {
            shake.CamShakeDamage();
            collision.GetComponent<player>().TakeDamage(damage);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            Player.LevelInt++;
            spawn();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(floatingDamage, floatingPoint.position, Quaternion.identity).GetComponent<floatingDamageScriptEnemy>().damageFloating = damage;
    }

    void create()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
    void createObj()
    {
        Instantiate(obj, transform.position, Quaternion.identity);
    }

    void spawn()
    {
        Instantiate(obj, point1.position, Quaternion.identity);
        Instantiate(obj, point2.position, Quaternion.identity);
        Instantiate(obj, point3.position, Quaternion.identity);
        Instantiate(obj, point4.position, Quaternion.identity);
        Instantiate(obj, point5.position, Quaternion.identity);
        Instantiate(obj, point6.position, Quaternion.identity);
        Instantiate(obj, point7.position, Quaternion.identity);
        Instantiate(obj, point8.position, Quaternion.identity);
        Instantiate(obj, point9.position, Quaternion.identity);
        Instantiate(obj, point10.position, Quaternion.identity);
        Instantiate(obj, point11.position, Quaternion.identity);
        Instantiate(obj, point12.position, Quaternion.identity);
    }
}
