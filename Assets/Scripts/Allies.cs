using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allies : MonoBehaviour
{
    //private Enemy7 enemy7;
    public float speed;
    public GameObject effect;
    private int damage = 1;
    private EnemyBoss enemyBoss;

    void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Invoke("DelateObj", 15f);
    }
    void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, closestEnemy.transform.position, speed * Time.deltaTime);
        if (closestEnemy.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        enemyBoss = FindObjectOfType<EnemyBoss>();
        if (enemyBoss != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyBoss.transform.position, speed * Time.deltaTime);
        }
    }

    public void DelateObj()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBoss")
        {
            collision.GetComponent<EnemyBoss>().TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

    /*void Update()
    {
        enemy = FindObjectOfType<Enemy>();
        enemy7 = FindObjectOfType<Enemy7>();
        if (enemy != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
        }
        else if (enemy7 != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy7.transform.position, speed * Time.deltaTime);
        }
    }*/
}
