using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy12 : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance; //��������� ������ ����
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    Transform Enemy12Trm;

    void Start()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Invoke("DestroyBullet", lifetime);//����������� �� ��������� �������
        Enemy12Trm = GameObject.Find("Enemy12(Clone)").GetComponent<Transform>();
    }


    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);//���������� ���� ������������ �������� � �����
        if (hitInfo.collider != null)
        {
            DestroyBullet();
        }
        if(Enemy12Trm.rotation.eulerAngles.y == -180)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
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
