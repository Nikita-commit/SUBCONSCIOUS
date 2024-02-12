using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class floatingHealth : MonoBehaviour
{

    public TextMeshPro textMP;

    void Start()
    {
        textMP.text = "+" + 1;
    }

    public void OnAnimationOver()
    {
        Destroy(gameObject);
    }
}
