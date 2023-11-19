using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private Slot[] _slots;
    
    public int Initialize()
    {
        _slots = GetComponentsInChildren<Slot>();
        return _slots.Length;
    }

    public void UpdateDisplay(Item[] data)
    {
        
    }
}