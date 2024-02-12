using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public float timeBetweenSpawns;
    float nextSpawnTime;

    public GameObject thornObject;
    public Transform[] points;
    public GameObject[] enemys;
    public GameObject[] enemysBoss;
    int enemy;
    float timeThorn;

    public Transform[] spawnPoints;
    public GameObject[] spawnPointsObjects;

    private player Player;
    bool isDone = false;
    bool isDone2 = false;

    public GameObject panel;
    public GameObject panelPause;
    public GameObject bombPrefab;
    public Transform pointBomb;
    [SerializeField] AudioClip soundsButton;
    AudioSource audioSource;
    [HideInInspector] public int NoAdsBool;

    void Start()
    {
        Player = FindObjectOfType<player>();
        audioSource = GetComponent<AudioSource>();
        Invoke("ThornRestart", 10f);/////указать время 
        InvokeRepeating("instBomb", 60f, 120f);
        if (PlayerPrefs.HasKey("NoAdsBool"))
        {
            NoAdsBool = PlayerPrefs.GetInt("NoAdsBool");
        }
    }

    public void RestartButton()
    {
        panel.SetActive(true);
        audioSource.PlayOneShot(soundsButton);
        Invoke("restart", 1.2f);
    }

    void restart()
    {
        if (NoAdsBool == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
            AdsManager.Instance.interstitialAds.ShowInterstitialAd();
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ReviewButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Kukharskiygames.SUBCONSCIOUSconqueryourFEAR");
    }

    public void PauseButton()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueButton()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShopButton()
    {
        panel.SetActive(true);
        audioSource.PlayOneShot(soundsButton);
        Invoke("readScene", 1.2f);
    }

    public void readScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void ThornActive()
    {
        Transform point = points[Random.Range(0, points.Length)];
        Instantiate(thornObject, point.position, Quaternion.identity);
        ThornRestart();
    }
    public void ThornRestart()
    {
        timeThorn = Random.Range(5, 15);
        Invoke("ThornActive", timeThorn);
    }

    public void instBomb()
    {
        Instantiate(bombPrefab, pointBomb.position, Quaternion.identity);
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Transform randomSpawnPoints = spawnPoints[Random.Range(0, spawnPoints.Length)];

            if (Player.Level == 0)
            {
                Instantiate(enemys[0], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 1)
            {
                enemy = Random.Range(0, 2);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 2)
            {
                var array = new int[] { 0, 1, 2, 17 };
                var enemy = array[Random.Range(0, array.Length)];
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 3)
            {
                var array = new int[] { 0, 1, 2, 3, 17 };
                var enemy = array[Random.Range(0, array.Length)];
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 4)
            {
                enemy = Random.Range(0, 5);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 5)
            {
                if (!isDone)
                {
                    Instantiate(enemysBoss[0], randomSpawnPoints.position, Quaternion.identity);
                    isDone = true;
                }
            }
            if (Player.Level == 6)
            {
                timeBetweenSpawns = 2f;
                enemy = Random.Range(5, 8);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 7)
            {
                timeBetweenSpawns = 0.8f;
                Instantiate(enemys[8], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 8)
            {
                enemy = Random.Range(8, 12);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 9)
            {
                enemy = Random.Range(12, 14);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 10)
            {
                if (!isDone2)
                {
                    Instantiate(enemysBoss[1], randomSpawnPoints.position, Quaternion.identity);
                    isDone2 = true;
                }
            }
            if (Player.Level == 11)
            {
                Instantiate(enemys[17], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 12)
            {
                enemy = Random.Range(14, 18);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 13)
            {
                isDone2 = false;
                isDone = false;
                var array = new int[] { 18, 19, 20, 8 };
                var enemy = array[Random.Range(0, array.Length)];
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 14)
            {
                var array = new int[] { 0, 13, 15, 16 };
                var enemy = array[Random.Range(0, array.Length)];
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 15)
            {
                Instantiate(enemys[0], randomSpawnPoints.position, Quaternion.identity);
                if (!isDone)
                {
                    Instantiate(enemysBoss[0], randomSpawnPoints.position, Quaternion.identity);
                    isDone = true;
                }
            }
            if (Player.Level == 16)
            {
                timeBetweenSpawns = 1f;
                var array = new int[] { 1, 2, 7, 8, 5 };
                var enemy = array[Random.Range(0, array.Length)];
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 17)
            {
                timeBetweenSpawns = 0.8f;
                var array = new int[] { 3, 4, 6, 11 };
                var enemy = array[Random.Range(0, array.Length)];
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 18)
            {
                var array = new int[] { 2, 17, 18, 19, 20 };
                var enemy = array[Random.Range(0, array.Length)];
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 19)
            {
                var array = new int[] { 0, 2, 4, 7, 9, 10, 15 };
                var enemy = array[Random.Range(0, array.Length)];
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 20)
            {
                Instantiate(enemys[17], randomSpawnPoints.position, Quaternion.identity);
                if (!isDone2)
                {
                    Instantiate(enemysBoss[1], randomSpawnPoints.position, Quaternion.identity);
                    isDone2 = true;
                }
            }
            if (Player.Level == 21)
            {
                var array = new int[] { 1, 5, 6, 12, 16, 19, 20 };
                var enemy = array[Random.Range(0, array.Length)];
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 22)
            {
                isDone2 = false;
                isDone = false;
                timeBetweenSpawns = 1f;
                enemy = Random.Range(0, 9);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 25)
            {
                if (!isDone)
                {
                    Instantiate(enemysBoss[0], randomSpawnPoints.position, Quaternion.identity);
                    Instantiate(enemysBoss[0], randomSpawnPoints.position, Quaternion.identity);
                    isDone = true;
                }
            }
            if (Player.Level == 26)
            {
                isDone2 = false;
                isDone = false;
                timeBetweenSpawns = 0.8f;
                enemy = Random.Range(9, 18);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 30)
            {
                if (!isDone2)
                {
                    Instantiate(enemysBoss[1], randomSpawnPoints.position, Quaternion.identity);
                    Instantiate(enemysBoss[1], randomSpawnPoints.position, Quaternion.identity);
                    isDone2 = true;
                }
            }
            if (Player.Level == 31)
            {
                isDone2 = false;
                isDone = false;
                enemy = Random.Range(9, 16);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
            if (Player.Level == 36)
            {
                enemy = Random.Range(11, 21);
                Instantiate(enemys[enemy], randomSpawnPoints.position, Quaternion.identity);
            }
        }
    }
}
