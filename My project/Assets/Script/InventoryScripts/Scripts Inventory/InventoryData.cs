using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class InventoryData
{
    public InventoryData(int slotCount)
    {
        Items = new Resource[slotCount];
    }
    
    public Resource[] Items { private set; get; }

    public bool SlotAvailable(Resource itemToAdd)
    {
        foreach (var item in Items)
        {
            if (item.AvailableFor(itemToAdd)) return true;
        }

        return false;
    }

    public void AddItem(ref Resource itemToAdd)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (itemToAdd.Empty) return;
            
            if (Items[i].AvailableFor(itemToAdd))
            {
                Items[i].Merge(ref itemToAdd);
            }
        }
    }

    public Resource Pick(int slotID)
    {
        if(slotID > Items.Length) throw new System.Exception($"Id {slotID} out of inventory");

        Resource item = Items[slotID];
        Items[slotID] = new Resource();

        return item;
    }

    public void Swap(int slotA, int slotB)
    {
        (Items[slotA], Items[slotB]) = (Items[slotB], Items[slotA]);
    }
}