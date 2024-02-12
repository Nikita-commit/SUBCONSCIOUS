using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardedBool : MonoBehaviour
{
    public bool isRewared = false;
    public bool is100 = false;
    public bool is1000 = false;
    public bool isNoAds = false;
    public static RewardedBool Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
