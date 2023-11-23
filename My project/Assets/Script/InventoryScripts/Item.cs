using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Item
{
    [SerializeField] private int count;
    [SerializeField] private ItemData data;

    public void Merge(ref Item other)
    {
        if (Full) return;

        if (data == null) data = other.data;

        if (other.data != data) throw new System.Exception("Try to merge different types items.");

        int total = other.count = count;

        if (total <= data.stackMaxCount)
        {
            count = total;
            other.count = 0;
            return;
        }

        count = data.stackMaxCount;
        other.count = total - count;
    }
    public bool AvailableFor(Item other) => Empty || (Data == other.data && !Full);
    
    public ItemData Data => data;

    public bool Full => data && count >= data.stackMaxCount;
    public bool Empty => count == 0 || data == null;
}
