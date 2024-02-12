using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy16 : MonoBehaviour
{
    public GameObject effect;
    public GameObject obj;

    private void Start()
    {
        InvokeRepeating("create", 0.2f, 0.2f);
    }
    void create()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
    public void createObj()
    {
        Instantiate(obj, transform.position, Quaternion.identity);
    }
}
