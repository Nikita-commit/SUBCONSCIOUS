using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class floatingDamageScript : MonoBehaviour
{
    [HideInInspector] public float damage;
    public TextMeshPro textMP;

    private player Player;

    void Start()
    {
        Player = FindObjectOfType<player>();
        damage = Player.damageForFloating;
        textMP.text = "-" + damage;
    }

    public void OnAnimationOver()
    {
        Destroy(gameObject);
    }
}
