using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsPrice : MonoBehaviour
{
    public Text text;
    private player Player;
    public int coin;

    GameObject CardsObject;
    GameObject[] cards;

    private WeaponPlayer weaponPlayerScript;

    void Start()
    {
        Player = FindObjectOfType<player>();
        CardsObject = GameObject.FindGameObjectWithTag("CardsObjectTeg");
        weaponPlayerScript = GameObject.FindGameObjectWithTag("weaponPlayerObj").GetComponent<WeaponPlayer>();
        if (Player.coinEnd < coin)
        {
            text.color = Color.red;
        }
        else if (Player.coinEnd >= coin)
        {
            text.color = Color.white;
        }
        cards = GameObject.FindGameObjectsWithTag("card");
    }

    void Update()
    {

    }

    public void healthButton()
    {
        if(Player.coinEnd >= coin)
        {
            if (Player.health < 5)
            {
                Player.health += 5 - Player.health;
            }
            if (Player.coinEnd >= 100)
            {
                Player.coinEnd -= coin;
                PlayerPrefs.SetInt("moneyPrefs", Player.coinEnd);
            }
            else
            {
                Player.coinEnd -= coin;
            }
        }
        Player.effectLevelOn();
        CardsObject.SetActive(false);
        Time.timeScale = 1;
        foreach (GameObject go in cards)
        Destroy(go);
    }

    public void damageButton()
    {
        if (Player.coinEnd >= coin)
        {
            weaponPlayerScript.bullFalse();
            if (Player.coinEnd >= 100)
            {
                Player.coinEnd -= coin;
                PlayerPrefs.SetInt("moneyPrefs", Player.coinEnd);
            }
            else
            {
                Player.coinEnd -= coin;
            }
        }
        Player.effectLevelOn();
        CardsObject.SetActive(false);
        Time.timeScale = 1;
        foreach (GameObject go in cards)
        Destroy(go);
    }

    public void speedButton()
    {
        if (Player.coinEnd >= coin)
        {
            Player.speedFalse();
            if (Player.coinEnd >= 100)
            {
                Player.coinEnd -= coin;
                PlayerPrefs.SetInt("moneyPrefs", Player.coinEnd);
            }
            else
            {
                Player.coinEnd -= coin;
            }
        }
        Player.effectLevelOn();
        CardsObject.SetActive(false);
        Time.timeScale = 1;
        foreach (GameObject go in cards)
        Destroy(go);
    }

    public void spinningWpnButton()
    {
        if (Player.coinEnd >= coin)
        {
            Player.spinningWeapon();
            if (Player.coinEnd >= 100)
            {
                Player.coinEnd -= coin;
                PlayerPrefs.SetInt("moneyPrefs", Player.coinEnd);
            }
            else
            {
                Player.coinEnd -= coin;
            }
        }
        Player.effectLevelOn();
        CardsObject.SetActive(false);
        Time.timeScale = 1;
        foreach (GameObject go in cards)
        Destroy(go);
    }

    public void sidesButton()
    {
        if (Player.coinEnd >= coin)
        {
            Player.SidesAttackON();
            if (Player.coinEnd >= 100)
            {
                Player.coinEnd -= coin;
                PlayerPrefs.SetInt("moneyPrefs", Player.coinEnd);
            }
            else
            {
                Player.coinEnd -= coin;
            }
        }
        Player.effectLevelOn();
        CardsObject.SetActive(false);
        Time.timeScale = 1;
        foreach (GameObject go in cards)
        Destroy(go);
    }

    public void x2GunsButton()
    {
        if (Player.coinEnd >= coin)
        {
            Player.TwoWeaponOn();
            if (Player.coinEnd >= 100)
            {
                Player.coinEnd -= coin;
                PlayerPrefs.SetInt("moneyPrefs", Player.coinEnd);
            }
            else
            {
                Player.coinEnd -= coin;
            }
        }
        Player.effectLevelOn();
        CardsObject.SetActive(false);
        Time.timeScale = 1;
        foreach (GameObject go in cards)
        Destroy(go);
    }

    public void alliesButton()
    {
        if (Player.coinEnd >= coin)
        {
            Player.Allies();
            if (Player.coinEnd >= 100)
            {
                Player.coinEnd -= coin;
                PlayerPrefs.SetInt("moneyPrefs", Player.coinEnd);
            }
            else
            {
                Player.coinEnd -= coin;
            }
        }
        Player.effectLevelOn();
        CardsObject.SetActive(false);
        Time.timeScale = 1;
        foreach (GameObject go in cards)
        Destroy(go);
    }

    public void MegaWarriorButton()
    {
        if (Player.coinEnd >= coin)
        {
            Player.MegaKnight();
            if (Player.coinEnd >= 100)
            {
                Player.coinEnd -= coin;
                PlayerPrefs.SetInt("moneyPrefs", Player.coinEnd);
            }
            else
            {
                Player.coinEnd -= coin;
            }
        }
        Player.effectLevelOn();
        CardsObject.SetActive(false);
        Time.timeScale = 1;
        foreach (GameObject go in cards)
        Destroy(go);
    }

    public void ExitButton()
    {
        foreach (GameObject go in cards)
        Destroy(go);
    }
}
