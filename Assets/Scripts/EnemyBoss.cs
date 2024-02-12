using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
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

    private Shake shake;

    public GameObject hill1;
    public GameObject hill2;
    public GameObject hill3;
    public GameObject BoomEffect;

    [SerializeField] FloatingHealthBar healthBar;
    [SerializeField] public float maxHealth;
    public GameObject DeathSong;
    GameObject bloodPrefab;
    public AudioClip soundsWalking;
    public AudioClip soundsPortal;
    AudioSource audioSource;

    private void Start()
    {
        Player = FindObjectOfType<player>();
        shake = GameObject.FindGameObjectWithTag("GameControllerObject").GetComponent<Shake>();
        Instantiate(StartElectricityEffect, transform.position, Quaternion.identity);
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundsPortal);
        audioSource.PlayOneShot(soundsWalking);
        bloodPrefab = BloodPrefab[Random.Range(0, BloodPrefab.Length)];
    }

    void Update()
    {
        int rand = Random.Range(0, 3);

        if (health <= 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            switch (rand)
            {
                case 1:
                    Instantiate(hill1, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(hill2, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(hill3, transform.position, Quaternion.identity);
                    break;
            }
            Instantiate(BoomEffect, transform.position, Quaternion.identity);
            Player.LevelInt = 40;
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
        if (collision.tag == "Player")
        {
            shake.CamShakeDamage();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(floatingDamage, floatingPoint.position, Quaternion.identity).GetComponent<floatingDamageScriptEnemy>().damageFloating = damage;
        healthBar.UpdateHealthBar(health, maxHealth);
    }
}
