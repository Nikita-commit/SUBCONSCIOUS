using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaKnight : MonoBehaviour
{
    public float speed;
    public GameObject effect;
    private int damage = 2;

    void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Invoke("DelateObj", 20f);
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

    public void DelateObj()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
