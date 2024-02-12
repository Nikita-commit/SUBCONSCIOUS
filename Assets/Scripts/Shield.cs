using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float cooldown;

    [HideInInspector] public bool isCooldown;

    private Image shieldImage;
    private player player; 

    void Start()
    {
        shieldImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        isCooldown = true;
    }

    
    void Update()
    {
        if (isCooldown)
        {
            shieldImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (shieldImage.fillAmount <= 0)
            {
                shieldImage.fillAmount = 1;
                isCooldown = false;
                player.shield.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetTimer()
    {
        shieldImage.fillAmount = 1;
    }

    public void ReduceTime(int damage)
    {
        if(damage == 1)
        {
            shieldImage.fillAmount -= damage / 10f;
        }else if(damage == 2)
        {
            shieldImage.fillAmount -= damage / 8f;
        }
    }
}
