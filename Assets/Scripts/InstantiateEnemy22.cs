using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy22 : MonoBehaviour
{
    private EnemyBoss boss;
    public GameObject[] skulls;
    public Transform[] point;

    void Start()
    {
        boss = FindObjectOfType<EnemyBoss>();
        InvokeRepeating("createObj", 1f, 2f);
    }

    private void Update()
    {
        if (boss == null)
        {
            Instantiate(skulls[0], point[0].position, Quaternion.identity);
            Instantiate(skulls[1], point[1].position, Quaternion.identity);
            Instantiate(skulls[2], point[2].position, Quaternion.identity);
            Instantiate(skulls[0], point[3].position, Quaternion.identity);
            Instantiate(skulls[1], point[4].position, Quaternion.identity);
            Instantiate(skulls[2], point[5].position, Quaternion.identity);
            Instantiate(skulls[0], point[6].position, Quaternion.identity);
            Instantiate(skulls[1], point[7].position, Quaternion.identity);
            Instantiate(skulls[2], point[8].position, Quaternion.identity);
            Instantiate(skulls[0], point[9].position, Quaternion.identity);
            Instantiate(skulls[1], point[10].position, Quaternion.identity);
            Instantiate(skulls[2], point[10].position, Quaternion.identity);
        }
    }

    void createObj()
    {
        GameObject skull = skulls[Random.Range(0, skulls.Length)];
        Instantiate(skull, transform.position, Quaternion.identity);
    }
}
