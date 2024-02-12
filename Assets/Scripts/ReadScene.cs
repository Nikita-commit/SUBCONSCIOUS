using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Purchasing;

[Serializable]
public class ConsumableItem
{
    public string Name;
    public string Id;
    public string desc;
    public float price;
}
[Serializable]
public class NonConsumableItem
{
    public string Name;
    public string Id;
    public string desc;
    public float price;
}

public class ReadScene : MonoBehaviour, IStoreListener
{
    public GameObject panel;
    [SerializeField] AudioClip soundsButton;
    AudioSource audioSource;
    [SerializeField] GameObject adsButton;
    [HideInInspector] public int NoAdsBool;

    IStoreController m_StoreContoller;
    public ConsumableItem cItem;
    public ConsumableItem cItem1000;
    public ConsumableItem cItemHelp;
    public NonConsumableItem ncItem;

    public Data data;
    public Payload payload;
    public PayloadData payloadData;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetupBuilder();
        if (PlayerPrefs.HasKey("NoAdsBool"))
        {
            NoAdsBool = PlayerPrefs.GetInt("NoAdsBool");
            if(NoAdsBool == 1)
            {
                adsButton.SetActive(false);
            }
        }
    }

    void SetupBuilder()
    {

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(cItem.Id, ProductType.Consumable);
        builder.AddProduct(cItem1000.Id, ProductType.Consumable);
        builder.AddProduct(cItemHelp.Id, ProductType.Consumable);
        builder.AddProduct(ncItem.Id, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void cleanButton()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        print("Success");
        m_StoreContoller = controller;
        CheckNonConsumable(ncItem.Id);
    }

    public void Consumable_Btn_Pressed()
    {
        //AddCoins(100);
        //RewardedBool.Instance.is100 = true;
        m_StoreContoller.InitiatePurchase(cItem.Id);
    }

    public void Consumable_Btn_Pressed1000()
    {
        //AddCoins(1000);
        //RewardedBool.Instance.is1000 = true;
        m_StoreContoller.InitiatePurchase(cItem1000.Id);
    }

    public void Consumable_Btn_Pressed_Help()
    {
        //help the developer
        m_StoreContoller.InitiatePurchase(cItemHelp.Id);
    }

    public void NonConsumable_Btn_Pressed()
    {
        //RemoveAds();
        m_StoreContoller.InitiatePurchase(ncItem.Id);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        var product = purchaseEvent.purchasedProduct;

        print("Purchase Complete" + product.definition.id);

        if (product.definition.id == cItem.Id)//consumable item is pressed
        {
            string receipt = product.receipt;
            data = JsonUtility.FromJson<Data>(receipt);
            payload = JsonUtility.FromJson<Payload>(data.Payload);
            payloadData = JsonUtility.FromJson<PayloadData>(payload.json);

            int quantity = payloadData.quantity;

            for (int i = 0; i < quantity; i++)
            {
                RewardedBool.Instance.is100 = true;
            }
        }
        if (product.definition.id == cItem1000.Id)//consumable item is pressed
        {
            string receipt = product.receipt;
            data = JsonUtility.FromJson<Data>(receipt);
            payload = JsonUtility.FromJson<Payload>(data.Payload);
            payloadData = JsonUtility.FromJson<PayloadData>(payload.json);

            int quantity = payloadData.quantity;

            for (int i = 0; i < quantity; i++)
            {
                RewardedBool.Instance.is1000 = true;
            }
        }
        if (product.definition.id == cItemHelp.Id)//consumable item is pressed
        {
            string receipt = product.receipt;
        }
        else if (product.definition.id == ncItem.Id)//non consumable
        {
            removeAds();
            RewardedBool.Instance.isNoAds = true;
            PlayerPrefs.SetInt("NoAdsBool", 1);
        }

        return PurchaseProcessingResult.Complete;
    }

    public void BackButton()
    {
        audioSource.clip = soundsButton;
        audioSource.Play();
        panel.SetActive(true);
        Invoke("Back", 1.2f);
    }
    void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ReviewButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Kukharskiygames.SUBCONSCIOUSconqueryourFEAR");
    }

    public void VideoButton()
    {
        AdsManager.Instance.rewardedAds.ShowRewardedAd();
    }

    public void removeAds()
    {
        adsButton.SetActive(false);
        print("No ads active!");
    }

    public void showAds()
    {
        adsButton.SetActive(true);
    }

    public void QuitButton()
    {
        audioSource.clip = soundsButton;
        audioSource.Play();
        panel.SetActive(true);
        Invoke("quit", 1.2f);
    }

    private void quit()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        print("failed" + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        print("initialize failed" + error + message);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        print("purchase failed" + failureReason);
    }

    void CheckNonConsumable(string id)
    {
        if (m_StoreContoller != null)
        {
            var product = m_StoreContoller.products.WithID(id);
            if (product != null)
            {
                if (product.hasReceipt)//purchased
                {
                    removeAds();
                }
                else
                {
                    showAds();
                }
            }
        }
    }
}

[Serializable]
public class SkuDetails
{
    public string productId;
    public string type;
    public string title;
    public string name;
    public string iconUrl;
    public string description;
    public string price;
    public long price_amount_micros;
    public string price_currency_code;
    public string skuDetailsToken;
}

[Serializable]
public class PayloadData
{
    public string orderId;
    public string packageName;
    public string productId;
    public long purchaseTime;
    public int purchaseState;
    public string purchaseToken;
    public int quantity;
    public bool acknowledged;
}

[Serializable]
public class Payload
{
    public string json;
    public string signature;
    public List<SkuDetails> skuDetails;
    public PayloadData payloadData;
}

[Serializable]
public class Data
{
    public string Payload;
    public string Store;
    public string TransactionID;
}
