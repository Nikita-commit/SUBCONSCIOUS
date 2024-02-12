using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed;
    [HideInInspector] public float dirX, dirY;
    public Joystick joystick;
    public int health;
    [HideInInspector] public int healthColumn;

    public SpriteRenderer weaponRenderer;

    private Rigidbody2D rb;

    private Shake shake;

    public GameObject shield;
    public Shield shieldTimer;

    [HideInInspector] public int damageForFloating;
    public GameObject floatingDamage;
    public GameObject FloatingHealth;
    public Transform floatingPoint;
    public GameObject thinkObj2;
    public GameObject thinkObj3;
    public GameObject thinkObj4;
    public GameObject canvasCards;
    public GameObject Blood;
    public GameObject deadPlayer;

    [HideInInspector] public int money;
    [HideInInspector] public int coinEnd;
    public Text moneyText;
    public Text LevelText;
    [HideInInspector] public int Level;
    [HideInInspector] public int LevelInt;
    [HideInInspector] public int moneyPrefs;
    public GameObject coinsEffect;
    public GameObject FloatingCoins;

    public Image PostProcesing;

    Animator anim;

    Card cardScript;

    public GameObject SpinningWpn;
    public GameObject SecondWeapon;
    private InstantiateBulletPlayer InstBull;
    public GameObject effectLevel;

    public GameObject Allies1;
    public GameObject Allies2;
    public GameObject Allies3;
    public GameObject Allies4;
    public Transform point1;
    public Transform point2;
    public Transform point3;

    public GameObject restartPanel;
    Spawner spawnerScript;

    gameController GameCtrl;
    [SerializeField] AudioClip soundsCoin;
    [SerializeField] AudioClip soundsHeart;
    [SerializeField] AudioClip soundsShield;
    [SerializeField] AudioClip soundsLevel;
    [SerializeField] AudioClip soundsWeapon;
    [SerializeField] AudioClip soundsCat;
    [SerializeField] AudioClip soundsSlowMo;
    [SerializeField] AudioClip soundsDamage;
    [SerializeField] AudioClip soundsDamageShield;
    [SerializeField] AudioClip soundsAllies;
    [SerializeField] AudioClip soundsMegaWarrior;
    AudioSource audioSource;

    void Start()
    {
        coinEnd = 0;
        LevelInt = 0;
        rb = GetComponent<Rigidbody2D>();
        shake = GameObject.FindGameObjectWithTag("GameControllerObject").GetComponent<Shake>();
        anim = GetComponent<Animator>();
        cardScript = canvasCards.GetComponent<Card>();
        InstBull = GetComponent<InstantiateBulletPlayer>();
        SecondWeapon.SetActive(false);
        spawnerScript = FindObjectOfType<Spawner>();
        audioSource = GetComponent<AudioSource>();
        GameCtrl = FindObjectOfType<gameController>();
        if (PlayerPrefs.HasKey("moneyPrefs"))
        {
            moneyPrefs = PlayerPrefs.GetInt("moneyPrefs");
            coinEnd = coinEnd + moneyPrefs;
            moneyText.text = "" + coinEnd;
        }
        if (RewardedBool.Instance.isRewared == true)
        {
            coinEnd = coinEnd + 10;
            moneyText.text = "" + coinEnd;
            PlayerPrefs.SetInt("moneyPrefs", coinEnd);
            RewardedBool.Instance.isRewared = false;
        }
        if (RewardedBool.Instance.is100 == true)
        {
            coinEnd = coinEnd + 90;
            moneyText.text = "" + coinEnd;
            PlayerPrefs.SetInt("moneyPrefs", coinEnd);
            RewardedBool.Instance.is100 = false;
        }
        if (RewardedBool.Instance.is1000 == true)
        {
            coinEnd = coinEnd + 990;
            moneyText.text = "" + coinEnd;
            PlayerPrefs.SetInt("moneyPrefs", coinEnd);
            RewardedBool.Instance.is1000 = false;
        }
    }

    void Update()
    {
        LevelText.text = "LV " + Level;
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;

        if(dirX != 0 && dirY !=0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if(LevelInt == 40)
        {
            Level += 1;
            canvasCards.SetActive(true);
            Time.timeScale = 0.2f;
            cardScript.InstantiateCards();
            audioSource.PlayOneShot(soundsSlowMo);
            LevelInt = 0;
        }

        if (health <= 0)
        {
            Instantiate(Blood, transform.position, Quaternion.identity);
            Instantiate(deadPlayer, transform.position, Quaternion.identity);
            restartPanel.SetActive(true);
            spawnerScript.timeBetweenSpawns = 60;
            PostProcesing.color = Color.red;
            GameCtrl.deathSound();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

    public void Equip(Weapon weapon)
    {
        weaponRenderer.sprite = weapon.GFX;
        Destroy(weapon.gameObject);
        audioSource.PlayOneShot(soundsWeapon);
    }

    public void TakeDamage(int damage)
    {
        if (!shield.activeInHierarchy)
        {
            health -= damage;
            Instantiate(floatingDamage, floatingPoint.position, Quaternion.identity);
            PostProcesing.color = Color.red;
            audioSource.PlayOneShot(soundsDamage);
            Invoke("Vignette", 0.13f);
        }

        else if (shield.activeInHierarchy && damage > 0)
        {
            shieldTimer.ReduceTime(damage);
            PostProcesing.color = new Color(0, 0, 255, 255);
            audioSource.PlayOneShot(soundsDamageShield);
            Invoke("Vignette", 0.13f);
        }

        damageForFloating = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shield")
        {
            shake.CamShakeDamage();
            PostProcesing.color = new Color(0, 0, 255, 255);
            if (!shield.activeInHierarchy)
            {
                 shield.SetActive(true);
                 shieldTimer.gameObject.SetActive(true);
                 shieldTimer.isCooldown = true;
                 Destroy(collision.gameObject);
            }
            else
            {
                shieldTimer.ResetTimer();
                Destroy(collision.gameObject);
            }
            audioSource.PlayOneShot(soundsShield);
            Invoke("Vignette", 0.13f);
        }

        else if (collision.tag == "Health")
        {
            shake.CamShakeDamage();
            PostProcesing.color = new Color32(255, 0, 20, 255);
            if (health < 5)
            {
                health += 1;
            }
            Instantiate(FloatingHealth, floatingPoint.position, Quaternion.identity);
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(soundsHeart);
            Invoke("Vignette", 0.13f);
        }

        else if(collision.tag == "Coin")
        {
            shake.CamShakeDamage();
            money = UnityEngine.Random.Range(1, 4);
            coinEnd = coinEnd + money;
            moneyText.text = "" + coinEnd;
            Destroy(collision.gameObject);
            Instantiate(coinsEffect, collision.gameObject.transform.position, Quaternion.identity);
            Instantiate(FloatingCoins, floatingPoint.position, Quaternion.identity);
            PostProcesing.color = new Color32(255, 255, 80, 255);
            audioSource.PlayOneShot(soundsCoin);
            Invoke("Vignette", 0.13f);
        }

        else if (collision.tag == "ThinkCat")
        {
            audioSource.PlayOneShot(soundsCat);
            thinkObj2.SetActive(true);
        }

        else if (collision.tag == "ThinkComputer")
        {
            thinkObj3.SetActive(true);//какие нибудь кнопки
        }

        else if (collision.tag == "ThinkReady")
        {
            thinkObj4.SetActive(true);
        }

        if (collision.tag == "EnemyBoss")
        {
            health -= 5;
        }

        if (collision.tag == "Thorn")
        {
            int damage = 1;
            TakeDamage(damage);
            shake.CamShakeDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "ThinkCat")
        {
            thinkObj2.SetActive(false);
        }

        else if (collision.tag == "ThinkComputer")
        {
            thinkObj3.SetActive(false);
        }

        else if (collision.tag == "ThinkReady")
        {
            thinkObj4.SetActive(false);
        }
    }

    void Vignette()
    {
        PostProcesing.color = Color.black;
    }

    public void speedFalse()
    {
        speed = 12f;
        Invoke("speedTrue", 15f);
    }

    public void speedTrue()
    {
        speed = 6f;
    }

    public void spinningWeapon()
    {
        SpinningWpn.SetActive(true);
        Invoke("spinningWeaponFalse", 15f);
    }

    public void spinningWeaponFalse()
    {
        SpinningWpn.SetActive(false);
    }

    public void SidesAttackON()
    {
        InstBull.StartinstBullet();
        Invoke("SidesAttackOff", 15f);
    }

    public void SidesAttackOff()
    {
        InstBull.OffinstBullet();
    }

    public void TwoWeaponOn()
    {
        SecondWeapon.SetActive(true);
        Invoke("TwoWeaponOff", 15f);
    }

    public void TwoWeaponOff()
    {
        SecondWeapon.SetActive(false);
    }

    public void effectLevelOn()
    {
        effectLevel.SetActive(true);
        moneyText.text = "" + coinEnd;
        audioSource.PlayOneShot(soundsLevel);
        Invoke("effectLevelOff", 3f);
    }

    public void effectLevelOff()
    {
        effectLevel.SetActive(false);
    }

    public void Allies()
    {
        Instantiate(Allies1, point1.position, Quaternion.identity);
        Instantiate(Allies2, point2.position, Quaternion.identity);
        Instantiate(Allies3, point3.position, Quaternion.identity);
        audioSource.PlayOneShot(soundsAllies);
    }

    public void MegaKnight()
    {
        Instantiate(Allies4, point3.position, Quaternion.identity);
        audioSource.PlayOneShot(soundsMegaWarrior);
    }
}
