using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float turnSpeed;
    public Sprite GFX;
    public GameObject Effect;
    public GameObject Effect2;

    private Shake shake;

    public GameObject joystick;

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("GameControllerObject").GetComponent<Shake>();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shake.CamShake2();
            collision.GetComponent<player>().Equip(this);//прочитать про this
            Instantiate(Effect, transform.position, Quaternion.identity);
            joystick.SetActive(true);
            Destroy(Effect2);
        }
    }
}
