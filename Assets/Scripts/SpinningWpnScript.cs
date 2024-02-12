using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWpnScript : MonoBehaviour
{
    [HideInInspector] public int damage;

    void Start()
    {
        damage = 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
        if (collision.tag == "EnemyBoss")
        {
            collision.GetComponent<EnemyBoss>().TakeDamage(damage);
        }
        if (collision.tag == "Enemy7")
        {
            collision.GetComponent<Enemy7>().TakeDamage(damage);
        }
    }
}
