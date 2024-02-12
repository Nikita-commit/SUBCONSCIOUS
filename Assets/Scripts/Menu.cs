using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject effect;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public Animator anim;
    [SerializeField] AudioClip soundsButton;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        panel2.SetActive(false);
        Invoke("ActivePanel", 1.7f);
    }

    public void game()
    {
        audioSource.clip = soundsButton;
        audioSource.Play();
        StartCoroutine(ChangeScene());
    }

    public void ActivePanel()
    {
        panel.SetActive(false);
    }

    IEnumerator ChangeScene()
    {
        panel2.SetActive(true);
        Instantiate(effect, point1.position, Quaternion.identity);
        Instantiate(effect, point2.position, Quaternion.identity);
        Instantiate(effect, point3.position, Quaternion.identity);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        anim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("SampleScene");
    }

    public void readScene()
    {
        audioSource.clip = soundsButton;
        audioSource.Play();
        panel3.SetActive(true);
        anim.SetTrigger("fadeOut");
        Invoke("sceneRead", 1.2f);
    }

    void sceneRead()
    {
        SceneManager.LoadScene("Read");
    }
    public void QuitButton()
    {
        audioSource.clip = soundsButton;
        audioSource.Play();
        Application.Quit();
    }
}
