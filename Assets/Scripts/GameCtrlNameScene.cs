using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrlNameScene : MonoBehaviour
{
    public GameObject panel;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject obj1;

    void Start()
    {
        Invoke("activePanel", 7.5f);
        Invoke("StartGame", 9.5f);
    }

    public void func1()
    {
        Text1.SetActive(true);
        obj1.SetActive(true);
        Text2.SetActive(true);
    }

    void activePanel()
    {
        panel.SetActive(true);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
