using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class floatingCoins : MonoBehaviour
{
    public TextMeshPro textMP;

    private player Player;

    void Start()
    {
        Player = FindObjectOfType<player>();
        int coin = Player.GetComponent<player>().money;
        textMP.text = "+" + coin;
    }

    public void OnAnimationOver()
    {
        Destroy(gameObject);
    }
}
