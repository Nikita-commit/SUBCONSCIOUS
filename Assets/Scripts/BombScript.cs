using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float attackRange;
    public LayerMask enemyLayer;
    public Transform attackPoint;
    public int damage;
    public GameObject BoomEffect;
    public GameObject ParticleEffectBoom;
    [SerializeField] AudioClip soundsBoom;
    [SerializeField] AudioClip soundsFitil;
    [SerializeField] AudioClip soundsStart;
    AudioSource audioSource;
    public GameObject SpriteObj;
    public GameObject SpriteGhost;
    private EnemyBoss enemyBoss;
    private Enemy7 enemy7;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundsStart);
        audioSource.clip = soundsFitil;
        audioSource.Play();
    }

    public void BOOM()
    {
        Collider2D[] enemysTODamage = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D col in enemysTODamage)
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
        }
        if(enemyBoss != null)
        {
            Collider2D[] enemysTODamageBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D col in enemysTODamage)
            {
                col.GetComponent<EnemyBoss>().TakeDamage(damage);
            }
        }
        if (enemy7 != null)
        {
            Collider2D[] enemysTODamageBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D col in enemysTODamage)
            {
                col.GetComponent<Enemy7>().TakeDamage(damage);
            }
        }
        audioSource.clip = soundsBoom;
        audioSource.Play();
        Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Instantiate(ParticleEffectBoom, transform.position, Quaternion.identity);
        Destroy(SpriteObj);
        Destroy(SpriteGhost);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
