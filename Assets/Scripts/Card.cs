using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    CardsPrice cardsPrice;
    public Transform transformParent;
    public GameObject[] CardsMassive;
    int cardsNum1;
    int cardsNum2;
    int cardsNum3;

    private player Player;
    GameObject CardsObject;

    private void Start()
    {
        Player = FindObjectOfType<player>();
        CardsObject = GameObject.FindGameObjectWithTag("CardsObjectTeg");
    }

    private void Update()
    {
        cardsPrice = FindObjectOfType<CardsPrice>();
    }

    public void InstantiateCards()
    {
        cardsNum1 = Random.Range(0, CardsMassive.Length);
        cardsNum2 = Random.Range(0, CardsMassive.Length);
        cardsNum3 = Random.Range(0, CardsMassive.Length);
        Instantiate(CardsMassive[cardsNum1], transformParent);
        Instantiate(CardsMassive[cardsNum2], transformParent);
        Instantiate(CardsMassive[cardsNum3], transformParent);
    }

    public void exitButton()
    {
        Player.effectLevelOn();
        CardsObject.SetActive(false);
        Time.timeScale = 1;
        cardsPrice.ExitButton();
    }
}
