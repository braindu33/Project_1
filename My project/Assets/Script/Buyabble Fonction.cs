using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class BuyabbleFonction : MonoBehaviour
{
    //public List<Resource> PriceAndIndex = new();
    [FormerlySerializedAs("itemBuy")] public List<ItemBuy> itemBuys = new ();

    private void Awake()
    {
        foreach(var itemBuy in itemBuys)
        {
            itemBuy.buyButton.onClick.AddListener(itemBuy.Buy);
itemBuy.closeButton.onClick.AddListener(Close);
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void Close()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}