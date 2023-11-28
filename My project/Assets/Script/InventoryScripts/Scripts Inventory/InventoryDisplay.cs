using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private int _draggedSlotIndex;
    
    private InventorySysteme _inventory;
    
    private Slot[] _slots;
    
    public int Initialize(InventorySysteme inventory)
    {
        _slots = GetComponentsInChildren<Slot>();
        _inventory = inventory;

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].Initialized(this, i);    
        }
        
        return _slots.Length;
    }

    public void UpdateDisplay(Item[] items)
    {
        for (var i = 0; i < _slots.Length; i++)
        {
            _slots[i].UpdateDisplay(items[i]);
        }
    }

    #region Inputs

    public void ClickSlot(int index)
    {
        Debug.Log($"Click on slot : {index}");
    }

    public void DragSlot(int index) => _draggedSlotIndex = index;

    public void DropOnSlot(int index)
    {
        _inventory.SwapSlots(_draggedSlotIndex, index);
    }

    #endregion
}