using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelateNoEffect : MonoBehaviour
{
    public float sec;
    [SerializeField] AudioClip sounds;
    AudioSource audioSource;

    void Start()
    {
        Invoke("Destroy", sec);
        audioSource = GetComponent<AudioSource>();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void soundFunc()
    {
        audioSource.PlayOneShot(sounds);
    }
}
