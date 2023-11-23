using System;
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
    
    [field : SerializeField] public Item[] items { private set; get; }

    public bool SlotAvailable(Item itemToAdd)
    {
        foreach (var item in items)
        {
            if (item.AvailableFor(itemToAdd)) return true;
        }

        return false;
    }

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (itemToAdd.Empty) return;
            
            if (items[i].AvailableFor(itemToAdd))
            {
                items[i].Merge(ref itemToAdd);
            }
        }
    }

    public Item Pick(int slotID)
    {
        if(slotID > items.Length) throw new System.Exception($"Id {slotID} out of inventory");

        Item item = items[slotID];
        items[slotID] = new Item();

        return item;
    }
}