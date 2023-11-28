using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor.Drawers;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class InventorySysteme : MonoBehaviour
{
    [SerializeField] private InventoryDisplay display;
    
    private InventoryData _data;

    private void Awake()
    {
        var slotCount = display.Initialize(this);

        _data = new InventoryData(slotCount);

        display.UpdateDisplay(_data.Items);
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public Item AddItem(Item item)
    {
        if (!_data.SlotAvailable(item)) return item;

        _data.AddItem(ref item);
        
        display.UpdateDisplay(_data.Items);

        return item;
    }

    public Item PickItem(int slotID)
    {
        var result = _data.Pick(slotID);
        
        display.UpdateDisplay(_data.Items);

        return result;
    }

    public void SwapSlots(int slotA, int slotB)
    {
        _data.Swap(slotA, slotB);

        display.UpdateDisplay(_data.Items);
    }
}