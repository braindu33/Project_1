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

    public void Buy()
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3))
        {
            BuyabbleFonction buy = hit.collider.GetComponent<BuyabbleFonction>();
            if (buy && Inventory.Instance.RemoveResource(itemIndex, itemPrice))
            {
                _spawner.Spawn(positionSpawn);
            }
        }*/

        if (Inventory.Instance.RemoveResource(itemIndex, itemPrice))
        {
            _spawner.Spawn(positionSpawn);
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    private void Close()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
