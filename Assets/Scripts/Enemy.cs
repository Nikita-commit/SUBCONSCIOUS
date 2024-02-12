using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;
    public GameObject floatingDamage;
    public Transform floatingPoint;

    private player Player;
    private MegaKnight megaKnight;

    public GameObject StartElectricityEffect;
    public GameObject DeathEffect;
    public GameObject[] BloodPrefab;
    GameObject bloodPrefab;

    private Shake shake;

    public GameObject hill1;
    public GameObject hill2;
    public GameObject hill3;

    [HideInInspector] public int damagePlayer;
    public GameObject DeathSong;
    public AudioClip soundsPortal;
    AudioSource audioSource;

    private void Start()
    {
        Player = FindObjectOfType<player>();
        shake = GameObject.FindGameObjectWithTag("GameControllerObject").GetComponent<Shake>();
        Instantiate(StartElectricityEffect, transform.position, Quaternion.identity);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundsPortal, 0.7f);
        bloodPrefab = BloodPrefab[Random.Range(0, BloodPrefab.Length)];
    }

    void Update()
    {
        megaKnight = FindObjectOfType<MegaKnight>();
        int rand = Random.Range(0, 30);

        if (health <= 0)
        {
            Instantiate(DeathSong, transform.position, Quaternion.identity);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            switch (rand)
            {
                case 1:
                    Instantiate(hill1, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(hill3, transform.position, Quaternion.identity);
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
                case 29:
                    Instantiate(hill3, transform.position, Quaternion.identity);
                    break;
            }
            Player.LevelInt++;
            Destroy(gameObject);
        }
        if (megaKnight != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, megaKnight.transform.position, speed * Time.deltaTime);
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
            Destroy(gameObject);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            Player.LevelInt++;
        }
        if (collision.tag == "SpinningWpnObject")
        {
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
        }
        if (collision.tag == "Allies")
        {
            Destroy(gameObject);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(floatingDamage, floatingPoint.position, Quaternion.identity).GetComponent<floatingDamageScriptEnemy>().damageFloating = damage;
    }
}
