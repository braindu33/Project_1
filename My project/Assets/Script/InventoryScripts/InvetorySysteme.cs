using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetorySysteme : MonoBehaviour
{
    [SerializeField] private InventoryDisplay display;
    private InventoryData _data;

    private void Awake()
    {
        display.Initialize();

        _data = new InventoryData();
    }

    public Item AddItem(Item item)
    {
        return item;
    }

    public Item PickItem()
    {
        
    }
}

public class InventoryDisplay : MonoBehaviour
{
    public void Initialize()
    {
        
    }
}

public class InventoryData
{
    
}