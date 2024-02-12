using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public GameObject panel;
    public GameObject facesArena;
    Animator anim;
    [SerializeField] AudioClip soundsTime;
    [SerializeField] AudioClip soundsRoom;
    [SerializeField] AudioClip soundsArena;
    [SerializeField] AudioClip soundsHuuu;
    [SerializeField] AudioClip soundsDead;
    [SerializeField] AudioClip soundsDeadPanel;
    AudioSource audioSource;
    private float startTime = 3;
    public Text timerText;
    public GameObject timerTextObject;

    private void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.GetComponent<Spawner>().enabled = false;
        audioSource = GetComponent<AudioSource>();
        timerTextObject.SetActive(false);
    }

    private void timerFunc()
    {
        if (startTime > 0)
        {
            anim.SetTrigger("volume");
            timerTextObject.SetActive(true);
            timerText.text = startTime.ToString();
            audioSource.clip = soundsTime;
            audioSource.Play();
            StartCoroutine(timerCor());
        }
        else if (startTime == 0)
        {
            EnemySpawn();
        }
    }

    IEnumerator timerCor()
    {
        yield return new WaitForSeconds(1f);
        startTime -= 1;
        timerText.text = startTime.ToString();
        timerFunc();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            anim.SetTrigger("go");
            facesArena.SetActive(true);
            audioSource.PlayOneShot(soundsHuuu);
            Invoke("timerFunc", 1.1f);
        }
    }

    public void EnemySpawn()
    {
        Destroy(timerTextObject);
        gameObject.GetComponent<Spawner>().enabled = true;
        audioSource.clip = soundsArena;
        audioSource.Play();
    }

    public void deathSound()
    {
        audioSource.PlayOneShot(soundsDead);
        audioSource.clip = soundsDeadPanel;
        audioSource.Play();
    }
}
