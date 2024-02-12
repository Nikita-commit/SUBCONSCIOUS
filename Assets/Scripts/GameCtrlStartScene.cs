using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrlStartScene : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject obj1;
    public GameObject lightObj;

    public void func1()
    {
        Text1.SetActive(false);
        obj1.SetActive(false);
        Text2.SetActive(true);
        lightObj.SetActive(true);
    }
        

    public void func2()
    {
        SceneManager.LoadScene("GameName");
    }
}
