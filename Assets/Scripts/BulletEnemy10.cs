using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy10 : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance; //дистанция полета пули
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    void Start()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Invoke("DestroyBullet", lifetime);//уничтожение по истечении времени
    }


    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);//определяем слой столкновения обьектов с пулей
        if (hitInfo.collider != null)
        {
            DestroyBullet();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<player>().TakeDamage(damage);
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
