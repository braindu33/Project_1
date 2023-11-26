using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private Slot[] _slots;
    
    public int Initialize()
    {
        _slots = GetComponentsInChildren<Slot>();

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].Initialized(this, i);    
        }
        
        return _slots.Length;
    }

    public void UpdateDisplay(Item[] items)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].UpdateDisplay(items[i]);
        }
    }

    public void ClickSlot(int index)
    {
        Debug.Log($"Click on slot : {index}");
    }
}