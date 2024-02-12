using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int numberOfHeart;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite brokenHeart;
    player Player;

    private void Start()
    {
        Player = FindObjectOfType<player>();
    }

    private void Update()
    {
        if (Player.health > numberOfHeart)
        {
            Player.health = numberOfHeart;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numberOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (i < Player.health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = brokenHeart;
            }
        }
    }
}
