using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;

    public void CamShake()
    {
        camAnim.SetTrigger("shake");
    }

    public void CamShake2()
    {
        camAnim.SetTrigger("shake2");
    }
    public void CamShakeDamage()
    {
        int rand = Random.Range(0, 1);

        if(rand == 0)
        {
            camAnim.SetTrigger("shakeDamage1");
        }
        else if(rand == 1)
        {
            camAnim.SetTrigger("shakeDamage2");
        }
    }
}
