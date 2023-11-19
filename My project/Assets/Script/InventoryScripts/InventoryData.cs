using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public InventoryData(int slotCount)
    {
        items = new Item[slotCount];
    }
    
    public Item[] items { private set; get; }

    public bool SlotAvailable(Item itemToAdd)
    {
        throw new System.NotImplementedException();
    }

    public Item AddItem(Item itemToAdd)
    {
        throw new System.NotImplementedException();
    }

    public Item Pick(int sloID)
    {
        throw new System.NotImplementedException();
    }
}