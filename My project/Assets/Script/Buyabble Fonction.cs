using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

[RequireComponent(typeof(Spawner))]
public class BuyabbleFonction : MonoBehaviour
{
    //public List<Resource> PriceAndIndex = new();
    [FormerlySerializedAs("itemBuy")] public List<ItemBuy> itemBuys = new ();
    
    [SerializeField] private int itemPrice = 1;
    [SerializeField] private int itemIndex = 0;
    [SerializeField] private TextMeshPro textComponent;
    [SerializeField] private Vector3 positionSpawn;

    private Spawner _spawner;
    

    private void Awake()
    {
        foreach(var itemBuy in itemBuys)
        {
            itemBuy.buyButton.onClick.AddListener(itemBuy.Buy)
        }
        
        _spawner = GetComponent<Spawner>();
    }

    private void Start()
    {
        textComponent.text = itemPrice + "wood";
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

public class ItemBuy
{
    [SerializeField] public int woodIndex;
    [SerializeField] public int woodCount = 50;
    [SerializeField] public Vector3 positionSpawn;
    [SerializeField] public Button buyButton;
    
    public Spawner spawner;
    public Action close;

    public void Buy()
    {
        if (Inventory.Instance.RemoveResource(woodCount)) 
        { 
            spawner.Spawn(positionSpawn);
        }
    close.Invoke();
    }
