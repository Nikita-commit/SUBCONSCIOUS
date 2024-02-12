using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delate : MonoBehaviour
{
    public float lifetime;
    public GameObject DeathEffect;
    void Start()
    {
        Invoke("Destroy", lifetime);
    }

    public void Destroy()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
