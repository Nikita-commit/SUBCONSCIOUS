using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public GameObject bomb;
    public Transform pointBomb;
    public GameObject effect;

    private Shake shake;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("GameControllerObject").GetComponent<Shake>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shake.CamShakeDamage();
            Instantiate(bomb, pointBomb.position, Quaternion.identity);
            Instantiate(effect, pointBomb.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
