using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class InventoryData
{
    public InventoryData(int slotCount)
    {
        Items = new Item[slotCount];
    }
    
    public Item[] Items { private set; get; }

    public bool SlotAvailable(Item itemToAdd)
    {
        foreach (var item in Items)
        {
            if (item.AvailableFor(itemToAdd)) return true;
        }

        return false;
    }

    public void AddItem(ref Item itemToAdd)
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

    public Item Pick(int slotID)
    {
        if(slotID > Items.Length) throw new System.Exception($"Id {slotID} out of inventory");

        Item item = Items[slotID];
        Items[slotID] = new Item();

        return item;
    }

    public void Swap(int slotA, int slotB)
    {
        (Items[slotA], Items[slotB]) = (Items[slotB], Items[slotA]);
    }
}