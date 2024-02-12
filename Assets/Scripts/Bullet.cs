using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance; //��������� ������ ����
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    void Start()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Invoke("DestroyBullet", lifetime);//����������� �� ��������� �������
    }

    
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);//���������� ���� ������������ �������� � �����
        if(hitInfo.collider != null)
        {
            /*if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }*/
            DestroyBullet();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);//�������� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            DestroyBullet();
        }
        if (collision.tag == "EnemyBoss")
        {
            collision.GetComponent<EnemyBoss>().TakeDamage(damage);
            DestroyBullet();
        }
        if (collision.tag == "Enemy7")
        {
            collision.GetComponent<Enemy7>().TakeDamage(damage);
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
