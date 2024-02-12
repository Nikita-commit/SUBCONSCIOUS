using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class floatingDamageScriptEnemy : MonoBehaviour
{
    public TextMeshPro textMP;

    private Bullet bullet;
    private Enemy enemyScript;
    private SpinningWpnScript spinningWpnScript;

    public int damageFloating;

    void Start()
    {
        /*enemyScript = FindObjectOfType<Enemy>();
        bullet = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Bullet>();
        spinningWpnScript = GameObject.FindGameObjectWithTag("SpinningWpnObject").GetComponent<SpinningWpnScript>();*/
        textMP.text = "-" + damageFloating.ToString();
    }

    public void OnAnimationOver()
    {
        Destroy(gameObject);
    }
}
